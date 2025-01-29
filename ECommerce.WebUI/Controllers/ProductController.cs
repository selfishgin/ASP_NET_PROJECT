using ECommerce.Application.Abstract;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers;

public class ProductController(IProductService productService) : Controller
{
	private readonly IProductService _productService = productService;


	public IActionResult Index(int page = 1, int categoryId = 0)
	{
		int pageSize = 10;
		var products = _productService.GetAllByCategory(categoryId);
		var pagedProducts = products.Skip((page-1)*pageSize).Take(pageSize).ToList();

		var model = new ProductListViewModel
		{
			Products = pagedProducts,
			CurrentCategory = categoryId,
			PageCount = (int)Math.Ceiling((double)products.Count/pageSize),
			PageSize = pageSize,
			CurrentPage = page
		};
		return View(model);
	}


}
