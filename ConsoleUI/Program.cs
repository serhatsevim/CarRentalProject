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
			CarTest();
			//BrandTest();
			//ColorTest();
			
			private static void CarTest()
			{
				CarManager carManager = new CarManager(new EfCarDal());			
				//Verilen Id'si eşleşen arabanın bilgileri ekrana yaz
				var car = carManager.GetById(3);
				Console.WriteLine("Model Yılı : {0} Günlük Ücreti : {1} Detaylar : {2}",car.ModelYear, car.DailyPrice, car.Description);
				//Yeni bir araba ekle
				carManager.Add(new Car{BrandId=3, ColorId=2, ModelYear=2021, DailyPrice=200, Description="Navigasyon, Manuel vites, Klima"});
				//Id ye göre arabayı güncelle
				carManager.Update(new Car{Id=2, BrandId=2, ColorId=3, ModelYear=2012, DailyPrice=300, Description="Navigasyon, Otomatik Vites, Elektrikli Klima"});
				//Id si gönderilen arabayı sil
				carManager.Delete(new Car{Id=3});
				//Tüm arabaları listele
				foreach(var car in carManager.GetAll())
				{
					Console.WriteLine("Model Yılı : {0} Günlük Ücreti : {1} Detaylar : {2}",car.ModelYear, car.DailyPrice, car.Description);
				}

			}	
			
			private static void BrandTest()
			{
				BrandManager brandManager = new BrandManager(new EfBrandDal());			
				//Verilen Id'si eşleşen markanın bilgileri ekrana yaz
				var brand = brandManager.GetById(4);
				Console.WriteLine("Marka: ", brand.Name);
				//Yeni bir marka ekle
				brandManager.Add(new Brand{Name="Mercedes"});
				//Id ye göre markayı güncelle
				brandManager.Update(new Brand{Id=2, Name = "Audi");
				//Id si gönderilen markayı sil
				brandManager.Delete(new Brand{Id=3});
				//Tüm markaları listele
				foreach(var brand in brandManager.GetAll())
				{
					Console.WriteLine("Marka ", brand.Name);
				}
			}	

			private static void ColorTest()
			{
				ColorManager colorManager = new ColorManager(new EfColorDal());			
				//Verilen Id'si eşleşen rengin bilgilerini ekrara yaz
				var color = colorManager.GetById(5);
				Console.WriteLine("Color : ", color.Name);
				//Yeni bir renk ekle
				colorManager.Add(new Color{Name = "Mavi"});
				//Id ye göre rengi güncelle
				colorManager.Update(new Color{Id=2, Name="Sarı");
				//Id si gönderilen rengi sil
				colorManager.Delete(new Color{Id=3});
				//Tüm renkleri listele
				foreach(var color in colorManager.GetAll())
				{
					Console.WriteLine("Renk : ", color.Name);
				}
			}				
		}
	}
}