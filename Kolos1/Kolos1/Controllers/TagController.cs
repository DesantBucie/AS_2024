using Microsoft.AspNetCore.Mvc;
using Kolos1.Models;
namespace Kolos1.Controllers
{
	public class TagController : Controller
	{
		private readonly MyDbContext _dbContext;
		public TagController(MyDbContext dbContext) { _dbContext = dbContext; }
		public IActionResult Index()
		{
			var tags = _dbContext.Tags.ToList();
			return View(tags);
		}

		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Tag tag)
		{
			if(ModelState.IsValid)
			{
				_dbContext.Tags.Add(tag);
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
			return View("Error", new Exception("Modelstate is invalid"));
		}
	}
}
