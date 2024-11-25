using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemoteMultiSiteMobileBasedExpenseManager.SqlServer;

using RemoteMultiSiteMobileBasedExpenseManager.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using RemoteMultiSiteMobileBasedExpenseManager.Repositories;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace RemoteMultiSiteMobileBasedExpenseManager.Controllers
{
    [Route("api/Users")]
    [ApiController]
    //[EnableCors]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public readonly IConfiguration _Iconfig;
        public UsersController(IUserRepository userRepository, IConfiguration Configuration)
        {
            _userRepository = userRepository;
            _Iconfig = Configuration;
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Users objUser)
        {
            try
            {
                var login = _userRepository.LoginUser(objUser);
                if (login == null)
                    return NotFound("Invalid User...");
                else
                {
                    string JwtToken = GenerateToken(login);
                    return Ok(new { token = JwtToken });
                }

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("CreateNewUser")]
        public async Task<IActionResult> CreateNewUser([FromBody] Users objUser)
        {
            bool isUserExists = false;
            try
            {
                await Task.Run(() =>
                {
                    var user = _userRepository.CreateUser(objUser);
                    if (user.IdUser == 0)
                        isUserExists = true;
                });   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            if (!isUserExists)
                return Ok(objUser);
            else
                return BadRequest("User Already Exists");
        }
        [HttpGet]
        [Authorize]
        [Route("GetAllUsers")]
        public async Task<IActionResult>  GetAllUsers()
        {
            try
            {
                var listUsers = await _userRepository.ListAllUsers();
                return Ok(listUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private string GenerateToken(Users objUser)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("Id", objUser.IdUser.ToString()),
                new Claim("Email", objUser.Email)
                //new Claim(ClaimTypes.Role,"Admin")

            };
            var symmeticKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Iconfig["Jwt:Key"]));
            var credentials = new SigningCredentials(symmeticKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_Iconfig["Jwt:Issuer"], _Iconfig["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        static string GenerateJwtWithFixedClaims(string secret, string issuer, string audience, string sub, string jti, long iat)
        {

            var payload = new Dictionary<string, object>
            {
                { "sub", sub },
                { "jti", jti },
                { "iat", iat },
                { "iss", issuer },
                { "aud", audience }
            };



            // Convert payload to JSON
            var jsonPayload = JsonConvert.SerializeObject(payload);

                // Encode JSON to bytes
                var bytesPayload = Encoding.UTF8.GetBytes(jsonPayload);

                // Create header
                var header = new JwtHeader
                {
                    { "typ", "JWT" },
                    { "alg", "HS256" }
                };

                // Convert header to JSON
                var jsonHeader = JsonConvert.SerializeObject(header);

                // Encode JSON to bytes
                var bytesHeader = Encoding.UTF8.GetBytes(jsonHeader);

                // Base64 encode header and payload
                var encodedHeader = Convert.ToBase64String(bytesHeader);
                var encodedPayload = Convert.ToBase64String(bytesPayload);

                // Create signature
                var varOcgSecretBytes = Encoding.UTF8.GetBytes(secret);
                using var hmacsha256 = new HMACSHA256(varOcgSecretBytes);
                var bytesToSign = Encoding.UTF8.GetBytes(encodedHeader + "." + encodedPayload);
                var signatureBytes = hmacsha256.ComputeHash(bytesToSign);
                var encodedSignature = Convert.ToBase64String(signatureBytes);

                // Construct JWT
                var jwt = $"{encodedHeader}.{encodedPayload}.{encodedSignature}";

                return jwt;
            }


        }
    }
