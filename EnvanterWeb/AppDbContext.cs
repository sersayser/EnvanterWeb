
using EnvanterWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnvanterWeb
{
    public class AppDbContext:DbContext
    {

        public DbSet<Ariza> Arizalar { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Cihaz> Cihazlar { get; set; }
        public DbSet<CihazTipi> CihazTipleri { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciTipi> KullaniciTipleri { get; set; }
        public DbSet<Marka> Markalar { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Ariza için Database tablo alanları kriterleri
            modelBuilder.Entity<Ariza>().ToTable("Arizalar");
            modelBuilder.Entity<Ariza>().HasKey(x => x.Id);
            modelBuilder.Entity<Ariza>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Ariza>().Property(x => x.CihazId).IsRequired();

            //Bolum için Database tablo alanları kriterleri
            modelBuilder.Entity<Bolum>().ToTable("Bolumler");
            modelBuilder.Entity<Bolum>().HasKey(x => x.Id);
            modelBuilder.Entity<Bolum>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Bolum>().Property(x => x.BolumAdi).HasMaxLength(50);

            //Cihaz için Database tablo alanları kriterleri
            modelBuilder.Entity<Cihaz>().ToTable("Cihazlar");
            modelBuilder.Entity<Cihaz>().HasKey(x => x.Id);
            modelBuilder.Entity<Cihaz>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Cihaz>().Property(x => x.MarkaId).IsRequired();
            modelBuilder.Entity<Cihaz>().Property(x => x.Model).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Cihaz>().Property(x => x.SeriNo).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Cihaz>().Property(x => x.CihazTipiId).IsRequired();

            //CihazTipi için Database tablo alanları kriterleri
            modelBuilder.Entity<CihazTipi>().ToTable("CihazTipleri");
            modelBuilder.Entity<CihazTipi>().HasKey(x => x.Id);
            modelBuilder.Entity<CihazTipi>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CihazTipi>().Property(x => x.CihazTipiAdi).HasMaxLength(50).IsRequired();

            //Firma için Database tablo alanları kriterleri
            modelBuilder.Entity<Firma>().ToTable("Firmalar");
            modelBuilder.Entity<Firma>().HasKey(x => x.Id);
            modelBuilder.Entity<Firma>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Firma>().Property(x => x.FirmaAdi).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Firma>().Property(x => x.TelefonNo).HasMaxLength(15).IsRequired();

            //Kullanici için Database tablo alanları kriterleri
            modelBuilder.Entity<Kullanici>().ToTable("Kullanicilar");
            modelBuilder.Entity<Kullanici>().HasKey(x => x.Id);
            modelBuilder.Entity<Kullanici>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Kullanici>().Property(x => x.AdSoyad).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Kullanici>().Property(x => x.KullaniciAdi).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Kullanici>().Property(x => x.Password).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Kullanici>().Property(x => x.KullaniciTipi).IsRequired();


            //KullaniciTipi için Database tablo alanları kriterleri
            modelBuilder.Entity<KullaniciTipi>().ToTable("KullaniciTipleri");
            modelBuilder.Entity<KullaniciTipi>().HasKey(x => x.Id);
            modelBuilder.Entity<KullaniciTipi>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<KullaniciTipi>().Property(x => x.Tipi).IsRequired();

            //Marka için Database tablo alanları kriterleri
            modelBuilder.Entity<Marka>().ToTable("Markalar");
            modelBuilder.Entity<Marka>().HasKey(x => x.Id);
            modelBuilder.Entity<Marka>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Marka>().Property(x => x.MarkaAdi).HasMaxLength(50).IsRequired();
        }

    }
}