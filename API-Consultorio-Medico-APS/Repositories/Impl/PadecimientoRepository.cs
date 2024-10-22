using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using Consultorio.Server.Base.Impl;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class PadecimientoRepository(AppDbContext context) : BaseRepository<Padecimiento>(context), IPadecimientoRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<PadecimientoDTO> ConsultarDTO()
        {
            IEnumerable<Padecimiento> query = _context.Padecimiento.ToList();
            return from p in query
                   select new PadecimientoDTO
                   {
                       Id = p.Id,
                       Descripcion = p.Descripcion
                   };
        }

        public Padecimiento ConsultarPorId(int id)
        {
            return _context.Padecimiento.Find(id);
        }

        public Padecimiento ConsultarPorNombre(string nombre)
        {
            return _context.Padecimiento.Where(p => p.Descripcion.Trim().Equals(nombre.Trim())).FirstOrDefault();
        }
    }
}
