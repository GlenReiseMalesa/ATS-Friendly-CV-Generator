using ATS_Friendly_CV_Generator;
using ATS_Friendly_CV_Generator.Data;
using ATS_Friendly_CV_Generator.Services;
using Microsoft.AspNetCore.Components.Web;
using SqliteWasmHelper;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//DB code
try
{    // sqlitewasmhelper automatically handles the loadDatabaseFromCache and syncDatabaseToCache logic i was writing manually in my JS script.
    // Your service registration
    builder.Services.AddSqliteWasmDbContextFactory<AppDbContext>(
        opts => opts.UseSqlite("Data Source=app.db"));
    builder.Services.AddScoped<ExperienceService>();
    builder.Services.AddScoped<EducationService>();
    builder.Services.AddScoped<DatabaseService>();
    builder.Services.AddScoped<SkillsService>();
    builder.Services.AddScoped<DatabaseService>();


    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

    var host = builder.Build();

    // Add global error handling
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Application starting...");

    //await host.RunAsync();
    await builder.Build().RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"FATAL ERROR: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
    throw;
}
//DB code



//await builder.Build().RunAsync();
