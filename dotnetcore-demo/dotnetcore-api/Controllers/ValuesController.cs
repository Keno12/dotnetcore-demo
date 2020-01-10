using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnetcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // 简单创建一个token令牌

            // 创建声明数组
            var claims = new Claim[]
           {
                new Claim(ClaimTypes.Name, "laozhang"),
                new Claim(JwtRegisteredClaimNames.Email, "laozhang@qq.com"),
                new Claim(JwtRegisteredClaimNames.Sub, "1"),//主题subject，就是id uid
           };

            // 实例化 token 对象

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("laozhanglaozhang"));//至少16位密钥

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );


            // 生成token
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new string[] { jwtToken };
        }

    }
}