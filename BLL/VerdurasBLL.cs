using Microsoft.EntityFrameworkCore;
using AP2_Albert.DAL;
using AP2_Albert.Models;

namespace AP2_Albert.BLL
{
    public class VerdurasBLL
    {
        private Context _context;
        public VerdurasBLL(Context context)
        {
            _context = context;
        }

        public bool Existe(int verduraId)
        {
            return _context.Verduras.Any(verdura => verdura.VerduraId == verduraId);
        }

        public bool Guardar(Verduras verdura)
        {
            return !Existe(verdura.VerduraId) ? Insertar(verdura) : Modificar(verdura);
        }

        public bool Insertar(Verduras verdura)
        {
            _context.Verduras.Add(verdura);

            foreach (var item in verdura.Detalle)
            {
                Vitaminas vitamina = _context.Vitaminas.Find(item.VitaminaId);
                vitamina.Existencia += item.Cantidad;
            }

            bool paso = _context.SaveChanges() > 0;

            _context.Entry(verdura).State = EntityState.Detached;

            return paso;
        }

        public bool Modificar(Verduras verdura)
        {
            var anterior = _context.Verduras
               .Where(v => v.VerduraId == verdura.VerduraId)
               .Include(v => v.Detalle)
               .AsNoTracking()
               .SingleOrDefault();

            foreach (var item in anterior.Detalle)
            {
                var vitamina = _context.Vitaminas.Find(item.VitaminaId);
                vitamina.Existencia -= item.Cantidad;
            }
            _context.Entry(anterior).State = EntityState.Detached;

            foreach (var item in verdura.Detalle)
            {
                Vitaminas vitamina = _context.Vitaminas.Find(item.VitaminaId);
                vitamina.Existencia += item.Cantidad;
                _context.Entry(item).State = EntityState.Added;
            }

            _context.Database.ExecuteSqlRaw($"DELETE FROM VerdurasDetalle WHERE VerduraId={verdura.VerduraId};");

            _context.Entry(verdura).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;

            _context.Entry(verdura).State = EntityState.Detached;

            return guardo;
        }

        public bool Eliminar(Verduras verdura)
        {
            _context.Entry(verdura).State = EntityState.Deleted;

            var anterior = _context.Verduras
               .Where(c => c.VerduraId == verdura.VerduraId)
               .Include(c => c.Detalle)
               .AsNoTracking()
               .SingleOrDefault();

            foreach (var item in anterior.Detalle)
            {
                var vitamina = _context.Vitaminas.Find(item.VitaminaId);
                vitamina.Existencia -= item.Cantidad;
            }

            _context.Database.ExecuteSqlRaw($"DELETE FROM VerdurasDetalle WHERE VerduraId={verdura.VerduraId};");


            bool paso = _context.SaveChanges() > 0;

            _context.Entry(verdura).State = EntityState.Detached;

            return paso;
        }

        public Verduras? Buscar(int compraId)
        {
            return _context.Verduras
                .Include(c => c.Detalle)
                .Where(c => c.VerduraId == compraId)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public List<Verduras>? GetListByDate(DateTime desde, DateTime hasta)
        {
            return _context.Verduras
                .Where(c => desde.Date <= c.FechaCreacion.Date && hasta.Date >= c.FechaCreacion.Date)
                .AsNoTracking()
                .ToList();
        }

        public List<Verduras>? GetList()
        {
            return _context.Verduras
                 .AsNoTracking()
                 .ToList();
        }
    }
}
