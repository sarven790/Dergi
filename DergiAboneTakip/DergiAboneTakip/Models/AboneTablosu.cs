using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneTakip.Models
{
    public class AboneTablosu
    {
        [Key]
        public int ID { get; set; }
        public int UyeID { get; set; }      
        public int Ay { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime AboneTarih { get; set; }
        public bool Durum { get; set; }
        public int DergiID { get; set; }

    }
}
