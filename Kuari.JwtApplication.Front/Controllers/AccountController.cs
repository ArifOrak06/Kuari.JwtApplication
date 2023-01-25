using Kuari.JwtApplication.Front.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Kuari.JwtApplication.Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public AccountController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var client = this._httpclientFactory.CreateClient();
                var content = new StringContent(JsonSerializer.Serialize(model),Encoding.UTF8,"application/json");
                var response =  await client.PostAsync("http://localhost:5213/api/auth/login",content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JsonWebTokenResponseModel>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    if (tokenModel != null)
                    {
                        JwtSecurityTokenHandler handler = new();
                        var token = handler.ReadJwtToken(tokenModel.Token);
                        var claimsIdentity = new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };


                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
                return View();
            }
            return View(model);
        }
    }
}
