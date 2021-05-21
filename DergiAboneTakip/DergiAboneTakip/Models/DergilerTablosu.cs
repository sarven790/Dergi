using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneTakip.Models
{
    public class DergilerTablosu
    {
        [Key]
        public int ID { get; set; }
        public string DergiAdi { get; set; }
        public decimal Fiyat { get; set; }
        public bool Durum { get; set; }
        public KategoriTablosu kategori { get; set; }
        
    }
}
