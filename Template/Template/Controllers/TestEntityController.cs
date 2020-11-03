using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Template.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestEntityController : ControllerBase
    {

        private readonly ILogger<TestEntityController> _logger;


        public TestEntityController(ILogger<TestEntityController> logger)
        {
            _logger = logger;

        }


        [HttpPost]
        public async Task<IActionResult> Create(Developer developer)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
           
        {
            _logger.LogInformation("SomeLog");
            return Ok();
        }


       
    }

    public class DeveloperValidator : AbstractValidator<Developer>
    {
        public DeveloperValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("FirstName should be not empty.NEVER!!!");
            RuleFor(p => p.LastName).Length(5, 9).WithMessage("Range of last name from 5 to 9 letters ");
        }
    }
}
