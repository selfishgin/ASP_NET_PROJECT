using ECommerce.Domain.Abstracts;

namespace ECommerce.Domain.Entities;

public class Category : IEntity
{
    public int CategoryID { get; set; }
    public required string CategoryName { get; set; }
}
