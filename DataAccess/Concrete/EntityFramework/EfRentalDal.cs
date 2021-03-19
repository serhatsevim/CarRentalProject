using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentalDal : EfEntityRepositoryBase<Rental,CarRentalContext>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails()
		{
			using(CarRentalContext context = new CarRentalContext())
			{
				var result = from r in context.Rentals
							 join c in context.Cars
							 on r.CarId equals c.Id
							 join b in context.Brands 
							 on b.Id equals c.BrandId
							 join cm in context.Customers
							 on r.CustomerId equals cm.Id
							 join u in context.Users
							 on u.Id equals cm.UserId
							 select new RentalDetailDto
							 {
								RentalId = r.Id, BrandName = b.Name, CustomerName = u.FirstName + " " + u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate
							 };
							 
				return result.ToList();
			}
		}
	}
}