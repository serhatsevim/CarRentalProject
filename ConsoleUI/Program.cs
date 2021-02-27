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
			//UserTest();
			//CustomerTest();
			//RentalTest();
			private static void CarTest()
			{
				CarManager carManager = new CarManager(new EfCarDal());			
				//Verilen Id'si eşleşen arabanın bilgileri ekrana yaz
				var car = carManager.GetById(3).Data;
				Console.WriteLine("Model Yılı : {0} Günlük Ücreti : {1} Detaylar : {2}",car.ModelYear, car.DailyPrice, car.Description);
				//Yeni bir araba ekle
				var resultAdd = carManager.Add(new Car{BrandId=3, ColorId=2, ModelYear=2021, DailyPrice=200, Description="Navigasyon, Manuel vites, Klima"});
				if (result.Success == true)
				{
					Console.WriteLine(resultAdd.Message);
				}
				//Id ye göre arabayı güncelle
				carManager.Update(new Car{Id=2, BrandId=2, ColorId=3, ModelYear=2012, DailyPrice=300, Description="Navigasyon, Otomatik Vites, Elektrikli Klima"});
				//Id si gönderilen arabayı sil
				carManager.Delete(new Car{Id=3});
				//Tüm arabaları listele
				var resultList = carManager.GetAll();
				if (resultList.Success == true)
				{
					foreach(var car in resultList.Data)
					{
						Console.WriteLine("Model Yılı : {0} Günlük Ücreti : {1} Detaylar : {2}",car.ModelYear, car.DailyPrice, car.Description);
					}
				}
				else
				{
					Console.WriteLine(resultList.Message);
				}
			}	
			
			private static void BrandTest()
			{
				BrandManager brandManager = new BrandManager(new EfBrandDal());			
				//Verilen Id'si eşleşen markanın bilgileri ekrana yaz
				var brand = brandManager.GetById(4).Data;
				Console.WriteLine("Marka: ", brand.Name);
				//Yeni bir marka ekle
				brandManager.Add(new Brand{Name="Mercedes"});
				//Id ye göre markayı güncelle
				brandManager.Update(new Brand{Id=2, Name = "Audi");
				//Id si gönderilen markayı sil
				brandManager.Delete(new Brand{Id=3});
				//Tüm markaları listele
				foreach(var brand in brandManager.GetAll().Data)
				{
					Console.WriteLine("Marka ", brand.Name);
				}
			}	

			private static void ColorTest()
			{
				ColorManager colorManager = new ColorManager(new EfColorDal());			
				//Verilen Id'si eşleşen rengin bilgilerini ekrara yaz
				var color = colorManager.GetById(5).Data;
				Console.WriteLine("Color : ", color.Name);
				//Yeni bir renk ekle
				colorManager.Add(new Color{Name = "Mavi"});
				//Id ye göre rengi güncelle
				colorManager.Update(new Color{Id=2, Name="Sarı");
				//Id si gönderilen rengi sil
				colorManager.Delete(new Color{Id=3});
				//Tüm renkleri listele
				foreach(var color in colorManager.GetAll().Data)
				{
					Console.WriteLine("Renk : ", color.Name);
				}
			}

			private static void UserTest()
			{
				UserManager userManager = new UserManager(new EfUserDal());			
				//Verilen Id'si eşleşen kullanıcı bilgilerini ekrara yaz
				var user = userManager.GetById(3).Data;
				Console.WriteLine("Adı : {0} Soyadı : {1} Email Adresi : {2} ", user.FirstName, user.LastName, user.Email);
				//Yeni bir kullanıcı ekle
				userManager.Add(new User{FirstName = "Deneme", LastName = "Deneme1234", Email = "deneme@deneme.com", Password="1234"});
				//Id ye göre kullanıcıyı güncelle
				userManager.Update(new User{Id=2, Email="deneme1234@deneme.com");
				//Id si gönderilen kullanıcıyı sil
				userManager.Delete(new User{Id=4});
				//Tüm kullanıcıları listele
				foreach(var user in userManager.GetAll().Data)
				{
					Console.WriteLine("Adı : {0} Soyadı : {1} Email Adresi : {2} ", user.FirstName, user.LastName, user.Email);
				}
			}

			private static void CustomerTest()
			{
				CustomerManager customerManager = new CustomerManager(new EfCustomerDal());			
				//Verilen Id'si eşleşen müşteri bilgilerini ekrara yaz
				var customer = customerManager.GetById(5).Data;
				Console.WriteLine("Şirket Adı : ", customer.CompanyName);
				//Yeni bir müşteri ekle
				customerManager.Add(new Customer{CompanyName = "X Company", UserId = 5);
				//Id ye göre müşteriyi güncelle
				customerManager.Update(new Customer{Id=2, CompanyName = "XY Software");
				//Id si gönderilen müşteriyi sil
				customerManager.Delete(new Customer{Id=4});
				//Tüm müşterileri listele
				foreach(var customer in customerManager.GetAll().Data)
				{
					Console.WriteLine("Şirket Adı : ", customer.CompanyName);
				}
			}

			private static void RentalTest()
			{
				RentalManager rentalManager = new RentalManager(new EfRentalDal());			
				//Verilen Id'si eşleşen kiralama bilgilerini ekrara yaz
				var rental = rentalManager.GetById(7).Data;
				Console.WriteLine("Araba Id : {0} Müşteri Id : {1} Kiralama Tarihi : {2} Teslim Tarihi : {3}", rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
				//Yeni bir araç kiralama kaydı ekle
				rentalManager.Add(new Rental{CarId = 3, CustomerId = 5, RentDate = "02/21/2021");
				//Id ye göre kiralamayı güncelle
				rentalManager.Update(new Rental{Id=2, ReturnDate = "02/27/2021");
				//Id si gönderilen kaydı sil
				rentalManager.Delete(new Rental{Id=4});
				//Tüm kiralık araçları listele
				foreach(var rentalCars in rentalManager.GetAll().Data)
				{
					Console.WriteLine("Araba Id : {0} Müşteri Id : {1} Kiralama Tarihi : {2} Teslim Tarihi : {3}", rentalCars.CarId, rentalCars.CustomerId, rentalCars.RentDate, rentalCars.ReturnDate);
				}
			}			
		}
	}
}