using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			//Verilen Id'si eşleşen arabanın bilgileri ekrara yazılır.
			var car = carManager.GetById(3))
			Console.WriteLine("Model Yılı : {0} Günlük Ücreti : {1} Detaylar : {2}",car.ModelYear, car.DailyPrice, car.Description);
			//Yeni bir araba ekleme
			carManager.Add(new Car{Id=6, BrandId=3, ColorId=2, ModelYear=2021, DailyPrice=200, Description="Navigasyon, Manuel vites, Klima"});
			//Id ye göre araba günceleniyor
			carManager.Update(new Car{Id=2, BrandId=2, ColorId=3, ModelYear=2012, DailyPrice=300, Description="Navigasyon, Otomatik Vites, Elektrikli Klima"});
			//Id si gönderilen arabayı sil
			carManager.Delete(new Car{Id=3});
			//Tüm arabaları listele
			foreach(var car in carManager.GetAll())
			{
				Console.WriteLine("Model Yılı : {0} Günlük Ücreti : {1} Detaylar : {2}",car.ModelYear, car.DailyPrice, car.Description);
			}
		}
	}
}