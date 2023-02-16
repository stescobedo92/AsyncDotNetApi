namespace AsyncProductAPI.Constants;

public class StaticApiEndpointNames
{
    private const string API_VERSION = "v1";
    public const string PRODUCTS = $"api/{API_VERSION}/products";
    public const string PRODUCTS_REQUEST_ID = $@"api/{API_VERSION}/products/{{requestId}}";
    public static string PRODUCTS_RESOURCE_URL = $"api/{API_VERSION}/products/{Guid.NewGuid().ToString()}";
    public const string PRODUCT_STATUS = $"api/{API_VERSION}/productstatus";
    public const string PRODUCT_STATUS_REQUEST_ID = $@"api/{API_VERSION}/productstatus/{{requestId}}";
}