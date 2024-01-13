using Microsoft.AspNetCore.Mvc.Rendering;
using QuillQuest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.Models.ViewModels
{
	public class ProductVM
	{
		public Product Product { get; set; }
		public IEnumerable<SelectListItem> Categories { get; set; }
	}
}
