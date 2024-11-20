using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Base.Impl;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class TipoDeCitaRepository(AppDbContext context) : BaseRepository<TipoDeCita>(context), ITipoDeCitaRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<TipoDeCitaDTO> ConsultarDTO()
        {
            IEnumerable<TipoDeCita> query = _context.TipoDeCita.ToList();
            return from tc in query
                   select new TipoDeCitaDTO
                   {
                       Id = tc.Id,
                       Descripcion = tc.Descripcion
                   };
        }

        public TipoDeCita ConsultarPorId(int id)
        {
            return _context.TipoDeCita.Find(id);
        }
    }
}
