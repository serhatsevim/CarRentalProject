using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using(CarRentalContext context = new CarRentalContext)
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.Id
							 join cl in context.Colors
							 and c.ColorId equals cl.Id
							 select new CarDetailDto
							 {
								CarName = c.Description, BrandName = b.Name, ColorName = cl.Name, DailyPrice = c.DailyPrice 
							 };
							 
				return result.ToList();			 
			}
		}
	}
}