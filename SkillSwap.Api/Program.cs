using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SkillSwap.Api.Errors;
using SkillSwap.Api.Filters;
using SkillSwap.Application;
using SkillSwap.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);

    // Add ExceptionFilter
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
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

    // DESCRIPTION : Add Middleware

    // app.UseMiddleware<ErrorHandlingMiddleware>();

    // DESCRIPTION : Exception Manager (UseExceptionHandler)

    // 1. Add a middleware that will intercept the exception log,
    // 2. then it resets the request path,
    // 3. re-executes it on that path.

    app.UseExceptionHandler("/error");

    // DESCRIPTION : To manage Exception without DefaultProblemDetailsFactory 
    // with a custom extension dictionnary to which we can add our custom properties
    // which will be added to the final response along with the details of the problem.

    // app.Map("/error", (HttpContext httpcontext) =>
    // {
    //     Exception? exception = httpcontext.Features.Get<IExceptionHandlerFeature>()?.Error;

    //     return Results.Problem();
    // });
    //

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


