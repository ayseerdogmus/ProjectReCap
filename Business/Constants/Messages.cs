using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı.";
        public static string AddFailed = "Ekleme işlemi başarısız!";
        public static string Deleted = "Silme işlemi başarılı.";
        public static string DeletedFailed = "Silme işlemi başarısız!";
        public static string Updated = "Güncelleme işlemi başarılı.";
        public static string UpdatedFailed = "Güncelleme işlemi başarısız!";
        public static string Listed = "Listeleme işlemi başarılı";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string CarAvailable="Araç kiralanabilir";
        public static string CarNotAvailable="Araç kiralanamaz henüz teslim edilmemiş!";
        public static string NotSuitableExtension="Resmin uzantısı uygun formatta değil!";
        public static string CarImagesCountError="Bir araca ait en fazla 5 fotoğraf eklenebilir!";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string UserRegistered="Kullanıcı kayıt oldu.";
        public static string UserNotFound="Kullanıcı bulunamadı!";
        public static string PasswordError="Parola hatası!";
        public static string SuccessfulLogin="Başarılı giriş.";
        public static string UserAlreadyExist="Kullanıcı zaten mevcut!";
        public static string AccessTokenCreated="Token oluşturuldu.";
    }
}
