// Controllers/ValeraController.cs
using Microsoft.AspNetCore.Mvc;
using ValeraApi.Models;
using ValeraApi.Services;

namespace ValeraApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValeraController : ControllerBase
{
    private readonly ValeraService _service;

    public ValeraController(ValeraService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<Valera> GetState()
    {
        var valera = _service.GetValera();
        return Ok(valera);
    }

    [HttpPost("work")]
    public ActionResult<Valera> GoToWork()
    {
        _service.GoToWork();
        return Ok(_service.GetValera());
    }

    [HttpPost("nature")]
    public ActionResult<Valera> ContemplateNature()
    {
        _service.ContemplateNature();
        return Ok(_service.GetValera());
    }

    [HttpPost("wine")]
    public ActionResult<Valera> DrinkWineAndWatchSeries()
    {
        _service.DrinkWineAndWatchSeries();
        return Ok(_service.GetValera());
    }

    [HttpPost("bar")]
    public ActionResult<Valera> GoToBar()
    {
        _service.GoToBar();
        return Ok(_service.GetValera());
    }

    [HttpPost("marginals")]
    public ActionResult<Valera> DrinkWithMarginals()
    {
        _service.DrinkWithMarginals();
        return Ok(_service.GetValera());
    }

    [HttpPost("subway")]
    public ActionResult<Valera> SingInSubway()
    {
        _service.SingInSubway();
        return Ok(_service.GetValera());
    }

    [HttpPost("sleep")]
    public ActionResult<Valera> Sleep()
    {
        _service.Sleep();
        return Ok(_service.GetValera());
    }
}