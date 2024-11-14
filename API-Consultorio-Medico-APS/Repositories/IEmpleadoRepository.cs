using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Server.Base;

namespace API_Consultorio_Medico_APS.Repositories
{
    public interface IEmpleadoRepository : IBaseRepository<Empleado>
    {
        IEnumerable<EmpleadoDTO> ConsultarDTO();
        IEnumerable<TimeOnly> ConsultarHorario(int id, DateOnly date);
        Empleado ConsultarPorId(int id);
    }
}
