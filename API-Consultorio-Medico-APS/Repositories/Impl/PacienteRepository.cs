using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using Consultorio.Server.Base.Impl;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class PacienteRepository(AppDbContext context) : BaseRepository<Paciente>(context), IPacienteRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<PacienteDTO> ConsultarDTO()
        {
            IEnumerable<Paciente> query = _context.Paciente.Where(p => p.Status == true).ToList();
            return from p in query
                   select new PacienteDTO
                   {
                       Id = p.Id,
                       Nombre = p.Nombre,
                       APaterno = p.APaterno,
                       AMaterno = p.AMaterno,
                       NumTelefono = p.NumTelefono,
                       Correo = p.Correo,
                       HistorialMed = p.HistorialMed,
                       FechaNac = p.FechaNac,
                       Usuario = p.Usuario,
                       Contraseña = p.Contraseña,
                       Status = p.Status
                   };
        }

        public Paciente ConsultarPorId(int id)
        {
            return _context.Paciente.Find(id);
        }
    }
}
