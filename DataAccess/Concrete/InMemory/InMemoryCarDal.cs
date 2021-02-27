using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;
		public InMemoryCarDal()
		{
			_cars = new List<Car>{
				new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2010, DailyPrice=70, Description="Elektronik Klima, Navigasyon , Manuel Vites, Hava yastığı"},
				new Car{Id=2, BrandId=2, ColorId=3, ModelYear=2012, DailyPrice=100, Description="Navigasyon, Otomatik Vites"},
				new Car{Id=3, BrandId=1, ColorId=5, ModelYear=2015, DailyPrice=150, Description="Vip hizmete özel araç"},
				new Car{Id=4, BrandId=3, ColorId=2, ModelYear=2017, DailyPrice=175, Description="Navigasyon, Hava yastığı, Otomatik vites"},
				new Car{Id=5, BrandId=3, ColorId=4, ModelYear=2021, DailyPrice=250, Description="Elektronik Klima, Navigasyon, Hava yastığı, Manuel Vites"}
			}; 
		}
		
		public void Add(Car car)
		{
			_cars.Add(car);
		}		
			
		public void Delete(Car car)
		{
			Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
			_cars.Remove(carToDelete);
		}
		
		public List<Car> GetAll()
		{
			return _cars;
		}
		
		public Car GetById(int id)
		{
			return _cars.SingleOrDefault(c => c.Id == id);
		}		
		
		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.ModelYear = car.ModelYear;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.Description = car.Description;
		}
		
		public List<CarDetailDto> GetCarDetails()
		{
			throw NotImplementedException();
		}
	}
}
