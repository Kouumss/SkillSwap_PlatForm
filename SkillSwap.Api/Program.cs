using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SkillSwap.Api.Common.Errors;
using SkillSwap.Application;
using SkillSwap.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);


    builder.Services.AddControllers();

    //Add DefaultProblemDetailsFactory custom => SkillSwapPlatformProblemDetailsFactory
    builder.Services.AddSingleton<ProblemDetailsFactory, SkillSwapPlatformProblemDetailsFactory>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //To route the request to the endpoint
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


