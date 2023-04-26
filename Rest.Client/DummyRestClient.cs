using System.Text.Json;
using Logic;
using Model;
using Rest.Model.Model;

namespace Rest.Client;

public class DummyRestClient
{
    public static async Task<RepairDto[]> GetById(int id)
        {
            await CallWebServiceId(id);
            var jsonResponseContent = await CallWebServiceId(id);
            var repairs = ConvertJson(jsonResponseContent);
            return repairs;
        }
        private static Task<string> CallWebServiceId(int id)
        {
            var repairs = new List<Repair>(RepoReader.ReadRepairs("ListOfRepairs.json")).Where(c => c.Id == id).ToList();
            var httpResponseContent = JsonSerializer.Serialize(repairs);
            return Task.FromResult(httpResponseContent);
        }
        
        //********************************************************

        public static async Task<RepairDto[]> GetByCarId(string carId)
        {
            var webServiceCall = CallWebServiceCarId(carId);
            var jsonResponseContent = await CallWebServiceCarId(carId);
            var repairs = ConvertJson(jsonResponseContent);
            return repairs;
        }
        private static Task<string> CallWebServiceCarId(string carId)
        {
            var repairs = new List<Repair>(RepoReader.ReadRepairs("ListOfRepairs.json")).Where(c => c.CarId == carId).ToList();
            var httpResponseContent = JsonSerializer.Serialize(repairs);
            return Task.FromResult(httpResponseContent);
        }
        
        //********************************************************

        public static async Task<RepairDto[]> GetByClientId(int clientId)
        {
            var webServiceCall = CallWebServiceClientId(clientId);
            var jsonResponseContent = await CallWebServiceClientId(clientId);
            var repairs = ConvertJson(jsonResponseContent);
            return repairs;
        }
        private static Task<string> CallWebServiceClientId(int clientId)
        {
            var repairs = new List<Repair>(RepoReader.ReadRepairs("ListOfRepairs.json")).Where(c => c.ClientId == clientId).ToList();
            var httpResponseContent = JsonSerializer.Serialize(repairs);
            return Task.FromResult(httpResponseContent);
        }
        
        //********************************************************
        
        public static async Task<RepairDto[]> GetByMechanicId(int mechanicId)
        {
            var webServiceCall = CallWebServiceMechanicId(mechanicId);
            var jsonResponseContent = await CallWebServiceMechanicId(mechanicId);
            var repairs = ConvertJson(jsonResponseContent);
            return repairs;
        }
        private static Task<string> CallWebServiceMechanicId(int mechanicId)
        {
            var repairs = new List<Repair>(RepoReader.ReadRepairs("ListOfRepairs.json")).Where(c => c.MechanicId == mechanicId).ToList();
            var httpResponseContent = JsonSerializer.Serialize(repairs);
            return Task.FromResult(httpResponseContent);
        }
        
        //********************************************************

        public static async Task<RepairDto[]> GetRepairs()
        {
            var webServiceCall = CallWebService();
            var jsonResponseContent = await CallWebService();
            var repairs = ConvertJson(jsonResponseContent);
            return repairs;
        }
        private static async Task<string> CallWebService()
        {
            var httpResponseContent = await File.ReadAllTextAsync("ListOfRepairs.json");
            return httpResponseContent;
        }



        private static RepairDto[] ConvertJson(string json)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
                 {
                     PropertyNameCaseInsensitive = true
                 };

            var repairs = JsonSerializer.Deserialize<RepairDto[]>(json, jsonSerializerOptions);

            return repairs;
        }
}