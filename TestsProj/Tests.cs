using System.Diagnostics;
using System.Text.Json;
using Logic;
using Model;
using Model.Services;
using Rest.Model.Model;
using Rest.Model.Services;

namespace TestsProj;

public class Tests : ITestsService
{
    private static readonly HttpClient HttpClient = new();

    public string RunTests(string host, int port)
    {
        Debug.Assert(condition: port > 0);

        try
        {
            var searchText = "xxx";
            
            IRepo repo = new Repo();
            
            var repairs1 = repo.GetRepairs();

            var repairs2 = GetRepairs(host, (ushort)port, searchText);

            Debug.Assert(condition: repairs2.Length == repairs1.Length);
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return "No errors";
        }
    
    private RepairDto[] GetRepairs(string webServiceHost, ushort webServicePort, string searchText)
    {
        var webServiceUri =
            $"https://{webServiceHost}:{webServicePort}/Repo/GetRepairs?searchText={searchText}";

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

    private RepairDto[] ConvertJson(string json)
    {
        var repairs = JsonSerializer.Deserialize<RepairDto[]>(json);

        return repairs;
    }
}