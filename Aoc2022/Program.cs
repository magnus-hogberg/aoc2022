using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Aoc2022;
using Aoc2022.Pages;
using Aoc2022.Solutions;
using BlazorStrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<InjectionTest>();

builder.Services.AddTransient<ISolution, SolutionDec1>();

builder.Services.AddTransient<ISolutionFactory, SolutionFactory>();

builder.Services.AddBlazorStrap();

await builder.Build().RunAsync();
