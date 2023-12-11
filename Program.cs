using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using csci340_iseegreen.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

string aspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "";
Console.WriteLine($"[DebugLog][Program] ASPNETCORE_ENVIRONMENT='{aspNetCoreEnvironment}'");

// Add services to the container.
builder.Services.AddRazorPages();

if (aspNetCoreEnvironment == "Development")
{
    Console.WriteLine("[DebugLog][Program] Development environment detected, using SQLite connection string...");
    builder.Services.AddDbContext<ISeeGreenContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ISeeGreenContextSQLite") ?? throw new InvalidOperationException("Connection string 'ISeeGreenContextSQLite' not found.")));
    Console.WriteLine("[DebugLog][Program] ISeeGreenContext added.");
}
else
{
    Console.WriteLine("[DebugLog][Program] Non-development environment detected, using SQL Server connection string...");
    builder.Services.AddDbContext<ISeeGreenContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING") ?? throw new InvalidOperationException("Connection string 'AZURE_SQL_CONNECTIONSTRING' not found.")));

    Console.WriteLine("[DebugLog][Program] ISeeGreenContext added, adding StackExchangeRedisCache...");
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = builder.Configuration["AZURE_REDIS_CONNECTIONSTRING"];
        options.InstanceName = "SampleInstance";
    });
    Console.WriteLine("[DebugLog][Program] AddStackExchangeRedisCache completed.");
}

Console.WriteLine("[DebugLog][Program] Adding default identity service...");
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ISeeGreenContext>();

Console.WriteLine("[DebugLog][Program] Adding database developer page exception filter...");
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

Console.WriteLine("[DebugLog][Program] Building the WebApplication object...");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    Console.WriteLine("[DebugLog][Program] Configuring HTTP request pipeline for development environment...");
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    Console.WriteLine("[DebugLog][Program] Configuring HTTP request pipeline for non-development environment...");
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

Console.WriteLine("[DebugLog][Program] Creating service scope...");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    Console.WriteLine("[DebugLog][Program] Getting ISeeGreenContext service...");
    var context = services.GetRequiredService<ISeeGreenContext>();
    Console.WriteLine("[DebugLog][Program] Ensuring database has been created...");
    context.Database.EnsureCreated();
}
Console.WriteLine("[DebugLog][Program] Services have been initialized, continuing WebApplication initialization...");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

Console.WriteLine("[DebugLog][Program] Synchronous initialization completed, starting WebApplication.Run task...");
Task appRun = Task.Run(() => app.Run());

Console.WriteLine("[DebugLog][Program] Starting DbInitializer.Initialize task...");
Task seedTask = Task.Run(() => DbInitializer.InitializeAsync(app));

Console.WriteLine("[DebugLog][Program] Waiting for both DbInitializer.Initialize and WebApplication.Run to complete...");
Task.WaitAll(appRun, seedTask);

Console.WriteLine("[DebugLog][Program] All tasks finished, end of program.");