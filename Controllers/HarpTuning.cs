using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Bank_End_Assignment2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HarpTuningController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] string instructions)
        {
            var output = new List<string>();
            var pattern = @"([A-Z]+)([+-]\d+)";
            var matches = Regex.Matches(instructions, pattern);

            foreach (Match match in matches)
            {
                string strings = match.Groups[1].Value;
                string action = match.Groups[2].Value;
                string direction = action.StartsWith("+") ? "tighten" : "loosen";
                int turns = int.Parse(action.Substring(1));

                output.Add($"{strings} {direction} {turns}");
            }

            return Ok(output);
        }
    }
}


