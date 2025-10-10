using Microsoft.AspNetCore.Mvc;

namespace Valera.Api.Controllers
{
    [ApiController]
    [Route("api/valera")]
    public class ValeraController : ControllerBase
    {
        private readonly Valera.Api.Models.Valera _valera;
        public ValeraController(Valera.Api.Models.Valera valera) { _valera = valera; }

        [HttpGet("status")]
        public IActionResult Status() => Ok(_valera);

        [HttpPost("action/gotowork")]
        public IActionResult GoToWork()
        {
            var ok = _valera.GoToWork();
            if (!ok) return BadRequest(new { error = "Cannot go to work: alcohol>=50 or fatigue>=10\n" });
            return Ok(_valera);
        }

        [HttpPost("action/contemplate")]
        public IActionResult Contemplate()
        {
            _valera.ContemplateNature();
            return Ok(_valera);
        }

        [HttpPost("action/drinktv")]
        public IActionResult DrinkTv()
        {
            _valera.DrinkWineAndWatchTV();
            return Ok(_valera);
        }

        [HttpPost("action/gotobar")]
        public IActionResult GoToBar()
        {
            _valera.GoToBar();
            return Ok(_valera);
        }

        [HttpPost("action/marginals")]
        public IActionResult Marginals()
        {
            _valera.DrinkWithMarginals();
            return Ok(_valera);
        }

        [HttpPost("action/sing")]
        public IActionResult Sing()
        {
            _valera.SingInMetro();
            return Ok(_valera);
        }

        [HttpPost("action/sleep")]
        public IActionResult Sleep()
        {
            _valera.Sleep();
            return Ok(_valera);
        }
    }
}