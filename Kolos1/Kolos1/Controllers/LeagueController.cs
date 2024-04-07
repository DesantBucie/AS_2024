using Microsoft.AspNetCore.Mvc;
using Kolos1.Models;

namespace Kolos1.Controllers
{
	public class LeagueController : Controller
	{
		private readonly MyDbContext _dbContext;
		public LeagueController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			var leagues = _dbContext.Leagues.ToList();
			return View(leagues);
		}

		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(League league)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Leagues.Add(league);
				try
				{
					_dbContext.SaveChanges();
				}
				catch (Exception ex)
				{
					return View("Error", ex);
				}
				return View("Added");
			}
			return View("Error", new Exception("Model state is invalid"));
		}
	}
}
