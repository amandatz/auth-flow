using AuthFlow.Api;
using AuthFlow.Application;
using AuthFlow.Infrastructure;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
{
    ValidatorOptions.Global.LanguageManager.Enabled = false;

    builder.Services
        .AddApi()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
