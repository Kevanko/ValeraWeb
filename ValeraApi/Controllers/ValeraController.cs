// Controllers/ValeraController.cs
using Microsoft.AspNetCore.Mvc;
using ValeraApi.DTOs;
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
    public ActionResult<ValeraStateDto> GetState()
    {
        return Ok(_service.GetState());
    }

    [HttpPost("work")]
    public ActionResult<ValeraStateDto> GoToWork()
    {
        return Ok(_service.GoToWork());
    }

    [HttpPost("nature")]
    public ActionResult<ValeraStateDto> ContemplateNature()
    {
        return Ok(_service.ContemplateNature());
    }

    [HttpPost("wine")]
    public ActionResult<ValeraStateDto> DrinkWineAndWatchSeries()
    {
        return Ok(_service.DrinkWineAndWatchSeries());
    }

    [HttpPost("bar")]
    public ActionResult<ValeraStateDto> GoToBar()
    {
        return Ok(_service.GoToBar());
    }

    [HttpPost("marginals")]
    public ActionResult<ValeraStateDto> DrinkWithMarginals()
    {
        return Ok(_service.DrinkWithMarginals());
    }

    [HttpPost("subway")]
    public ActionResult<ValeraStateDto> SingInSubway()
    {
        return Ok(_service.SingInSubway());
    }

    [HttpPost("sleep")]
    public ActionResult<ValeraStateDto> Sleep()
    {
        return Ok(_service.Sleep());
    }
}