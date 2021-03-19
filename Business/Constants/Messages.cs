using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string AddedItem = "Kayıt eklendi.";
		public static string AddedItemError = "Kayıt eklenemedi.";
		public static string DeletedItem = "Kayıt silindi.";
		public static string DeletedItemError = "Kayıt silinemedi.";
		public static string UpdatedItem = "Kayıt güncellendi.";
		public static string UpdatedItemError = "Kayıt güncellenemedi.";
		public static string DataListed = "Kayıt listelendi.";
		public static string DataListedError = "Kayıt listelenemedi.";
		public static string MaintenanceTime = "Sisteme bakım yapılıyor.";		
		public static string CarIsRentalError = "Bu araç kiralanmış.";		
		public static string CarImageLimitExcededError = "Bir araba  için en fazla 5 resim ekleyebilirsiniz.";		

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessfulLogin="Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated="Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";		
	}
}