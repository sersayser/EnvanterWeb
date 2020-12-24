using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnvanterWeb.Models.Entity
{
    public class Bolum
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen bölüm adı giriniz!")]
        [MaxLength(50,ErrorMessage ="Lütfen 50 karakteri geçmeyiniz!")]
        public string BolumAdi { get; set; }
    }
}
