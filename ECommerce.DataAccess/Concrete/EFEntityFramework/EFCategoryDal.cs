using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Context;
using ECommerce.Domain.Entities;
using ECommerce.Repository.DataAccess.EntityFrameworkAccess;

namespace ECommerce.DataAccess.Concrete.EFEntityFramework;

public class EFCategoryDal : EFEntityRepositoryBase<Category, NortWindDbContext>, ICategoryDal
{



}
