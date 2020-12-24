using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnvanterWeb.Models.Entity
{
    public class Firma
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Firma adı giriniz!")]
        [MaxLength(50,ErrorMessage ="Lütfen 50 karakteri geçmeyiniz!")]
        public string FirmaAdi { get; set; }
        [Required(ErrorMessage = "Firma adı giriniz!")]
        [MaxLength(15, ErrorMessage = "Lütfen 15 karakteri geçmeyiniz!")]
        public string TelefonNo { get; set; }
        public string KontakKisi { get; set; }
        public string KontakTelefon { get; set; }
        public bool AktifMi { get; set; }
    }
}
