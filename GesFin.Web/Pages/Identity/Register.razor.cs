using GesFin.Core.Handles;
using GesFin.Core.Requests.Account;
using GesFin.Web.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace GesFin.Web.Pages.Identity;

public partial class RegisterPage : ComponentBase
{
    #region Dependencies 
    [Inject]
    public ISnackbar snackbar { get; set; } = null!;
    [Inject]
    public IAccountHandler Handler { get; set; } = null!;
    [Inject]
    public NavigationManager navigationManager { get; set; } = null!;

    [Inject]
    public AuthenticationStateProvider authenticationStateProvider { get; set; } = null!;
    #endregion
    public MudForm? _mudForm { get; set; }
    
    #region Properties
    public bool IsBusy { get; set; } = false;
    public RegisterRequest InputModel { get; set; } = new();

    #endregion

    #region Overrides
    protected override async Task OnInitializedAsync()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is { IsAuthenticated: true })
            navigationManager.NavigateTo("/");
    }

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.RegisterAsync(InputModel);

            if (result.IsSuccess)
            {
                snackbar.Add(result.Message, Severity.Success);
                navigationManager.NavigateTo("/login");
            }
            else
                snackbar.Add(result.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    

}