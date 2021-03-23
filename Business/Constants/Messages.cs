using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarGeted = "Araba bilgisi getirildi.";

        public static string CarsListed = "Arabalar listelendi";
        public static string CarsByBrandsListed = "Arabalar markalarına göre listelendi";
        public static string CarsByColorsListed = "Arabalar renklerine göre listelendi";

        public static string CarDtoListed = "Arabalar listelendi";

        // ------------------------------------------------------------------------------------------

        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDelete = "Marka silindi.";
        public static string BrandUpdate = "Marka güncellendi.";
        public static string BrandGet = "Marka getirildi.";
        public static string BrandsListed = "Markalar listelendi.";

        // ------------------------------------------------------------------------------------------

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDelete = "Renk silindi.";
        public static string ColorUpdate = "Renk güncellendi.";
        public static string ColorGet = "Renk getirildi.";
        public static string ColorsListed = "Renkler listelendi.";

        // ------------------------------------------------------------------------------------------
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserGeted = "Kullanıcı getirildi.";
        public static string UsersListed = "Kullanıcılar listelendi.";
        public static string UsersDtoListed = "Kullanıcıların bilgisi listelendi.";

        // ------------------------------------------------------------------------------------------

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerGeted = "Müşteri getirildi.";
        public static string CustomersListed = "Müşteriler listelendi.";

        // ------------------------------------------------------------------------------------------

        public static string RentalAdded = "Kiralama eklendi.";
        public static string RentalDeleted = "Kiralama silindi.";
        public static string RentalUpdated = "Kiralama güncellendi.";
        public static string RentalGeted = "Kiralama getirildi.";
        public static string RentalListed = "Kiralamalar listelendi.";

        // ------------------------------------------------------------------------------------------
        public static string NameRull = "Araç ismi minimum 2 karakterden oluşmalıdır.";
        public static string PriceRull = "Araçın günlük fiyatı 0'dan büyük olmalıdır.";
        public static string MaintenanceTime = "Bakim";
        public static string CarAlreadyExist = "Araç zaten var";
        public static string BrandLimitExceded = "Marka limiti aşıldı";
        public static string AuthorizationDenied = "Gerekli yetki bulunamadı";
        // ------------------------------------------------------------------------------------------
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Eşleşmedi";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExist = "Kullanıcı zaten var";
        public static string SuccessfulRegister = "Kayıt başarılı";
    }
}
