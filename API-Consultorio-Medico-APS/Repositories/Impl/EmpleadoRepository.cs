using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using Consultorio.Server.Base.Impl;
using Microsoft.EntityFrameworkCore;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class EmpleadoRepository(AppDbContext context) : BaseRepository<Empleado>(context), IEmpleadoRepository
    {
        private readonly AppDbContext _context = context;
        public IEnumerable<EmpleadoDTO> ConsultarDTO()
        {
            IEnumerable<Empleado> query = _context.Empleado.ToList();
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
                       Contraseña = e.Contraseña
                   };
        }

        public Empleado ConsultarPorId(int id)
        {
            return _context.Empleado.Find(id);
        }
    }
}
