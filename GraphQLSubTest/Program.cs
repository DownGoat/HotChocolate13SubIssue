using GraphQLSubTest;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    ;


var app = builder.Build();

app.UseHttpsRedirection();
app.UseWebSockets();
app.MapControllers();
app.MapGraphQL();

app.Run();