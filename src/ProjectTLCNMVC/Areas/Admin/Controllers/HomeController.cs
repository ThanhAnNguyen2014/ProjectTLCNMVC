﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNMVC.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTLCNMVC.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class HomeController : Controller
    {
		
		// GET: /<controller>/
		public IActionResult Index()
		{
			return View();
		}
		//public ObjectResult Index()
		//{
		//	var categories = new Categories { CategoryName = "Cổng VGA", Description="Cổng xuất hình ảnh từ laptop sang Máy chiếu" };
		//	return new ObjectResult(categories);
		//}


    }
}
