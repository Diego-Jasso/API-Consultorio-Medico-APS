using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Base.Impl;
using Microsoft.EntityFrameworkCore;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class ConsultaRepository(AppDbContext context) : BaseRepository<Consulta>(context), IConsultaRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<ConsultaDTO> ConsultarDTO()
        {
            IEnumerable<Consulta> query = _context.Consulta.Include(c => c.Cita).ToList();
            return from c in query
                   select new ConsultaDTO
                   {
                       Id = c.Id,
                       Cita_Id = c.Cita_Id,
                       Costo = c.Costo,
                       Comentarios = c.Comentarios
                   };
        }

        public Consulta ConsultarPorId(int id)
        {
            return _context.Consulta.Find(id);
        }
    }
}
