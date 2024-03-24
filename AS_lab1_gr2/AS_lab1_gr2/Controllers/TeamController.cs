using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AS_lab1_gr2.Models;

public class TeamController : Controller {
    private MyDbContext _dbContext;

    public TeamController(MyDbContext dbContext){
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        ViewBag.teams = _dbContext.Teams.ToList();
        return View();
    }
    public IActionResult Add()
    {
        var leagues = _dbContext.Leagues.ToList();
        var leagueList = new List<SelectListItem>();
        foreach (var l in leagues)
        {
            string text = l.Level + ", " + l.Country + " - " +  l.Name;
            string id = l.Id.ToString();
            leagueList.Add(new SelectListItem(text, id));
        }
        ViewBag.leagueList = leagueList;

        return View();
    }
    [HttpPost]
    public IActionResult Add(Team team){
        if(ModelState.IsValid){
            var league = _dbContext.Leagues.FirstOrDefault(l => l.Id == team.LeagueId); 
            if(league == null){
                ViewBag.error = "League is null";
                return View("Error");
            }
            team.League = league;

            _dbContext.Teams.Add(team);
            try {
                _dbContext.SaveChanges();
            }
            catch (Exception ex) {
                ViewBag.error = "Cannot save changes";
                return View("Error");
            }
            return View("Added");
        }
        ViewBag.error = "Model state is invalid";
        return View("Error");
    }
}
