
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ShopOnlineCafe.Client.Authentication;
using ShopOnlineCafe.Shared;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace ShopOnlineCafe.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navManager;
        private readonly AuthenticationStateProvider authStateProvider;

        public UserService(HttpClient httpClient, NavigationManager navManager, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _navManager = navManager;
            this.authStateProvider = authStateProvider;
        }



        public async Task Authenticate(LoginRequest loginRequest)
        {
            var loginResponse = await _httpClient.PostAsJsonAsync<LoginRequest>("/api/Account/Login", loginRequest);

            if (loginResponse.IsSuccessStatusCode)
            {
                var userSession = await loginResponse.Content.ReadFromJsonAsync<UserSession>();
                var customAuthStateProvider = (CustomAuthenticationStateProcider)authStateProvider;
                await customAuthStateProvider.UpdateAuthenticationState(userSession);
                _navManager.NavigateTo("/", true);
               
            }
            else if (loginResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                
                return ;
            }
            
        }

        public async Task<bool> Register(RegisterRequest registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Account/Register", registerRequest);
            if(result.IsSuccessStatusCode)
            {
                _navManager.NavigateTo("/login");
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
