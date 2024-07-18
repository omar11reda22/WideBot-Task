using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WideBot.DTOs;
using WideBot.Mycontext;

namespace WideBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        public SecurityController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }


        // registeration 

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto dTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = dTO.UserName,
                    Email = dTO.Email,
                    PasswordHash = dTO.Password
                };
                IdentityResult result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {

                    return Ok("account added success");
                }
                else
                {
                    return BadRequest("sorry something is wrong please try again ..!");
                }
            }
            else
            {
                return BadRequest();
            }

        }






        // Login 

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody]LoginDto dTO)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser result = await userManager.FindByNameAsync(dTO.Username);
                if (result is not null)
                {
                    //check password
                    bool found = await userManager.CheckPasswordAsync(result, dTO.Password);
                    if (found is true)
                    {
                        // create claims 
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, result.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:secret"]));
                        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
                        JwtSecurityToken jwtSecurity = new(
                            issuer: configuration["JWT:issuer"],
                            audience: configuration["JWT:audianse"],
                            expires: DateTime.Now.AddHours(24),
                            claims: claims,
                            signingCredentials: signingCredentials


                            );


                        // create token 
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(jwtSecurity),
                            expiration = jwtSecurity.ValidTo

                        });
                    }
                    else
                    {
                        return NotFound("sorry password is wrong");
                    }
                }
                else
                {
                    return NotFound("sorry user is notfound please register and try again");
                }


            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
