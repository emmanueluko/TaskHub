using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskHub.TaskHub.Model;
using TaskHub.TaskHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.TaskHub.Controller
{
    public class AuthenticationController:ControllerBase {

		private readonly UserManager<ApplicationUser> _userManager;
		private readonly TokenService _tokenService;

		// Constructor Injection
		public AuthenticationController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto model)
		{
			var user = new IdentityUser { UserName = model.Email, Email = model.Email };
			var result = await _userManager.CreateAsync((ApplicationUser)user, model.Password);

			if (!result.Succeeded) 
				return BadRequest(result.Errors);

				return Ok(new { message = "User registered successfully" });
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
				return Unauthorized(new { message = "Invalid credentials" });

				var token = _tokenService.GenerateToken(user);
				return Ok(new { token });
		}
	}

}
