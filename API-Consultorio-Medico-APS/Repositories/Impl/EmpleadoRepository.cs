using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Base.Impl;
using Microsoft.EntityFrameworkCore;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class EmpleadoRepository(AppDbContext context) : BaseRepository<Empleado>(context), IEmpleadoRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<EmpleadoDTO> ConsultarDTO()
        {
            IEnumerable<Empleado> query = _context.Empleado.Where(e => e.Status == true).ToList();
            return from e in query
                   select new EmpleadoDTO
                   {
                       Id = e.Id,
                       TipoEmp = e.TipoEmp,
                       Salario = e.Salario,
                       Nombre = e.Nombre,
                       APaterno = e.APaterno,
                       AMaterno = e.AMaterno,
                       Curp = e.Curp,
                       RFC = e.RFC,
                       NumSeguro = e.NumSeguro,
                       Usuario = e.Usuario,
                       Contraseña = e.Contraseña,
                       Status = e.Status,
                       Correo = e.Correo
                   };
        }

        public IEnumerable<TimeOnly> ConsultarHorario(int id,DateOnly date)
        {
            TimeOnly time = new TimeOnly(8, 0, 0);
            List<TimeOnly> horarios = new List<TimeOnly>();
            for (int i = 1; i <= 12; i++)
            {
                TimeOnly auxTime = time.AddHours(i);
                Cita cita = _context.Cita.Where(c => c.Empleado_Id == id && c.Fecha.Equals(date) && c.Hora.Equals(auxTime)).FirstOrDefault();
                if (cita == null) {
                    horarios.Add(auxTime);
                }
            }
            return horarios.ToList();
        }

        public Empleado ConsultarPorId(int id)
        {
            return _context.Empleado.Find(id);
        }
    }
}
