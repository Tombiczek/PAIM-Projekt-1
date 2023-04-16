using Rest.Client;
using Rest.Model.Model;

namespace ConsoleApp;


public class Program
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static void Main_(string[] args)
        {
            try
            {
                const string webServiceHost = "localhost"; //args[0];
                const ushort webServicePort = 7049; //ushort.Parse(args[1]);
                const string id = "2"; //id example
                const string carId = "WW9477W"; //carId example
                const string mechanicId = "2"; //mechanicId example
                const string clientId = "1"; //clientId example
                const string name = "Cleaning"; //name example
                const string description = "cool"; //description example

                
                
                var getById = RestClient.GetById(webServiceHost, webServicePort, id);
                getById.Wait();
                var repairs1 = getById.Result;
                Console.WriteLine("'GetById' results for " + id + ":");
                foreach (var repair in repairs1)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");

                var getByCarId = RestClient.GetByCarId(webServiceHost, webServicePort, carId);
                getByCarId.Wait();
                var repairs2 = getByCarId.Result;
                Console.WriteLine("'GetByCarId' results for " + carId + ":");
                foreach (var repair in repairs2)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");

                var getByClientId = RestClient.GetByClientId(webServiceHost, webServicePort, clientId);
                getByClientId.Wait();
                var repairs3 = getByClientId.Result;
                Console.WriteLine("'getByClientId' results for " + clientId + ":");
                foreach (var repair in repairs3)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");
                
                var getByMechanicId = RestClient.GetByMechanicId(webServiceHost, webServicePort, mechanicId);
                getByClientId.Wait();
                var repairs4 = getByMechanicId.Result;
                Console.WriteLine("'GetByMechanicId' results for " + mechanicId + ":");
                foreach (var repair in repairs4)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");

                var getRepairs = RestClient.GetRepairs(webServiceHost, webServicePort);
                getRepairs.Wait();
                var repairs5 = getRepairs.Result;
                Console.WriteLine("'GetRepairs' results:");
                foreach (var repair in repairs5)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Program completed.");
            }
        }

    }