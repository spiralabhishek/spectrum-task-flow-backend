using SocketDemoProject.Data;
using SocketDemoProject.GraphQL;
using Microsoft.EntityFrameworkCore;
using HotChocolate.AspNetCore; 
using HotChocolate.Subscriptions;
//using HotChocolate.AspNetCore.Voyager; 

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Add the origin of your React app. 
                          // If your React app runs on a different port, change it here.
                          policy.WithOrigins("http://localhost:8080")
                                .AllowAnyHeader()  // Allows all headers (like 'Content-Type')
                                .AllowAnyMethod(); // Allows all methods (GET, POST, etc.)
                      });
});


// Configure DbContext with in-memory database
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options.UseInMemoryDatabase("TaskDb"));

// Add GraphQL services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions() // <-- CORRECT POSITION
    .AddType<TaskType>();

var app = builder.Build();

// Ensure the database is created and seeded for in-memory
using (var scope = app.Services.CreateScope())
{
    var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var context = contextFactory.CreateDbContext();
    context.Database.EnsureCreated();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseWebSockets(); 

app.MapGraphQL();

app.Run();