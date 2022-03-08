using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mevzuuCafe.Models
{
    public class Email
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string AdSoyad { get; set; }
        public string GonderenMail { get; set; }
    }
}