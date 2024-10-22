using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using Consultorio.Server.Base.Impl;
using Microsoft.EntityFrameworkCore;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class ExpedienteRepository(AppDbContext context) : BaseRepository<Expediente>(context), IExpedienteRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<ExpedienteDTO> ConsultarDTO()
        {
            IEnumerable<Expediente> query = _context.Expediente.Include(e => e.Paciente).ToList();
            return from e in query
                   select new ExpedienteDTO
                   {
                       Id = e.Id,
                       Paciente_Id = e.Paciente_Id,
                       Nombre = e.Paciente.Nombre,
                       APaterno = e.Paciente.APaterno,
                       AMaterno = e.Paciente.AMaterno,
                       Altura = e.Altura,
                       Peso = e.Peso,
                       Alergias = e.Alergias,
                       Genero = e.Genero
                   };
        }

        public Expediente ConsultarPorId(int id)
        {
            return _context.Expediente.Find(id);
        }

        public Expediente ConsultarPorPacienteId(int id)
        {
            return _context.Expediente.Where(e => e.Paciente_Id == id).FirstOrDefault();
        }
    }
}
