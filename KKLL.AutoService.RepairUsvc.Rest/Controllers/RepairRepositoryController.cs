using KKLL.AutoService.RepairUsvc.RepairLogic;
using KKLL.AutoService.RepairUsvc.RepairModel;
using KKLL.AutoService.RepairUsvc.Rest.Model.Converters;
using KKLL.AutoService.RepairUsvc.Rest.Model.Model;
using KKLL.AutoService.RepairUsvc.Rest.Model.Services;
using KKLL.AutoService.RepairUsvc.Tests;

namespace KKLL.AutoService.RepairUsvc.Rest.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Logging;
  using RepairModel.Services;

  [ApiController]
  [Route("[controller]")]
  public class RepairRepositoryController : ControllerBase, IRestRepair, ITestsService
  {
    private readonly ILogger<RepairRepositoryController> _logger;
    private readonly IRepairRepository _repairRepository;

    public RepairRepositoryController(ILogger<RepairRepositoryController> logger)
    {
      _logger = logger;
      _repairRepository = new RepairRepository();
    }



    [HttpGet]
    [Route("GetById")]
    public RepairDto[] GetDtoById(int id)
    {
      var repairs = _repairRepository.FindById(id);
      return repairs.Select(repair => repair.ConvertToRepairDto()).ToArray();
    }
    
    [HttpGet]
    [Route("GetByCarId")]
    public RepairDto[] GetDtoByCarId(string carId)
    {
      var repairs = _repairRepository.FindByCarId(carId);
      return repairs.Select(repair => repair.ConvertToRepairDto()).ToArray();
    }
    
    [HttpGet]
    [Route("GetByClientId")]
    public RepairDto[] GetDtoByClientId(int clientId)
    {
      var repairs = _repairRepository.FindByClientId(clientId);
      return repairs.Select(repair => repair.ConvertToRepairDto()).ToArray();
    }
    
    [HttpGet]
    [Route("GetByMechanicId")]
    public RepairDto[] GetDtoByMechanicId(int mechanicId)
    {
      var repairs = _repairRepository.FindByMechanicId(mechanicId);
      return repairs.Select(repair => repair.ConvertToRepairDto()).ToArray();
    }

    [HttpGet]
    [Route("GetRepairs")]
    public RepairDto[] GetDtoRepairs()
    {
      var repairs = _repairRepository.GetRepairs();

      return repairs.Select(repair => repair.ConvertToRepairDto()).ToArray();
    }

    [HttpGet]
    [Route("RunTests")]
    public string RunTests(string host, int port)
    {
      ITestsService tests = new Tests.Tests();
      return tests.RunTests(host, port);
    }

    
    [HttpPost]
    [Route("AddNewRepair")]
    public void AddNewDtoRepair(Repair newRepair)
    {
      _repairRepository.AddNewRepair(newRepair);
    }

    [HttpPost]
    [Route("DeleteById")]
    public void DeleteDtoById(int id)
    {
      _repairRepository.DeleteById(id);
    }

  }
}
