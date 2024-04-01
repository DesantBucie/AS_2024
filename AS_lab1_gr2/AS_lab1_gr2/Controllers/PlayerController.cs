
using AS_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AS_lab1_gr2.Controllers
{
    public class PlayerController : Controller
    {
        private MyDbContext _dbContext;

        public PlayerController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.players = _dbContext.Players.ToList();
            return View();
        }

        public IActionResult AddEdit(int id=-1)
        {
            var positions = _dbContext.Positions.ToList();
            ViewBag.positionList = positions;

            var teams = _dbContext.Teams.ToList();
            var teamList = new List<SelectListItem>();
            
            foreach (var t in teams)
            {
                string text = t.Name;
                string sid = t.Id.ToString();
                teamList.Add(new SelectListItem(text, sid));
            }
            ViewBag.teamList = teamList;
            if (id == -1)
            {
                ViewBag.Header = "Dodaj gracza";
                ViewBag.Button = "Dodaj";
                return View();
            }
            else
            {
                var player = _dbContext.Players.FirstOrDefault(x => x.Id == id);
                ViewBag.Header = "Edytuj gracza";
                ViewBag.Button = "Edytuj";
                return View(player);
            }
        }

        [HttpPost]
        public IActionResult AddEdit(Player player, int[] positions)
        {
            var team = _dbContext.Teams.FirstOrDefault(x => x.Id == player.TeamId);
            player.Team = team;

            var playerPositions = _dbContext.Positions.Where(p => positions.Contains(p.Id)).ToList();
            player.Positions = playerPositions;
            if (player.Id == 0)
            {
                _dbContext.Players.Add(player);
            }
            else
            {
                _dbContext.Players.Update(player);
            }
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View("Error");
            }
            
            return View("Added");
            
        }
    }
}