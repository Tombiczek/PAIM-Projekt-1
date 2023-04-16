using Rest.Client;
using Rest.Model.Model;

namespace ConsoleApp;

public class DummyProgram
{
    public static void Main(string[] args)
        {
            try
            {
                const int id = 2; //id example
                const string carId = "WW9477W"; //carId example
                const int mechanicId = 2; //mechanicId example
                const int clientId = 1; //clientId example
                const string name = "Cleaning"; //name example
                const string description = "cool"; //description example

                var getById = DummyRestClient.GetById(id);
                getById.Wait();
                var repairs1 = getById.Result;
                Console.WriteLine("'GetById' results for " + id + ":");
                foreach (var repair in repairs1)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");

                var getByCarId = DummyRestClient.GetByCarId(carId);
                getByCarId.Wait();
                var repairs2 = getByCarId.Result;
                Console.WriteLine("'GetByCarId' results for " + carId + ":");
                foreach (var repair in repairs2)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");

                var getByClientId = DummyRestClient.GetByClientId(clientId);
                getByClientId.Wait();
                var repairs3 = getByClientId.Result;
                Console.WriteLine("'getByClientId' results for " + clientId + ":");
                foreach (var repair in repairs3)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");
                
                var getByMechanicId = DummyRestClient.GetByMechanicId(mechanicId);
                getByClientId.Wait();
                var repairs4 = getByMechanicId.Result;
                Console.WriteLine("'GetByMechanicId' results for " + mechanicId + ":");
                foreach (var repair in repairs4)
                    Console.WriteLine(repair.Name);
                Console.WriteLine("\n");

                var getRepairs = DummyRestClient.GetRepairs();
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