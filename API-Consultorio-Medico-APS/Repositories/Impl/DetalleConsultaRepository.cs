using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using Consultorio.Server.Base.Impl;
using Microsoft.EntityFrameworkCore;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class DetalleConsultaRepository(AppDbContext context) : BaseRepository<DetalleConsulta>(context), IDetalleConsultaRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<DetalleConsultaDTO> ConsultarDTO()
        {
            IEnumerable<DetalleConsulta> query = _context.DetalleConsulta.Include(dc => dc.Consulta).ToList();
            return from dc in query
                   select new DetalleConsultaDTO
                   {
                       Id = dc.Id,
                       Consulta_Id = dc.Consulta_Id,
                       Padecimiento = dc.Padecimiento,
                       Tratamiento = dc.Tratamiento,
                       Duracion = dc.Duracion,
                       Comentarios = dc.Comentarios
                   };
        }

        public DetalleConsulta ConsultarPorId(int id)
        {
            return _context.DetalleConsulta.Find(id);
        }
    }
}
