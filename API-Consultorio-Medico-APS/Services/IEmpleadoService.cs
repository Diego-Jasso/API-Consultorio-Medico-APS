using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Server.Base;

namespace API_Consultorio_Medico_APS.Services
{
    public interface IEmpleadoService:IBaseService<EmpleadoDTO,EmpleadoNewDTO>
    {
        EmpleadoDTO DarDeBaja(int id);
        List<TimeOnly> ConsultarHorario(int id, DateOnly date);
    }
}
