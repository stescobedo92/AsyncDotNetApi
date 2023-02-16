using AsyncProductAPI.Data;
using AsyncProductAPI.Dtos;
using AsyncProductAPI.Models;
using AsyncProductAPI.Constants;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=RequestDB.db"));

var app = builder.Build();

app.UseHttpsRedirection();

//Start Endpoint
app.MapPost(StaticApiEndpointNames.PRODUCTS, async (AppDbContext context, ListingRequest listingRequest) => {
    if(listingRequest is null)
        return Results.BadRequest();

    listingRequest.RequestStatus = Enum.GetName(typeof(RequestStatusType), 1);
    listingRequest.EstimatedCompetionTime = StaticNames.ESTIMATED_COMPETION_TIME_ORIGINAL;

    await context.ListingRequests.AddRangeAsync(listingRequest);
    await context.SaveChangesAsync();

    return Results.Accepted($"{StaticApiEndpointNames.PRODUCT_STATUS}/{listingRequest.RequestId}", listingRequest);
});

//Status endpoint
app.MapGet(StaticApiEndpointNames.PRODUCT_STATUS_REQUEST_ID, (AppDbContext context, string requestId) => {
    var listingRequest = context.ListingRequests.FirstOrDefault(listing => listing.RequestId == requestId);

    if( listingRequest is null) 
        return Results.NotFound();

    ListingStatus listingStatus = new ListingStatus {
        RequestStatus = listingRequest.RequestStatus,
        ResourceURL = String.Empty
    };

    if(listingRequest.RequestStatus!.ToUpper() == Enum.GetName(typeof(RequestStatusType), 2))
    {
        listingStatus.ResourceURL = StaticApiEndpointNames.PRODUCTS_RESOURCE_URL;
        return Results.Ok(listingStatus);
    }

    listingStatus.EstimatedCompetionTime = StaticNames.ESTIMATED_COMPETION_TIME_MODIFIED;
    return Results.Ok(listingStatus);
});

//Final endpoint
app.MapGet(StaticApiEndpointNames.PRODUCTS_REQUEST_ID, (string requestId) => {
    return Results.Ok(StaticNames.MESSAGE);
});

app.Run();