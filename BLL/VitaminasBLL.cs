using AP2_Albert.DAL;
using AP2_Albert.Models;
using Microsoft.EntityFrameworkCore;

namespace AP2_Albert.BLL
{
    public class VitaminasBLL
    {
        private Context _context;
        public VitaminasBLL(Context context)
        {
            _context = context;
        }

        public bool Existe(int vitaminaID)
        {
            return _context.Vitaminas.Any(vitamina => vitamina.VitaminaId == vitaminaID);
        }

        public bool Guardar(Vitaminas vitamina)
        {
            return (!Existe(vitamina.VitaminaId)) ? Insertar(vitamina) : Modificar(vitamina);
        }

        public bool Insertar(Vitaminas vitamina)
        {
            _context.Vitaminas.Add(vitamina);

            return _context.SaveChanges() > 0;
        }

        public bool Modificar(Vitaminas vitamina)
        {
            _context.Entry(vitamina).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(vitamina).State = EntityState.Detached;
            return guardo;
        }

        public bool Eliminar(Vitaminas vitamina)
        {
            _context.Entry(vitamina).State = EntityState.Deleted;

            return _context.SaveChanges() > 0;
        }

        public Vitaminas? Buscar(int vitaminaId)
        {
            return _context.Vitaminas
                .Where(p => p.VitaminaId == vitaminaId)
                .SingleOrDefault();
        }

        public List<Vitaminas> GetList()
        {
            return _context.Vitaminas
                .AsNoTracking()
                .ToList();
        }
    }
}
