using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Google.Protobuf.Reflection;
using HealthBuddyApp.Context;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyApp.Controllers
{
   [Route("[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private IConfiguration _configuration;
        private AppDBContext context;

        public SignInController(AppDBContext context,IConfiguration configuration)
        {
            _configuration = configuration;
            this.context = context;
            
        }

        [HttpPost("authenticate")]
        public IActionResult Login([FromBody] LoginReqDto login)
        {
            var user = Authenticate(login);
            if (user != null)
            {
                var token = Generate(user);

                

                if ("ROLE_PATIENT" == user.Role.ToString())
                {
                    var currentUser = context.Patients.Include(p => p.User).FirstOrDefault(p => p.User.Id == user.Id);


                //return Ok(token);
                    return Ok(new
                    {
                        data = new
                        {
                            jwt = token,
                            id = currentUser.Id
                        }
                    });
                }else if("ROLE_DOCTOR" == user.Role.ToString())
                {
                    var currentUser = context.Doctors.Include(p => p.User).FirstOrDefault(p => p.User.Id == user.Id);


                    //return Ok(token);
                    return Ok(new
                    {
                        data = new
                        {
                            jwt = token,
                            id = currentUser.Id
                        }
                    });
                }
            }
            return NotFound("User Not found");
        }

        private string Generate(User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:JWTSecret"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
          
            };

            var token = new JwtSecurityToken(
                    _configuration["AppSettings:Issuer"],
                    _configuration["AppSettings:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);



        }

        private User  Authenticate(LoginReqDto login) 
        {
                var currentUser = context.Users.FirstOrDefault(u => u.UserName.ToLower() == login.UserName.ToLower() && u.Password == login.Password);

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }


    }
}
