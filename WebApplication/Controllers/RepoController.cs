using Logic;
using Model;
using Rest.Model.Converters;
using Rest.Model.Model;
using Rest.Model.Services;

namespace WebApplication.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Logging;
    using Model.Services;

    [ApiController]
  [Route( "[controller]" )]
  public class RepoController : ControllerBase, IRestRepair
  {
    private readonly ILogger<RepoController> _logger;
    private readonly IRepo _repo;

    public RepoController( ILogger<RepoController> logger )
    {
      _logger = logger;
      _repo = new Repo( );
    }


    
    [HttpGet]
    [Route("GetById")]
    public RepairDto[] GetDtoById(int id)
    {
      var repairs = _repo.FindById(id);
      return repairs.Select(repair => repair.ConvertToRepairDto()).ToArray();
    }

    [HttpGet]
    [Route( "GetRepairs" )]
    public RepairDto[ ] GetDtoRepairs()
    {
      var repairs = _repo.GetRepairs();

      return repairs.Select(repair => repair.ConvertToRepairDto()).ToArray();
    }
  }
}
