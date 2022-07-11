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
                  UnidadDeMedida = "Miligramos"
              },
              new Vitaminas() {
                  VitaminaId = 2,
                  Descripcion = "Vitamina B",
                  UnidadDeMedida = "Microgramos"
              }
            );
        }
    }
}
