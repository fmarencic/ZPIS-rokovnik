using System;
using System.Data.Entity;
using ZPISdatabaseAzure.Model;

namespace ZPISdatabaseAzure
{
    public class ZPISRokovnikDatabaseContext : DbContext
    {
        private readonly string databasePath;
        

        public ZPISRokovnikDatabaseContext() : base("name=ZPISRokovnikDatabaseContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PismenoEF>()
           .HasRequired(p => p.PismenoVrsta)
           .WithMany(p => p.Pismena)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<PismenoEF>()
            .HasRequired(p => p.Predmet)
            .WithMany(p => p.Pismena)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<SudionikEF>()
            .HasRequired(p => p.Predmet)
            .WithMany(p => p.Sudionici)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<SudionikEF>()
            .HasRequired(p => p.Uloga)
            .WithMany(p => p.Sudionici)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<UpisnikEF>()
            .HasRequired(p => p.VrstaUpisnika)
            .WithMany(p => p.Upisnici)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<PismenoVrstaEF>()
            .HasRequired(p => p.Schema)
            .WithMany(p => p.PismenaVrste)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<KalendarEF>()
            .HasOptional(p => p.VrstaKalendara)
            .WithMany(p => p.VrsteKalendara)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<PredmetEF>()
            .HasOptional(p => p.StatusPredmeta)
            .WithMany(p => p.StatusiPredmeta)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<PredmetEF>()
            .HasOptional(p => p.Tijelo)
            .WithMany(p => p.Tijela)
            .WillCascadeOnDelete(false);

        }

        #region DbSet

        public virtual DbSet<UlogaEf> Uloga { get; set; }
        public virtual DbSet<DomenaEF> Domena { get; set; }
        public virtual DbSet<KorisnikEF> Korisnik { get; set; }
        public virtual DbSet<KorisnikUlogaEF> KorisnikUloga { get; set; }
        public virtual DbSet<OsobaEF> Osoba { get; set; }
        public virtual DbSet<OsobaFotografijeEF> OsobaFotografije { get; set; }
        public virtual DbSet<PredmetEF> Predmet { get; set; }
        public virtual DbSet<PismenoVrstaEF> PismenoVrsta { get; set; }
        public virtual DbSet<UpisnikEF> Upisnik { get; set; }
        public virtual DbSet<PismenoEF> Pismeno { get; set; }
        public virtual DbSet<DokumentPismenoEF> DokumentPismeno { get; set; }
        public virtual DbSet<SchemaEF> Schema { get; set; }
        public virtual DbSet<SchemaDokumentaEF> SchemaDokumenta { get; set; }
        public virtual DbSet<DokumentEF> Dokument { get; set; }
        public virtual DbSet<SudionikEF> Sudionik { get; set; }
        public virtual DbSet<KalendarEF> Kalendar { get; set; }
        public virtual DbSet<VrstaUpisnikaEF> VrstaUpisnika { get; set; }
        public virtual DbSet<KorisnikAuthEF> KorisnikAuth { get; set; }
        public virtual DbSet<BrojnoStanjeViewEF> BrojnoStanjeView { get; set; }
        #endregion




    }
}
