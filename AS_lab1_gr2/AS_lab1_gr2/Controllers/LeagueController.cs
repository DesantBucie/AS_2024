using AS_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_lab1_gr2.Controllers
{
    public class LeagueController : Controller
    {
        private readonly MyDbContext _dbContext;

        public IActionResult Index()
        {
            return View();
        }

        public LeagueController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
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
                _dbContext.Leagues.Add(league); //Repository.AddArticle(article);

                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error");
                }

                return View("Added");
            }
            return View("Error");
        }
    }
}

