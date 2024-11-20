using API_Consultorio_Medico_APS.Base;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;

namespace API_Consultorio_Medico_APS.Services
{
    public interface IUsuarioService : IBaseService<UsuarioDTO,UsuarioNewDTO>
    {

        bool LoginExitoso(LoginDTO login);

        UsuarioDTO ConsultarPorCorreo(string correo);

    }
}
