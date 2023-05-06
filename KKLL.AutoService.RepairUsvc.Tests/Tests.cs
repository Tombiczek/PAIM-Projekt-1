using System.Diagnostics;
using System.Text.Json;
using KKLL.AutoService.RepairUsvc.RepairLogic;
using KKLL.AutoService.RepairUsvc.RepairModel;
using KKLL.AutoService.RepairUsvc.RepairModel.Services;
using KKLL.AutoService.RepairUsvc.Rest.Model.Model;
using KKLL.AutoService.RepairUsvc.Rest.Model.Services;

namespace KKLL.AutoService.RepairUsvc.Tests;

public class Tests : ITestsService
{
    private static readonly HttpClient HttpClient = new();

    public string RunTests(string host, int port)
    {
        Debug.Assert(condition: port > 0);

        try
        {
            const string searchText = "xxx";
            
            IRepairRepository repairRepository = new RepairRepository();
            
            var repairs1 = repairRepository.GetRepairs();

            var repairs2 = GetRepairs(host, (ushort)port, searchText);

            Debug.Assert(condition: repairs2.Length == repairs1.Length);
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return "No errors";
        }
    
    private RepairDto[]? GetRepairs(string webServiceHost, ushort webServicePort, string searchText)
    {
        var webServiceUri =
            $"https://{webServiceHost}:{webServicePort}/RepairRepository/GetRepairs?searchText={searchText}";

        var webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        webServiceCall.Wait();

        var jsonResponseContent = webServiceCall.Result;

        var repairs = ConvertJson(jsonResponseContent);

        return repairs;
    }
    
    private async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
    {
        var httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

        HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

        httpResponseMessage.EnsureSuccessStatusCode();

        var httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

        return httpResponseContent;
    }

    private RepairDto[]? ConvertJson(string json)
    {
        var repairs = JsonSerializer.Deserialize<RepairDto[]>(json);

        return repairs;
    }
}