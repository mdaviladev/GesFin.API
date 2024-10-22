using GesFin.Api.Data;
using GesFin.Core.Handles;
using GesFin.Core.Models;
using GesFin.Core.Requests.Categories;
using GesFin.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace GesFin.Api.Handlers
{
    public class CategoryHandler(AppDBContext context) : ICategoryHandler
    {
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                var category = new Category
                {
                    Description = request.Description,
                    Title = request.Title,
                    UserId = request.UserId
                };
                await context.Categories.AddAsync(category);
                await context.AddRangeAsync();
                return new Response<Category?>(category, 201, "Registro criado com sucesso!");
            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex, "Falha na criação do registro." + ex.Message);
                return new Response<Category?>(null, 500, "Não foi possível criar o registro");
            }

        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        {
            try
            {
                var category = await context
                           .Categories
                           .FirstOrDefaultAsync(x => x.Id == request.Id
                                             && x.UserId == request.UserId);
                if (category is null)
                {
                    return new Response<Category?>(null, 501, "Registro não encontrado!");
                }
                context.Categories.Remove(category);
                return new Response<Category?>(category);
            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível excluir o registro");
            }

        }

        public async Task<Response<List<Category>>> GetByAllAsync(GetAllCategoriesRequest request)
        {
            var query = context.Categories
                               .AsNoTracking()
                               .Where(x => x.UserId == request.UserId)
                               .OrderBy(x => x.Title);

            var categories = await query
                                    .Skip((request.PageNumber - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Category>>(categories,
                                                     count,
                                                     request.PageNumber,
                                                     request.PageSize);

        }


        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        {
            try
            {
                var category = await context
                    .Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return category is null
                    ? new Response<Category?>(null, 404, "Categoria não encontrada")
                    : new Response<Category?>(category);
            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível recuperar o registro");
            };
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await context
                                       .Categories
                                       .FirstOrDefaultAsync(x => x.Id == request.Id
                                                          && x.UserId == request.UserId);
                if (category == null)
                {
                    return new Response<Category?>(null, 404, "Registro não encontrado!");
                }
                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category);
            }
            catch
            {
                return new Response<Category?>(null, 500, "[XT0258] Não pois possivel alterar o registro.");
            }
        }
    }
}