using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bank_End_Assignment2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChiliPeppersController : ControllerBase
    {
        private readonly Dictionary<string, int> pepperShu = new()
        {
            { "Poblano", 1500 },
            { "Mirasol", 6000 },
            { "Serrano", 15500 },
            { "Cayenne", 40000 },
            { "Thai", 75000 },
            { "Habanero", 125000 }
        };

        [HttpGet]
        public IActionResult Get([FromQuery] string ingredients)
        {
            var ingredientList = ingredients.Split(',').ToList();
            int totalSpiciness = ingredientList.Sum(pepper => pepperShu.ContainsKey(pepper) ? pepperShu[pepper] : 0);
            return Ok(totalSpiciness);
        }
    }
}
