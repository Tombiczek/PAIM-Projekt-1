using System.Text;
using System.Text.Json;
using KKLL.AutoService.RepairUsvc.Rest.Model.Model;

namespace KKLL.AutoService.RepairUsvc.Rest.Client;

public class RestClient
{
    private static readonly HttpClient HttpClient = new();
    
    
    public static async Task<RepairDto[]?> GetById(string webServiceHost, ushort webServicePort, string id)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/RepairRepository/GetById?id={id}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    public static async Task<RepairDto[]?> GetByCarId(string webServiceHost, ushort webServicePort, string carId)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/RepairRepository/GetByCarId?carId={carId}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    public static async Task<RepairDto[]?> GetByClientId(string webServiceHost, ushort webServicePort, string clientId)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/RepairRepository/GetByClientId?clientId={clientId}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    public static async Task<RepairDto[]?> GetByMechanicId(string webServiceHost, ushort webServicePort, string mechanicId)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/RepairRepository/GetByMechanicId?mechanicId={mechanicId}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    public static async Task<RepairDto[]?> GetRepairs(string webServiceHost, ushort webServicePort)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/RepairRepository/GetRepairs";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        var jsonResponseContent = await CallWebService(HttpMethod.Get, webServiceUri);

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }

    public static async Task AddNewRepair(string webServiceHost, ushort webServicePort, int id, string plate,
        int clientId, int mechanicId, string name, string description, int price)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/RepairRepository/AddNewRepair";

        using StringContent jsonContent = new(JsonSerializer.Serialize(new
        {
            id = id,
            plate = plate,
            clientId = clientId,
            mechanicId = mechanicId,
            name = name,
            description = description,
            price = price
        }), Encoding.UTF8, "application/json");

        var result = await HttpClient.PostAsync(webServiceUri, jsonContent);
        var resultContent = await result.Content.ReadAsStringAsync();
    }

    public static async Task DeleteById(string webServiceHost, ushort webServicePort, string id)
    {
        var webServiceUri = $"https://{webServiceHost}:{webServicePort}/RepairRepository/DeleteById?id={id}";
        var webServiceCall = CallWebService(HttpMethod.Delete, webServiceUri);
        var jsonResponseContent = await CallWebService(HttpMethod.Delete, webServiceUri);
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