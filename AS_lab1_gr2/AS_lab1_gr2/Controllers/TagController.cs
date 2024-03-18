using AS_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_lab1_gr2.Controllers
{
    public class TagController : Controller
    {
        private readonly MyDbContext _dbContext;
        public IActionResult Index()
        {
            return View();
        }

        public TagController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Tags.Add(tag); //Repository.AddArticle(article);

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

