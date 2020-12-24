using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnvanterWeb.Models.Entity
{
    public class Kullanici
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen kullanici adınızı giriniz!")]
        [MaxLength(50, ErrorMessage ="Lütfen 50 karakteri geçmeyiniz!")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Lütfen şifre alanını boş bırakmayınız!")]
        [MaxLength(50, ErrorMessage = "Lütfen 50 karakteri geçmeyiniz!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen ad soyad bilgisi giriniz!")]
        [MaxLength(50, ErrorMessage = "Lütfen 50 karakteri geçmeyiniz!")]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "Lütfen kullanici tipini seçiniz!")]
        
        public int KullaniciTipi { get; set; }
        public int BolumId { get; set; }
        public bool AktifMi { get; set; }
        public virtual Bolum bolum { get; set; }
    }
}
