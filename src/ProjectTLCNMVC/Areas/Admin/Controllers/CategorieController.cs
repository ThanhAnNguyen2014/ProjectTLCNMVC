using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNMVC.Dao.Admin;
using ProjectTLCNMVC.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTLCNMVC.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class CategorieController : Controller
    {
		ProjectShopAPIContext db;
		public CategorieController(ProjectShopAPIContext _db)
		{
			db = _db;
		}


		// GET: /<controller>/
		public IActionResult Index()
        {
			return View(db.Categories.ToList());

			//var model = new CategoriesDao();
			//return View(model.ListAll());
		}
	}
}
