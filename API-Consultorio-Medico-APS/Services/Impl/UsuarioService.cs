using AutoMapper;
using API_Consultorio_Medico_APS.Services;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using API_Consultorio_Medico_APS.Repositories.Impl;
using System.Security.Cryptography;
using System.Text;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class UsuarioService(IUsuarioRepository repository,IMapper mapper) : IUsuarioService
    {
        private readonly IUsuarioRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<UsuarioDTO> ConsultarDTO()
        {
            throw new NotImplementedException();
        }

        public UsuarioDTO ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioDTO ConsultarPorCorreo(string correo)
        {
            Usuario usuario = _repository.ConsultarPorCorreo(correo);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public UsuarioDTO Agregar(UsuarioNewDTO usuarioDto)
        {
            throw new NotImplementedException();
        }

        public UsuarioDTO Editar(UsuarioDTO usuarioDto)
        {
            throw new NotImplementedException();
        }

        public UsuarioDTO EliminarDTO(int id)
        {
            throw new NotImplementedException();

        }
        public UsuarioDTO Eliminar(int id)
        {
            throw new NotImplementedException();

        }

        public bool LoginExitoso(LoginDTO login)
        {
            bool esExitosoLogin = false;
            
            Usuario usuarioTemp =  _repository.ConsultarPorCorreo(login.email);

            if (usuarioTemp != null){
                using var hmac = new HMACSHA512(usuarioTemp.passwordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != usuarioTemp.passwordHasH[i])
                    {
                        esExitosoLogin = false;
                    }
                    else
                    {
                        esExitosoLogin = true;
                    }
                }
            } 
            return esExitosoLogin;
        }
    }
}
