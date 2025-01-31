using ECommerce.Domain.Entities;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Abstract;

public interface ICartService
{
	void AddToCart(Cart cart, Product product);
	void RemoveFromCart(Cart cart, int productId);
	List<CartLine> List(Cart cart);
}
