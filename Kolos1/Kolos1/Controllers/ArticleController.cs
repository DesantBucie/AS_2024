using Microsoft.AspNetCore.Mvc;
using Kolos1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolos1.Controllers
{
	public class ArticleController : Controller
	{
		private readonly MyDbContext _db;
		public ArticleController(MyDbContext db) { _db = db; }
		public IActionResult Index()
		{
			var article = _db.Articles.ToList();

			return View(article);
		}
		public IActionResult AddUpdate(int id = -1)
		{
			var authors = _db.Authors.ToList();
			var authorsList = authors.Select(a => new SelectListItem
			{ Text = a.FirstName + " " + a.LastName, Value = a.Id.ToString()});
			ViewBag.AuthorsList = authorsList;

			var category = _db.Categories.ToList();
			var categoryList = category.Select(c => new SelectListItem
			{ Text = c.Name, Value = c.Id.ToString() });
			ViewBag.CategoryList = categoryList;

			if (id != -1)
			{
				var article = _db.Articles.FirstOrDefault(a => a.Id == id);
				return View(article);
			}
			else
			{
				return View();
			}
		}
		[HttpPost]
		public IActionResult AddUpdate(Article article)
		{
			if (ModelState.IsValid)
			{
				var author = _db.Authors.FirstOrDefault(a => article.AuthorId == a.Id);
				var category = _db.Categories.FirstOrDefault(c => article.AuthorId == c.Id);
				article.CreationDate = DateTime.Now;
				if (article.Id != 0)
				{
					var art = _db.Articles.FirstOrDefault(a => a.Id == article.Id);
					if (art != null)
					{
						art.Author = author;
						art.AuthorId = article.AuthorId;
						art.Cateogry = category;
						art.CategoryId = article.CategoryId;

						art.Title = article.Title;
						art.Lead = article.Lead;
						art.Content = article.Content;
						art.CreationDate = article.CreationDate;
					}
					else
					{
						return View("Error", new Exception("Article is null"));
					}
				}
				else
				{
					_db.Articles.Add(article);
				}
				try
				{
					_db.SaveChanges();
				}
				catch (Exception ex)
				{
					return View("Error", ex);
				}
				return RedirectToAction("Index");
			}
			return View("Error", new Exception("Model state is invalid"));
		}
		public IActionResult Delete(int id)
		{
			var article = _db.Articles.FirstOrDefault(a => a.Id == id);
			if (article != null)
			{
				_db.Articles.Remove(article);
				try
				{
					_db.SaveChanges();
				}
				catch(Exception ex)
				{
					return View("Error", ex);
				}
				return View();
			}
			return View("Error", new Exception("Id is wrong"));
		}
	}
}
