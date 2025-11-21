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

    // GET /api/valera → список всех Валер
    [HttpGet]
    public ActionResult<List<ValeraStateDto>> GetAll()
    {
        return Ok(_service.GetAllValeras());
    }

    // POST /api/valera → создать нового Валеру
    [HttpPost]
    public ActionResult<ValeraStateDto> Create([FromBody] CreateValeraDto dto)
    {
        var result = _service.CreateValera(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    // GET /api/valera/{id} → получить по ID
    [HttpGet("{id}")]
    public ActionResult<ValeraStateDto> GetById(int id)
    {
        var result = _service.GetById(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    // POST /api/valera/{id}/work
    [HttpPost("{id}/work")]
    public ActionResult<ValeraStateDto> GoToWork(int id)
    {
        var result = _service.GoToWork(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("{id}/nature")]
    public ActionResult<ValeraStateDto> ContemplateNature(int id)
    {
        var result = _service.ContemplateNature(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("{id}/wine")]
    public ActionResult<ValeraStateDto> DrinkWineAndWatchSeries(int id)
    {
        var result = _service.DrinkWineAndWatchSeries(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("{id}/bar")]
    public ActionResult<ValeraStateDto> GoToBar(int id)
    {
        var result = _service.GoToBar(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("{id}/marginals")]
    public ActionResult<ValeraStateDto> DrinkWithMarginals(int id)
    {
        var result = _service.DrinkWithMarginals(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("{id}/subway")]
    public ActionResult<ValeraStateDto> SingInSubway(int id)
    {
        var result = _service.SingInSubway(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("{id}/sleep")]
    public ActionResult<ValeraStateDto> Sleep(int id)
    {
        var result = _service.Sleep(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}