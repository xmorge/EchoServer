var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/{*requestPath}", (HttpRequest request) =>
{
    app.Logger.LogInformation($"received request for {request.Path}");
    return new
    {
        method = request.Method,
        host = request.Headers.Host,
        headers = request.Headers,
        path = request.Path,
        query = request.Query,
    };
});

app.Run();
