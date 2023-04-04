using InterviewAPI.Models;
using InterviewAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly ICharacters _characters;
        private readonly IPlanets _planets;

        public InterviewController(ICharacters characters, IPlanets planets)
        {
            _characters = characters;
            _planets = planets;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string choice)
        {
            StringBuilder names = new StringBuilder();

            if (choice == "character")
            {
                var response = await _characters.GetChracter();

                if (response != null)
                {
                    response.
                        Select(x => x.name).
                        ToList().
                        ForEach(x => names.AppendLine(x));
                }
            }
            else
            {
                var response = await _planets.GetPlanets();

                if (response != null)
                {
                    response.Select(x => x.name).
                        ToList().
                        ForEach(x => names.AppendLine(x));
                }

                
            }

            return Ok(names.ToString());
;        }
    }
}
