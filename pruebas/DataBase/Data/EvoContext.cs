using Evo.Apiii.DataBase.Model.Shcemas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo_DataAccess.Data
{
    public class EvoContext : DbContext
    {
        public EvoContext(DbContextOptions<EvoContext> options) : base(options) { }

        public DbSet<PropietariosEntity> Propietarios { get; set; }
        public DbSet<MascotasEntity> mascotas { get; set; }
        public DbSet<TipoMascotasEntity> TipoMascotas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Empresas");

            modelBuilder.Entity<MascotasEntity>(e =>
            {
                e.Property(x => x.Id).IsUnicode();
                e.HasOne(x => x.TipoMascotas)
                .WithMany(x => x.Mascotas)
                .HasForeignKey(x => x.TipoDeMascotaId);

                e.HasOne(x => x.Propietarios)
                .WithMany(x => x.Mascotas)
                .HasForeignKey(x => x.PropietarioId);

            });
        }

    }
}
