using AsyncProductAPI.Data;
using AsyncProductAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=RequestDB.db"));

var app = builder.Build();

app.UseHttpsRedirection();

//Start Endpoint
app.MapPost("api/v1/products", async (AppDbContext context, ListingRequest listingRequest) => {
    if(listingRequest is null)
        return Results.BadRequest();

    listingRequest.RequestStatus = "ACCEPT";
    listingRequest.EstimatedCompetionTime = "2023-02-16:10:53:00";

    await context.ListingRequests.AddRangeAsync(listingRequest);
    await context.SaveChangesAsync();

    return Results.Accepted($"api/v1/producstatus/{}");
});

app.Run();