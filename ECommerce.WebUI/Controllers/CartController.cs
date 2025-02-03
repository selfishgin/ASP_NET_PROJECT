using ECommerce.Application.Abstract;
using ECommerce.Domain.Models;
using ECommerce.WebUI.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers;

public class CartController(ICartSessionService sessionService, IProductService productService, ICartService cartService) : Controller
{
	private readonly ICartSessionService _sessionService = sessionService;
	private readonly IProductService _productService = productService;
	private readonly ICartService _cartService = cartService;

	public IActionResult AddToCart(int productId)
	{
		var productToBeAdded = _productService.GetById(productId);
		var cart = _sessionService.GetCart();
		_cartService.AddToCart(cart, productToBeAdded);
		_sessionService.SetCart(cart);

		TempData["message"] = string.Format("Your product, {0} was succesfully added", productToBeAdded.ProductName);

		return RedirectToAction("Index", "Product");
	}

	public IActionResult List()
	{
		var cart = _sessionService.GetCart();
		var model = new CartListViewModel{
			Cart = cart
		};
		return View(model);
	}

	public IActionResult Remove(int productId)
	{
		var cart = _sessionService.GetCart();
		_cartService.RemoveFromCart(cart, productId);
		_sessionService.SetCart(cart);
		TempData["message"] = string.Format("Your product was succesfully deleted");
		return RedirectToAction("List");
	}

	[HttpGet]
	public IActionResult Complete()
	{
		var shippingDetailsViewModel = new ShippingDetailsViewModel
		{
			ShippingDetails = new ShippingDetails()
			{ 
				Address=string.Empty, 
				Age=0, 
				City=string.Empty, 
				Email=string.Empty, 
				Firstname=string.Empty, 
				Lastname=string.Empty,
			}


		};
		return View(shippingDetailsViewModel);
	}

	[HttpPost]
	public IActionResult Complete(ShippingDetailsViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}
		TempData.Add("message", String.Format("Thank you, {0}! Your order is in progress.", model.ShippingDetails.Firstname));
		Thread.Sleep(1000);
		return RedirectToAction("Index", "Product");

	}

}
