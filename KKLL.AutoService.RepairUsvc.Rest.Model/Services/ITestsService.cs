namespace KKLL.AutoService.RepairUsvc.Rest.Model.Services;

public interface ITestsService
{
    public string RunTests(string host, int port);
}