using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ECommerce.WebUI.Entities;

public class CustomIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
{
	public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options) : base(options)
	{

	}
}
