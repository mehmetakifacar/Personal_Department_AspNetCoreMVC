using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Personal_Department_AspNetCoreMVC.Models;
using System.Security.Claims;

namespace Personal_Department_AspNetCoreMVC.Controllers
{
	public class LoginController : Controller
	{
		Context db = new Context();
		//public IActionResult LogIn()
		//{
		//	return View();
		//}


		public async Task<IActionResult> LogIn(Admin p1)
		{
			var info = db.Admins.FirstOrDefault(c => c.User == p1.User &&
			c.Password == p1.Password);

			if (info != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,p1.User)

				};
				var userIdentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Personal");
			}
			return View();
		}
	}
}
