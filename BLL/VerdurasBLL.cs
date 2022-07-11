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

            bool paso = _context.SaveChanges() > 0;

            _context.Entry(verdura).State = EntityState.Detached;

            return paso;
        }

        public bool Modificar(Verduras verdura)
        {

            _context.Database.ExecuteSqlRaw($"DELETE FROM VerdurasDetalle WHERE VerduraId={verdura.VerduraId};");

            _context.Entry(verdura).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;

            _context.Entry(verdura).State = EntityState.Detached;

            return guardo;
        }

        public bool Eliminar(Verduras verdura)
        {
            _context.Entry(verdura).State = EntityState.Deleted;

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

        public List<Verduras> GetListByDate(DateTime desde, DateTime hasta)
        {
            return _context.Verduras
                .Where(c => desde.Date <= c.FechaCreacion.Date && hasta.Date >= c.FechaCreacion.Date)
                .AsNoTracking()
                .ToList();
        }

        public List<Verduras> GetList()
        {
            return _context.Verduras
                 .AsNoTracking()
                 .ToList();
        }
    }
}
