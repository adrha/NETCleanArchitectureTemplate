using CityManager.Application;
using CityManager.Application.Common.Interfaces;
using CityManager.Application.Common.Options;
using CityManager.Infrastructure;

using System.Reflection;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CityManagerOptions>(
    builder.Configuration.GetSection(CityManagerOptions.OptionPosition));

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers()
    .AddApplicationPart(Assembly.GetExecutingAssembly())
    .AddNewtonsoftJson(options => 
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("localhost")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    IApplicationDbContextInitializer contextInitializer =
        scope.ServiceProvider.GetRequiredService<IApplicationDbContextInitializer>();
    
    await contextInitializer.InitializeAsync();
    await contextInitializer.SeedAsync();
}

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health");

app.Run();