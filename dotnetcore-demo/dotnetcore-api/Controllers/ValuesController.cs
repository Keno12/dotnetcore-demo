using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnetcore_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace dotnetcore_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly JwtSetting setting;
        public ValuesController(IOptions<JwtSetting> _setting)
        {
            setting = _setting.Value;
        }

        // GET api/GetToken 简单创建一个token令牌
        [HttpGet]
        public IActionResult GetToken()
        {
            try
            {  
                //1.创建声明数组
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, "wangxiaodao"),
                    new Claim(JwtRegisteredClaimNames.Email, "wangkun32@126.com"),
                    new Claim(ClaimTypes.Role, "admin")
                };

                //2.实例化 token 对象
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.SecretKey));//至少16位密钥
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(setting.Issuer, setting.Audience, claims, DateTime.Now, DateTime.Now.AddMinutes(30), creds);

                //3.生成token
                return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}