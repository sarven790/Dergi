using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneTakip.Models
{
    public class KategoriTablosu
    {
        [Key]
        public int ID { get; set; }
        public string KategoriAdi { get; set; }
        public IList<DergilerTablosu> dergilerTablosus;
    }
}
