using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNMVC.Areas.Admin.Models
{
    public class CategoriesViewModel
    {
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public string Picture { get; set; }
		public int DisplayOrder { get; set; }
		public bool IsDisplay { get; set; }
	}
}
