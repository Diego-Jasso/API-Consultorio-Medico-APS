using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Server.Base;

namespace API_Consultorio_Medico_APS.Repositories
{
    public interface IExp_PadRepository : IBaseRepository<Exp_Pad>
    {
        IEnumerable<Exp_PadDTO> ConsultarDTO();
        Exp_Pad ConsultarPorId(int id);
    }
}
