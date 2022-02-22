using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIIntro_0.Controllers
{
    public class ValueController : ApiController
    {
        #region Notlar
        //MVC projelerinde bir Action'in basına bir HTTP attribute'u koymadıgımız takdirde bu Action'in default request'i Get olarak algılanır...

        //API projelerinde ise bu yöntemlerin özellikle yazılması gerekir. Yoksa Action tanınmaz... Bu şekilde özellikle Request yöntemini Attribute olarak yazmazsanız ilgili Action'in calısabilmesinin tek yolu Action isminin basına ilgili Request yöntemlerinden birisinin yazılmasıdır(Get, Post vs)....

        //Eget HTTP yöntemini bir attribute olarak tanımlamak istemezseniz o zaman Request yöntem adlarınızın(Get,Post,Put,Delete) Action isminin basına yazılmasına Conventional Basing Route yöntemi denir... Eger Attribute yöntemini tercih ediyorsanız buna Customized Route yöntemi denir...




        /*
         Get: Bir sayfanın ilk kez gelmesidir(siz url'den aynı sayfayı isteseniz bile o aslında yapılan yepyeni bir istektir ve sayfa yeni bir şekilde size ilk kez gibi gelecektir)...
         Post: Size gelmiş olan bir sayfanın tekrar server'a geri gönderilmesidir(API'da özellikle sadece ekleme işlemleri icin kullanılır...Teknik olarak Post yönteminde güncelleme yapabiliyor olsanız da API'da güncelleme icin Post saglıklı degildir...)
         Put: API'da güncelleme icin tercih edilir...
         Delete: API'da silme işlemleri icin tercih edilir...
         
         
         
         */



        #endregion





        static List<string> _sehirler = new List<string>
       {
           "İstanbul","İzmir","Yalova"
       };

        [HttpGet]
        public List<string> ListCities()
        {
            return _sehirler;
        }


        [HttpGet]
        public string GetCityByIndex(int index)
        {
            return _sehirler[index];
        }

        [HttpPost]
        public List<string> AddCity(string item)
        {
            _sehirler.Add(item);
            return ListCities();
        }

        [HttpDelete]
        public List<string> RemoveCity(string item)
        {
            _sehirler.Remove(item);
            return _sehirler;
        }

        [HttpPut]
        public List<string> UpdateCity(int index,string yeniDeger)
        {
            _sehirler[index] = yeniDeger;
            return _sehirler;
        }






    }
}
