using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Server.Base;

namespace API_Consultorio_Medico_APS.Repositories
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        IEnumerable<PacienteDTO> ConsultarDTO();
        Paciente ConsultarPorId(int id);
    }
}
