using Microsoft.AspNetCore.Mvc;

namespace Bank_End_Assignment2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FergusonballController : ControllerBase
    {
        public class FergusonballRequest
        {
            public int Points { get; set; }
            public int Fouls { get; set; }
        }

        [HttpPost]
        public IActionResult Post([FromForm] FergusonballRequest request)
        {
            if (request.Points < 0 || request.Fouls < 0)
            {
                return BadRequest("Points and fouls must be non-negative.");
            }

            int stars = request.Points * 5 - request.Fouls * 2; 
            return Ok(stars);
        }

        [HttpGet("goldteam")]
        public IActionResult GetGoldTeamCount([FromQuery] FergusonballRequest[] players)
        {
            int count = 0;
            bool isGoldTeam = true;

            foreach (var player in players)
            {
                if (player.Points <= player.Fouls)
                {
                    isGoldTeam = false;
                }
                else
                {
                    count++;
                }
            }

            return Ok(new { PlayerCount = count, IsGoldTeam = isGoldTeam });
        }
    }
}

