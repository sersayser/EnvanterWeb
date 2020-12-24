using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnvanterWeb.Models.Entity
{
    public class KullaniciTipi
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen kullanici tipi giriniz!")]
        [MaxLength(50, ErrorMessage = "Lütfen 50 karakteri geçmeyiniz!")]
        public string Tipi { get; set; }
    }
}
