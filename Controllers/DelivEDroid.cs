using Microsoft.AspNetCore.Mvc;

namespace Bank_End_Assignment2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DelivedroidController : ControllerBase
    {
        public class DelivedroidRequest
        {
            public int Collisions { get; set; }
            public int Deliveries { get; set; }
        }

        [HttpPost]
        public IActionResult Post([FromForm] DelivedroidRequest request)
        {
            if (request.Collisions < 0 || request.Deliveries < 0)
            {
                return BadRequest("Collisions and deliveries must be non-negative.");
            }

            int score = request.Deliveries * 50 - request.Collisions * 10;
            if (request.Deliveries > request.Collisions)
            {
                score += 500;
            }

            return Ok(score);
        }
    }
}


