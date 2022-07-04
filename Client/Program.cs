global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
global using QuanLyTuyenSinh.Client.Services.SinhvienServices;
global using QuanLyTuyenSinh.Shared;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QuanLyTuyenSinh.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<ISinhvientrungtuyen, Sinhvientrungtuyen>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
await builder.Build().RunAsync();
