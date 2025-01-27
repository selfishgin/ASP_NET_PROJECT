using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService categoryService;

		public IActionResult Index()
		{
			var category = _categoryService.GetAll();
		}
	}
}
