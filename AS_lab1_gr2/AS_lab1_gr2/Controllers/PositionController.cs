using AS_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_lab1_gr2.Controllers
{
    public class PositionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly MyDbContext _dbContext;

        public PositionController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Position position)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Positions.Add(position); //Repository.AddArticle(article);

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

