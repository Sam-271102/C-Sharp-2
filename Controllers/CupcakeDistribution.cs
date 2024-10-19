using Microsoft.AspNetCore.Mvc;

namespace Bank_End_Assignment2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CupcakeDistributionController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] int regularBoxes, [FromForm] int smallBoxes)
        {
            if (regularBoxes < 0 || smallBoxes < 0)
            {
                return BadRequest("Number of boxes must be non-negative.");
            }

            int totalCupcakes = (regularBoxes * 8) + (smallBoxes * 3);
            int cupcakesLeftOver = totalCupcakes - 28;

            return Ok(cupcakesLeftOver);
        }
    }
}

