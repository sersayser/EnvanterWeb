using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnvanterWeb.Models.Entity
{
    public class CihazTipi
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen cihaz tipi giriniz!")]
        [MaxLength(50, ErrorMessage ="Lüften 50 karakteri geçmeyiniz!")]
        public string CihazTipiAdi { get; set; }
    }
}
