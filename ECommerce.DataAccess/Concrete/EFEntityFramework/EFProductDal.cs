using ECommerce.DataAccess.Abstact;
using ECommerce.DataAccess.Context;
using ECommerce.Domain.Entities;
using ECommerce.Repository.DataAccess.EntityFrameworkAccess;

namespace ECommerce.DataAccess.Concerete.EFEntityFramework;

public class EFProductDal : EFEntityRepositoryBase<Product, NortWindDbContext>, IProductDal
{


}