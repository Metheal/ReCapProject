using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Arac eklendi!";
        public static string BrandAdded = "Marka eklendi!";
        public static string ColorAdded = "Renk eklendi!";
        public static string CustomerAdded = "Musteri eklendi!";
        public static string CarInvalidName = "Aracin ismi en az 3 karakter olabilir!";
        public static string DailyPriceInvalid= "Aracin gunluk ucreti 0'dan buyuk olmalidir!";
        
        public static string MaintenanceTime = "Bakim zamani";

        public static string CarsListed = "Araclar listelendi";
        public static string CarListed = "Arac listelendi";
        public static string CarsDTOListed = "Araclar aciklamalariyla listelendi";
        public static string CarDTOListed = "Arac aciklamalariyla listelendi";

        public static string BrandsListed = "Markalar listelendi";
        public static string BrandListed = "Marka listelendi";

        public static string ColorsListed = "Renkler listelendi";
        public static string ColorListed = "Renk listelendi";

        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserListed = "Kullanıcı listelendi";

        public static string CustomersListed = "Musteriler listelendi";
        public static string CustomerListed = "Musteri listelendi";
        public static string CustomersDTOListed = "Musteriler detayli listelendi";
        public static string CustomerDTOListed = "Musteri detayli listelendi";

        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalListed = "Kiralama listelendi";
        public static string RentalsDTOListed = "Kiralamalar detayli listelendi";
        public static string RentalDTOListed = "Kiralama detayli listelendi";

        public static string CarImageLimitExceeded = "Aracin 5'ten fazla resmi olamaz";
        public static string CarImageUpdated = "Arac resmi guncellendi";
        public static string CarImageAdded = "Arac resmi eklendi";
        public static string CarImageDeleted = "Arac resmi silindi";
        public static string NotAnImage = "Lutfen gorsel yukleyiniz";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanici basariyla kaydedildi";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Parola hatali";
        public static string SuccessfulLogin = "Sisteme giris basarili";
        public static string UserAlreadyExists = "Bu kullanici adi kullaniliyor";
        public static string AccessTokenCreated = "Access Token basariyla olusturuldu";

        public static string NotEnoughFindexScore = "Musterinin yeterli findex puani yok";
    }
}
