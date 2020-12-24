using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnvanterWeb.Models.Entity
{
    public class Cihaz
    {
        public int Id { get; set; }
        public int BolumId { get; set; }
        public int UretimYili { get; set; }
        [Required(ErrorMessage ="Lütfen marka seçiniz!")]
        public int MarkaId { get; set; }
        [Required(ErrorMessage = "Lütfen cihaz tipi seçiniz!")]
        public int CihazTipiId { get; set; }
        [Required(ErrorMessage = "Lütfen model giriniz!")]
        [MaxLength(50,ErrorMessage ="Lütfen 50 karakteri aşmayınız!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Lütfen seri no giriniz!")]
        [MaxLength(50, ErrorMessage = "Lütfen 50 karakteri aşmayınız!")]
        public string SeriNo { get; set; }
        public bool GarantiliMi { get; set; }
        public virtual Marka marka { get; set; }
        public virtual CihazTipi cihazTipi { get; set; }
        public virtual Bolum bolum { get; set; }

    }
}
