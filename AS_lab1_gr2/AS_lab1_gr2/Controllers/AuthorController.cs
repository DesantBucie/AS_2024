﻿using Microsoft.AspNetCore.Mvc;
using AS_lab1_gr2.Models;
using System.Diagnostics;

namespace AS_lab1_gr2.Controllers
{
    public class AuthorController: Controller
    {
        private readonly MyDbContext _dbContext;
        
        public AuthorController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var authors = _dbContext.Authors.ToList();
            Debug.WriteLine("Dupa" + authors);
            return View(authors);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author author)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Authors.Add(author); //Repository.AddArticle(article);

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
