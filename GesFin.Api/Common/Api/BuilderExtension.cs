using GesFin.Api.Data;
using GesFin.Api.Handlers;
using GesFin.Core;
using GesFin.Core.Handles;
using GesFin.Core.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GesFin.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(
        this WebApplicationBuilder builder)
        {
            Configurations.ConnectionString =
                builder
                    .Configuration
                    .GetConnectionString("DefaultConnection")
                ?? string.Empty;

            Configurations.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            Configurations.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
            ApiConfiguration.StripeApiKey = builder.Configuration.GetValue<string>("StripeApiKey") ?? string.Empty;

            //StripeConfiguration.ApiKey = ApiConfiguration.StripeApiKey;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
        }

        public static void AddSecurity(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            builder.Services.AddAuthorization();
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder
                .Services
                        .AddDbContext<AppDBContext>(
                            x => { x.UseSqlServer(Configurations.ConnectionString); });

            builder.Services
                .AddIdentityCore<User>()
                .AddRoles<IdentityRole<long>>()
                .AddRoleStore<AppDBContext>()
                .AddApiEndpoints();
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                options => options.AddPolicy(
                    ApiConfiguration.CorsPolicyName,
                    policy => policy
                        .WithOrigins([
                            Configurations.BackendUrl,
                            Configurations.FrontendUrl
                        ])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                ));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddTransient<ICategoryHandler, CategoryHandler>();

            // builder
            //     .Services
            //     .AddTransient<ITransactionHandler, TransactionHandler>();

            // builder
            //     .Services
            //     .AddTransient<IReportHandler, ReportHandler>();

            // builder
            //     .Services
            //     .AddTransient<IOrderHandler, OrderHandler>();

            // builder
            //     .Services
            //     .AddTransient<IStripeHandler, StripeHandler>();
        }
    }
}