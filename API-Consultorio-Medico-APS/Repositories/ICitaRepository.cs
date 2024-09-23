using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Server.Base;

namespace API_Consultorio_Medico_APS.Repositories
{
    public interface ICitaRepository:IBaseRepository<Cita>
    {
        IEnumerable<CitaDTO> ConsultarDTO();
        Cita ConsultarPorId(int id);
    }
}
