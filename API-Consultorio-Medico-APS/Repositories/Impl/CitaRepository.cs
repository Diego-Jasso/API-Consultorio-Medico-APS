using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Base.Impl;
using Microsoft.EntityFrameworkCore;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class CitaRepository(AppDbContext context) : BaseRepository<Cita>(context), ICitaRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<CitaDTO> ConsultarDTO()
        {
            IEnumerable<Cita> query = _context.Cita.Include(c => c.Empleado).Include(c => c.Paciente).Include(c => c.TipoDeCita).Where(c => c.Status == true).ToList();
            return from c in query
                   select new CitaDTO
                   {
                       Id = c.Id,
                       Paciente_Id = c.Paciente_Id,
                       Empleado_Id = c.Empleado_Id,
                       NombrePaciente = c.Paciente.Nombre,
                       APaternoPaciente = c.Paciente.APaterno,
                       AMaternoPaciente = c.Paciente.AMaterno,
                       NombreEmpleado = c.Empleado.APaterno,
                       APaternoEmpleado = c.Empleado.APaterno,
                       AMaternoEmpleado = c.Empleado.AMaterno,
                       Fecha = c.Fecha,
                       Hora = c.Hora,
                       Status = c.Status,
                       TipoCita = c.TipoCita,
                       TipoCitaDescripcion = c.TipoDeCita.Descripcion,
                       Asistencia = c.Asistencia
                   };
        }

        public Cita ConsultarPorId(int id)
        {
            return _context.Cita.Find(id);
        }
    }
}
