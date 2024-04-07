using Kolos1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kolos1.Controllers
{
	public class EventTypeController : Controller
	{
		private readonly MyDbContext _dbContext;
		public EventTypeController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var model = _dbContext.EventTypes.ToList();
			return View(model);
		}
		public IActionResult Add() { return View(); }
		[HttpPost]
		public IActionResult Add(EventType eventType)
		{
			if (ModelState.IsValid)
			{
				_dbContext.EventTypes.Add(eventType);
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
