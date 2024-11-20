using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Base;

namespace API_Consultorio_Medico_APS.Repositories
{
    public interface IDetalleConsultaRepository : IBaseRepository<DetalleConsulta>
    {
        IEnumerable<DetalleConsultaDTO> ConsultarDTO();
        DetalleConsulta ConsultarPorId(int id);
        Cita ConsultarCitaDesdeDetalle(int id);
    }
}
