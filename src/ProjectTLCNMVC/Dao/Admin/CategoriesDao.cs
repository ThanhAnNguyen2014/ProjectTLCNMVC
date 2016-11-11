using ProjectTLCNMVC.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using ProjectTLCNMVC.Areas.Admin.Models;

namespace ProjectTLCNMVC.Dao.Admin
{

	public class CategoriesDao
    {

		ProjectShopAPIContext context;
		public List<Categories> ListAll()
		{
			return context.Categories.Where(x => x.IsDisplay == true).ToList();
		}
	}
}
