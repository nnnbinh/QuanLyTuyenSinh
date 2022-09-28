﻿using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;


namespace QuanLyTuyenSinh.Client
{

    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly HttpClient httpClient;

        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            this.localStorage = localStorage;
            this.httpClient = httpClient;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await localStorage.GetItemAsStringAsync("token");
            var identity = new ClaimsIdentity();

            httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token)) 
            {
                var validator = new JwtSecurityTokenHandler();
                var jwttoken = validator.ReadJwtToken(token.Replace("\"", ""));

                if (DateTime.Compare(DateTime.Now, jwttoken.ValidTo.ToLocalTime()) < 0) { 
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
                
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Replace("\"",""));
                }
                else
                {
                    string userId = jwttoken.Claims.First(claim => claim.Type == "UserId").Value;

                    var result = await httpClient.PostAsJsonAsync("api/Auth/refresh", userId);
                    if(result.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine(result.Content.ReadAsStringAsync());
                        Console.WriteLine("toang");
                    }
                    else { 
                        var newToken = await result.Content.ReadAsStringAsync();
                        await localStorage.SetItemAsync("token", newToken);
                        identity = new ClaimsIdentity(ParseClaimsFromJwt(newToken), "jwt");

                        httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                    }
                }
            }
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
