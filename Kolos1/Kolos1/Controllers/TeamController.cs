using Microsoft.AspNetCore.Mvc;
using Kolos1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolos1.Controllers
{
	public class TeamController : Controller
	{
		private readonly MyDbContext _db;
		public TeamController(MyDbContext db) { _db = db; }

		public IActionResult Index()
		{
			var model = _db.Teams.ToList();
			return View(model);
		}
		public IActionResult Add(int id = -1)
		{
			var leagues = _db.Leagues.ToList();
			var leagueList = leagues.Select(l =>  new SelectListItem {  Text = l.Name, Value = l.Id.ToString()}).ToList();
			
			ViewBag.LeagueList = leagueList;
			if (id != -1)
			{
				var team = _db.Teams.FirstOrDefault(t => t.Id == id);
				return View(team);
			}
			else
			{
				return View();
			}
		}
		[HttpPost]
		public IActionResult Add(Team team)
		{
			if (ModelState.IsValid)
			{
				var league = _db.Leagues.FirstOrDefault(l => l.Id == team.LeagueId);
				if (league == null)
				{
					return View("Error", new Exception("League is null"));
				}
				if (team.Id != 0)
				{
					var updateTeam = _db.Teams.FirstOrDefault(l => l.Id == team.Id);
					if (updateTeam != null)
					{
						updateTeam.Name = team.Name;
						updateTeam.League = league;
						updateTeam.City = team.City;
						updateTeam.Country = team.Country;
					}
				}
				else
				{
					team.League = league;
					_db.Teams.Add(team);
				}
				try
				{
					_db.SaveChanges();
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
