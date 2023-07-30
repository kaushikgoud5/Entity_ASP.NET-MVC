using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CategoryController1 : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController1(ApplicationDbContext db)
        {
                
            _db = db;   
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList= _db.Categories;
             return View(objCategoryList);

        }
        public IActionResult Create()
        {
           
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

             _db.Categories.Add(obj);
             _db.SaveChanges();
             return RedirectToAction("Index");


        }
    }
}
