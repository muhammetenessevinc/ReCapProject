using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarNameInvalid = "Ürün İsme Geçersiz";
        public static string MaintenanceTime="sistem bakımda";
        public static string CarsListed= "Ürünler listelendi";
        public static string CarsDeleted = "Ürünler silindi";
        public static string CarsUpdated = "Ürünler güncellendi";
        public static string CarsPrice = "Fiyat sıfırdan büyük olmalı";
        //internal


        public static string UserAdded = "Kişi Eklendi";
        public static string UserDeleted = "Kişi silindi";
        public static string UserUpdated = "Kişi güncellendi";



        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";



        public static string RentalAdded = "Kiralama İşlemi Eklendi";
        public static string RentalDeleted = "Kiralama İşlemi Silindi";
        public static string RentalUpdated = "Kiralama İşlemi Güncellendi";
        public static string RentalUndeliveredCar = "Araç Henüz Teslim Edilmedi";




        public static string BrandAdded = "Model Eklendi";
        public static string BrandDeleted = "Model silindi";
        public static string BrandUpdated = "Model güncellendi";
        public static string BrandListed = "Modeller Listelendi";


        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorListed = "Renkler Listelendi";



        public static string ImageLimit="Resim Ekleme Sınırı Aşıldı";



        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound= "Kullanıcı bulunamadı";
        public static string PasswordError="Parola hatası";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists="Kullanıcı Mevcut";
        public static string AccessTokenCreated="Token Oluşturuldu";



        public static string RolesCame = "Roller Geldi";
        public static string UserGetById = "Id' ye göre Listeleme Yapıldı";
        public static string UserGetAll = "Tümü Listelendi";



        public static string CreditCardAdded = "Kartınızdan Ücret Tahsil Edilmiştir";
        public static string CreditCardDeleted = "CART silindi";
        public static string CreditCardUpdated = "CART güncellendi";
        public static string CreditCardListed = "CART listelendi";



        public static string ErrorRent = "Araç şuanda başka bir kişide lütfen aracın iade eilmesini bekleyin yada farklı bir araç seçiniz";




        public static string RentalInValid = "";
        public static string CarIsRentable = "";
    }
}
