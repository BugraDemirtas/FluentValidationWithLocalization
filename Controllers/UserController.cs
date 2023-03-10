using FluentValidation;
using FluentValidationWithLocalization.Model;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using FluentValidationWithLocalization.Extensions;

namespace FluentValidationWithLocalization.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{

		private readonly ILogger<UserController> _logger;

		private readonly IValidator<User> _validator;


		public UserController(ILogger<UserController> logger, IValidator<User> validator)
		{
			_logger = logger;

			_validator = validator;
		}




		[HttpPost(Name = "AddUser")]
		public async Task<IActionResult> Add([FromBody] User user)
		{
			ValidationResult result = await _validator.ValidateAsync(user);

			if (!result.IsValid)
			{
				
				return BadRequest(result.Errors);

			}

			return Accepted("Ok");
		}


	}
}
