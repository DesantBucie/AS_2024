using Microsoft.AspNetCore.Mvc;
using Kolos1.Models;

namespace Kolos1.Controllers
{
	public class CategoryController : Controller
	{
		private readonly MyDbContext _dbContext;
		public CategoryController(MyDbContext dbContext) {
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			var categories = _dbContext.Categories.ToList();
			return View(categories);
		}
		public IActionResult Add() { return View(); }

		[HttpPost]
		public IActionResult Add(Category category)
		{
			if(ModelState.IsValid)
			{
				_dbContext.Categories.Add(category);
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
			return View("Error", new Exception("Category state is invalid"));
		}
	}
}
