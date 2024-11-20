using API_Consultorio_Medico_APS.Base;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;

namespace API_Consultorio_Medico_APS.Repositories
{
    public interface IUsuarioRepository: IBaseRepository<Usuario>
    {
        bool ExisteNombreUsuario(int id, string nombreUsuario);
        Usuario ConsultarPorCorreo(string correo);
    }
}
