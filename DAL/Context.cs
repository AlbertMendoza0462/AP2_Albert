using AP2_Albert.Models;
using Microsoft.EntityFrameworkCore;

namespace AP2_Albert.DAL
{
    public class Context: DbContext
    {
        public DbSet<Vitaminas> Vitaminas { get; set; }
        public DbSet<Verduras> Verduras { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vitaminas>().HasData(
              new Vitaminas() {
                  VitaminaId = 1,
                  Descripcion = "Vitamina A",
                  UnidadMedida = "Miligramos",
                  Existencia = 0
              },
              new Vitaminas() {
                  VitaminaId = 2,
                  Descripcion = "Vitamina B",
                  UnidadMedida = "Microgramos",
                  Existencia = 0
              },
              new Vitaminas()
              {
                  VitaminaId = 3,
                  Descripcion = "Vitamina C",
                  UnidadMedida = "Miligramos",
                  Existencia = 0
              },
              new Vitaminas()
              {
                  VitaminaId = 4,
                  Descripcion = "Vitamina D",
                  UnidadMedida = "Microgramos",
                  Existencia = 0
              }
            );
        }
    }
}
