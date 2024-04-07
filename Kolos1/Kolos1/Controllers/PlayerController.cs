using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kolos1.Models;
namespace Kolos1.Controllers
{
	public class PlayerController : Controller
	{
		private readonly MyDbContext _db;
		public PlayerController(MyDbContext db) { _db = db; }
		public IActionResult Index()
		{
			var model = _db.Players.ToList();
			return View(model);
		}
		public IActionResult AddUpdate(int id = -1)
		{
			var positions = _db.Positions.ToList();
			

			var positionList = positions.Select(p => new SelectListItem { 
				Text = p.Name, 
				Value = p.Id.ToString() 
			}).ToList();
			ViewBag.PositionList = positionList;

			var teams = _db.Teams.ToList();
			var teamsList = teams.Select(t => new SelectListItem { 
				Text = t.Name,
				Value = t.Id.ToString() 
			}).ToList();
            ViewBag.TeamsList = teamsList;

			if(id != -1)
			{
				var player = _db.Players.FirstOrDefault(p => p.Id == id);
				ViewBag.Header = "Edycja gracza";
				ViewBag.Button = "Edytuj";
				return View(player);
			}
			else
			{
				ViewBag.Header = "Dodaj gracza";
				ViewBag.Button = "Dodaj";
				return View();
			}
        }
		[HttpPost]
		public IActionResult AddUpdate(Player player, List<int> Positions)
		{
			if (ModelState.IsValid)
			{
				var team = _db.Teams.FirstOrDefault(t => t.Id == player.TeamId);	

				var playerPositions = _db.Positions.Where(pos => Positions.Contains(pos.Id)).ToList();
					
				if(player.Id != 0)
				{
					var p = _db.Players.FirstOrDefault(p => p.Id == player.Id);
					if(p != null)
					{
						p.FirstName = player.FirstName;
						p.LastName = player.LastName;
						p.Team = team;
						p.BirthDate = player.BirthDate;
						p.Country = player.Country;
						
						p.Positions?.Clear();
						foreach(var position in playerPositions)
						{
							p.Positions.Add(position);
						}
					}

				}
				else
				{
					player.Team = team;
					player.Positions = playerPositions;
					_db.Players.Add(player);
				}
				try
				{
					_db.SaveChanges();
				}
				catch (Exception ex)
				{
					return View("Error", ex);
				}
				return View("AddedUpdated");
			}
			return View("Error", new Exception("Model state is invalid"));
		}
	}
}
