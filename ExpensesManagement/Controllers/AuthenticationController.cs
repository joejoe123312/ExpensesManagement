using ExpensesManagement.Data;
using ExpensesManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpensesManagement.Controllers
{
    public class AuthenticationController : Controller
    {

        public AuthenticationController()
        {

        }

        // Get - Login
        [Route("Login")]
        public IActionResult Login([FromQuery] string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            if (username == "pusa" && password == "potpot13A")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, "pusa"));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimPrincipal);
                returnUrl = (returnUrl == null) ? "/" : returnUrl;
                return Redirect(returnUrl);
            }

            return BadRequest();
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.SignOutAsync();

            return Redirect("Login");
        }
    }
}
