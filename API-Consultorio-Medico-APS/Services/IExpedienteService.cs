using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Base;

namespace API_Consultorio_Medico_APS.Services
{
    public interface IExpedienteService:IBaseService<ExpedienteDTO,ExpedienteNewDTO>
    {
        ExpedienteDTO ConsultarPorPacienteId(int id);
    }
}
