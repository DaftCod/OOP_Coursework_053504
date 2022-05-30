using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Constellation> Constellations { get; set; }
        public virtual DbSet<ConstellationStar> ConstellationStars { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<GeographicalObject> GeographicalObjects { get; set; }
        public virtual DbSet<Star> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Animal>()
                .Property(e => e.FamilyName)
                .IsFixedLength();

            modelBuilder.Entity<Constellation>()
                .Property(e => e.ShortName)
                .IsFixedLength();

            modelBuilder.Entity<Country>()
                .Property(e => e.Religions)
                .IsFixedLength();

            modelBuilder.Entity<GeographicalObject>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Star>()
                .Property(e => e.FlemstedBayerCode)
                .IsFixedLength();

            modelBuilder.Entity<Star>()
                .Property(e => e.VisibleSize)
                .IsFixedLength();

            modelBuilder.Entity<Star>()
                .Property(e => e.HR)
                .IsFixedLength();

            modelBuilder.Entity<Star>()
                .Property(e => e.HIP)
                .IsFixedLength();

            modelBuilder.Entity<Star>()
                .Property(e => e.HD)
                .IsFixedLength();
        }
    }
}
