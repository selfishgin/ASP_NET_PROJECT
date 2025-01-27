using ECommerce.Application.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Concrete;

public class CategoryService(ICategoryDal categoryDal) : ICategoryService
{
	private readonly ICategoryDal _categoryDal = categoryDal;

	public List<Category> GetAll()
	{
		return _categoryDal.GetList();
	}

}
