using ECommerce.Application.Abstract;
using ECommerce.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers;

public class CartController(ICartSessionService sessionService, IProductService productService) : Controller
{
	private readonly ICartSessionService _sessionService = sessionService;
	private readonly IProductService _productService = productService;

	public IActionResult Index()
	{
		return View();
	}
}
