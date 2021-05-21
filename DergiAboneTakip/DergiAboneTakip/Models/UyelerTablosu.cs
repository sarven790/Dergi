using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneTakip.Models
{
    public class UyelerTablosu
    {
        [Key]
        public int ID { get; set; }
        public string KulAdi { get; set; }
        public string KulSoyadi { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public int Yetki { get; set; }
        public bool Durum { get; set; }

    }
}
