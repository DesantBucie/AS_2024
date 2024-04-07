using Microsoft.AspNetCore.Mvc;
using Kolos1.Models;

namespace Kolos1.Controllers
{
	public class AuthorController : Controller
	{
		private readonly MyDbContext _dbContext;
		public AuthorController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			var model = _dbContext.Authors.ToList();
			return View(model);
		}

		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Author author)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Authors.Add(author);
				try
				{
					_dbContext.SaveChanges();
				}
				catch (Exception ex)
				{
					return View("Error",ex);
				}
				
				return View("Added");
			}
			return View("Error", new Exception("Model state is invalid"));
		}
	}
}
