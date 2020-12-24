using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnvanterWeb.Models.Entity
{
    public class Ariza
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Cihaz Seçiniz!")]
        public int CihazId { get; set; }
        public DateTime Tarih { get; set; }
        public int KullaniciId { get; set; }
        public string Aciklama { get; set; }
        public bool ArizaBittiMi { get; set; }
        public virtual Cihaz cihaz { get; set; }
        public virtual Kullanici kullanici { get; set; }
        public virtual Bolum bolum { get; set; }
    }
}
