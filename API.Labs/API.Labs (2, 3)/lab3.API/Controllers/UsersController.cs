using lab3.BL;
using lab3.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lab3.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IHelpers _helpers;
    private readonly UserManager<Person> _userManager;
    public UsersController(IHelpers helpers, UserManager<Person> userManager)
    {
        _helpers = helpers;
        _userManager = userManager;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenDto>> Login(LoginDto credentials) 
    {
        Person? person = await _userManager.FindByNameAsync(credentials.UserName);
        if (person is null) 
        { 
            return BadRequest();
        }

        bool passwordCheck = await _userManager.CheckPasswordAsync(person, credentials.Password);
        if (!passwordCheck)
        {
            return Unauthorized();
        }

        var claims = await _userManager.GetClaimsAsync(person);
        string token = _helpers.GenerateToken(claims);
        
        return new TokenDto(token);
    }
    [HttpPost]
    [Route("admin-register")]
    public async Task<IActionResult> AdminRegister(RegisterDto newAdmin)
    {
        Person person = new Person { UserName= newAdmin.UserName, Email = newAdmin.Email, Dependants = 0 };

        var hashingPasswordResult = await _userManager.CreateAsync(person, newAdmin.Password);
        if(!hashingPasswordResult.Succeeded)
        {
            return BadRequest(hashingPasswordResult.Errors);
        }

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, person.Id),
            new Claim(ClaimTypes.Role, "Admin")
        };
        return CreatedAtAction(actionName:nameof(GetCurrentUserInfo),
                               value: new {Message="Admin Registered Successfully"});
    }
    [HttpPost]
    [Route("user-register")]
    public async Task<IActionResult> UserRegister(RegisterDto newUser)
    {
        Person person = new Person { UserName = newUser.UserName, Email = newUser.Email, Dependants = 0 };

        var hashingPasswordResult = await _userManager.CreateAsync(person, newUser.Password);
        if (!hashingPasswordResult.Succeeded)
        {
            return BadRequest(hashingPasswordResult.Errors);
        }

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, person.Id),
            new Claim(ClaimTypes.Role, "User")
        };
        return CreatedAtAction(actionName: nameof(GetCurrentUserInfo),
                               value: new { Message = "User Registered Successfully" });
    }
    [HttpGet]
    [Authorize]
    [Route("current-user-info")]
    public async Task<ActionResult<PersonReadVM>> GetCurrentUserInfo()
    {
        Person? currentUser = await _userManager.GetUserAsync(User);
        if (currentUser is null)
        {
            return NotFound();
        }

        return new PersonReadVM(currentUser.UserName ?? "", currentUser.Email ?? "", currentUser.Dependants);
    }
    [HttpGet]
    [Route("user-info/{id}")]
    [Authorize(Policy = "AllowUsers&Admins")]
    public async Task<ActionResult<PersonReadVM>> GetUserInfo(int id) 
    {
        Person? user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
        {
            return NotFound();
        }

        return new PersonReadVM (user.UserName ?? "", user.Email ?? "", user.Dependants);
    }
    [HttpGet]
    [Route("manager-info/{id}")]
    [Authorize(Policy = "AllowAdminsOnly")]
    public async Task<ActionResult<PersonReadVM>> GetManagerInfo(int id)
    {
        Person? manager = await _userManager.FindByIdAsync(id.ToString());
        if (manager is null)
        {
            return NotFound();
        }

        return new PersonReadVM(manager.UserName ?? "", manager.Email ?? "", manager.Dependants);
    }
}
