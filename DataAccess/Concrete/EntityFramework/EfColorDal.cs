using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfColorDal : EfEntityRepositoryBase<Color,CarRentalContext>, IColorDal
	{
		
	}
}