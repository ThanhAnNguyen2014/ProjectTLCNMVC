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
		ProjectShopAPIContext context;
		public CategorieController(ProjectShopAPIContext _context)
		{
			context = _context;
		}
		// GET: /<controller>/
		public IActionResult Index()
        {
			return View(context.Categories.ToList());
			//return View(model);
		}
	}
}
