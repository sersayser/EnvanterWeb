namespace EnvanterWeb.Migrations
{
    using EnvanterWeb.Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EnvanterWeb.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EnvanterWeb.AppDbContext context)
        {
            IEnumerable<Bolum> bolumler = new List<Bolum>()
                {
                new Bolum { Id=1, BolumAdi="Radyoloji"},
                new Bolum { Id=2, BolumAdi="Onkoloji"},
                new Bolum { Id=3, BolumAdi="Pediatri"},
                new Bolum { Id=4, BolumAdi="Dahiliye"},
                new Bolum { Id=5, BolumAdi="Beyin"},
                new Bolum { Id=6, BolumAdi="İdari"},
                new Bolum { Id=7, BolumAdi="Teknik"}
                };
            context.Bolumler.AddRange(bolumler);
            context.SaveChanges();

            IEnumerable<CihazTipi> cihazTipleri = new List<CihazTipi>()
                {
                new CihazTipi { Id=1, CihazTipiAdi="Rontgen"},
                new CihazTipi { Id=2, CihazTipiAdi="MR"},
                new CihazTipi { Id=3, CihazTipiAdi="Hasta Yatağı"},
                new CihazTipi { Id=4, CihazTipiAdi="Ventilatör"},
                new CihazTipi { Id=5, CihazTipiAdi="Kan Sayımı Cihazı"}
                };
            context.CihazTipleri.AddRange(cihazTipleri);
            context.SaveChanges();

            IEnumerable<Firma> firmalar = new List<Firma>()
                {
                new Firma { Id=1, FirmaAdi="Sesa Medikal Ltd", TelefonNo="03122317754", AktifMi=true, KontakKisi="Ali Uysal", KontakTelefon="05674526621"},
                new Firma { Id=2, FirmaAdi="Mesa Medikal Ltd", TelefonNo="02166463281", AktifMi=true, KontakKisi="Mustafa Taşcı", KontakTelefon="05675537711"},
                new Firma { Id=3, FirmaAdi="Helal Medikal Ltd", TelefonNo="03232998361", AktifMi=true, KontakKisi="Mehmet Güven", KontakTelefon="05679986652"},
                new Firma { Id=4, FirmaAdi="Düzgün Medikal Ltd", TelefonNo="02123342654", AktifMi=true, KontakKisi="Serkan Can", KontakTelefon="05678876754"},
                new Firma { Id=5, FirmaAdi="Sağlık Medikal Ltd", TelefonNo="02247643498", AktifMi=true, KontakKisi="Hasan Gezen", KontakTelefon="05678827772"},
                new Firma { Id=6, FirmaAdi="Tedavi Medikal Ltd", TelefonNo="0242665878", AktifMi=true, KontakKisi="Halil Kara", KontakTelefon="056733244311"}
                };
            context.Firmalar.AddRange(firmalar);
            context.SaveChanges();

            IEnumerable<Kullanici> kullanicilar = new List<Kullanici>()
                {
                new Kullanici { Id = 1, AdSoyad = "Kevser Ak", BolumId = 1,KullaniciTipi= 2, KullaniciAdi = "kevser", AktifMi = true, Password = "666666" },
                new Kullanici { Id = 2, AdSoyad = "Mustafa Bal", BolumId = 3,KullaniciTipi= 1, KullaniciAdi = "mustafa", AktifMi = true, Password = "666666" },
                new Kullanici { Id = 3, AdSoyad = "Mehmet Özen", BolumId = 1,KullaniciTipi= 1, KullaniciAdi = "mehmet", AktifMi = true, Password = "666666" },
                new Kullanici { Id = 4, AdSoyad = "Hasan Aynacı", BolumId = 7,KullaniciTipi= 5, KullaniciAdi = "hasan", AktifMi = true, Password = "666666" },
                new Kullanici { Id = 5, AdSoyad = "Serkan Saykal", BolumId = 6,KullaniciTipi= 4, KullaniciAdi = "serkan", AktifMi = true, Password = "666666" }
                };
            context.Kullanicilar.AddRange(kullanicilar);
            context.SaveChanges();

            IEnumerable<Marka> markalar = new List<Marka>()
                {
                new Marka { Id=1, MarkaAdi="Siemens"},
                new Marka { Id=2, MarkaAdi="Fuji"},
                new Marka { Id=3, MarkaAdi="Mespa"},
                new Marka { Id=4, MarkaAdi="Philips"},
                new Marka { Id=5, MarkaAdi="Beckman"}
                };
            context.Markalar.AddRange(markalar);
            context.SaveChanges();

            IEnumerable<KullaniciTipi> kullaniciTipleri = new List<KullaniciTipi>()
                {
                new KullaniciTipi { Id = 1,Tipi="Doktor" },
                new KullaniciTipi { Id = 2, Tipi = "Hemşire" },
                new KullaniciTipi { Id = 3, Tipi = "Destek" },
                new KullaniciTipi { Id = 4, Tipi = "Admin" },
                new KullaniciTipi { Id = 5, Tipi = "Teknik" }
                };
            context.KullaniciTipleri.AddRange(kullaniciTipleri);
            context.SaveChanges();

        }
    }
}
