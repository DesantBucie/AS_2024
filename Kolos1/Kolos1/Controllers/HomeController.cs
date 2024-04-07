using Microsoft.AspNetCore.Mvc;

namespace Kolos1.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Title = "Home";
			return View();
		}
	}
}
