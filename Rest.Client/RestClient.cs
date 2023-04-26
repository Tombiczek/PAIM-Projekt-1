using System.Text.Json;
using Rest.Model.Model;

namespace Rest.Client;

public class RestClient
{
    private static readonly HttpClient HttpClient = new();
    
    
    public static async Task<RepairDto[]?> GetById(string webServiceHost, ushort webServicePort, string id)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/Repo/GetById?id={id}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    public static async Task<RepairDto[]?> GetByCarId(string webServiceHost, ushort webServicePort, string carId)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/Repo/GetByCarId?carId={carId}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    public static async Task<RepairDto[]?> GetByClientId(string webServiceHost, ushort webServicePort, string clientId)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/Repo/GetByClientId?clientId={clientId}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    public static async Task<RepairDto[]?> GetByMechanicId(string webServiceHost, ushort webServicePort, string mechanicId)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/Repo/GetByMechanicId?mechanicId={mechanicId}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    public static async Task<RepairDto[]?> GetRepairs(string webServiceHost, ushort webServicePort)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/Repo/GetRepairs";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    private static async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
    {
        var httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

        HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

        httpResponseMessage.EnsureSuccessStatusCode();

        var httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

        return httpResponseContent;
    }

    private static RepairDto[]? ConvertJson(string json)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var repairs = JsonSerializer.Deserialize<RepairDto[]>(json, jsonSerializerOptions);

        return repairs;
    }
}