using ECommerce.Application.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ECommerce.WebUI.ViewComponents;

public class CategoryListViewComponent : ViewComponent
{
	private readonly ICategoryService _categoryService;

	public CategoryListViewComponent(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	public ViewViewComponentResult Invoke()
	{
		var model = new CategoryListViewModel
		{
			Categories = _categoryService.GetAll()
		};
		return View(model);
	}
}
