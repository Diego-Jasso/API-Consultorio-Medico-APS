using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;

namespace API_Consultorio_Medico_APS.Services
{
    public interface ITokenServices
    {
        string CrearToken(UsuarioDTO dto);
    }
}
