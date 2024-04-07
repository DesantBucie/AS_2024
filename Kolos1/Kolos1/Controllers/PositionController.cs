using Microsoft.AspNetCore.Mvc;
using Kolos1.Models;
namespace Kolos1.Controllers
{
	public class PositionController : Controller
	{
		private readonly MyDbContext _dbcontext;
		public PositionController(MyDbContext dbcontext)
		{
			_dbcontext = dbcontext;
		}
		public IActionResult Index()
		{
			var positions = _dbcontext.Positions.ToList();
			return View(positions);
		}
		public IActionResult Add() { return View(); }
		[HttpPost]
		public IActionResult Add(Position position)
		{
			if (ModelState.IsValid)
			{
				_dbcontext.Positions.Add(position);
				try
				{
					_dbcontext.SaveChanges();
				}
				catch (Exception ex)
				{
					return View("Error", ex);
				}
				return View("Added");
			}
			return View("Error", new Exception("Model state is invalid"));
		}
	}
}
