using ECommerce.Domain.Abstracts;

namespace ECommerce.Domain.Entities;

public class Product : IEntity 
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public required int CategoryID { get; set; }
    public required decimal UnitPrice { get; set; }
    public required short UnitInStock { get; set; }
}
