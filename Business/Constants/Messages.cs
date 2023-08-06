using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "eklendi";
        public static string NameInvalid = "isim geçersiz";
        public static string MaintenanceTime ="Sistem bakımda";
        public static string Listed =" Listelendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string ItisLike = "Ürün önceden beğenilmiş";


    }
}
