using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Server.Base;

namespace API_Consultorio_Medico_APS.Repositories
{
    public interface IPadecimientoRepository : IBaseRepository<Padecimiento>
    {
        IEnumerable<PadecimientoDTO> ConsultarDTO();
        Padecimiento ConsultarPorId(int id);
        Padecimiento ConsultarPorNombre(string nombre);
    }
}
