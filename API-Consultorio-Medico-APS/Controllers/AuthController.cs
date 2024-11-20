using API_Consultorio_Medico_APS.Base.Impl;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Services;
using API_Consultorio_Medico_APS.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace API_Consultorio_Medico_APS.Controllers
{
    public class AuthController(IUsuarioService service,IPacienteService pacienteService,ITokenServices token) : BaseApiController
    {
        private readonly ITokenServices _tokenService = token;
        private readonly IUsuarioService _service = service;
        private readonly IPacienteService _pacienteService = pacienteService;

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<AuthResponseDTO> Login(LoginDTO login)
        {
            var usuarioDto = new AuthResponseDTO();
            var usuario = _service.ConsultarPorCorreo(login.email);
            if (usuario == null)
            {
                usuarioDto = new AuthResponseDTO
                {
                    status = "error",
                    message = "El Usuario no existe",
                    ok = false
                };
                return Ok(usuarioDto);
            }
            var resultado = _service.LoginExitoso(login);

            if (!resultado)
            {
                usuarioDto = new AuthResponseDTO
                {
                    status = "error",
                    message = "Contraseña incorrecta",
                    ok = false
                };
                return Ok(usuarioDto);
            }
             usuarioDto = new AuthResponseTrueDTO
            {
                status = "success",
                message = "Login correcto",
                ok = true,
                id = usuario.Id,
                usname = usuario.User,
                token = _tokenService.CrearToken(usuario),
                accountType = usuario.AccountType
             };

            return Ok(usuarioDto);
        }
        [HttpGet]
        public ActionResult<AuthResponseDTO> Renovar()
        {
            string? token = Request.Headers["TokenKey"];

            if(string.IsNullOrWhiteSpace(token))
            {
                return new AuthResponseDTO
                {
                    status = "error",
                    message = "No se pudo renovar su token",
                    ok = false
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadJwtToken(token);

            int id = Convert.ToInt32(jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value);
            string? nombreUsuario = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.NameId)?.Value;

            if (nombreUsuario == null)
            {
                return new AuthResponseDTO 
                { status = "error", 
                    message = "No se pudo renovar su token", 
                    ok = false 
                };
            }

            UsuarioDTO? usuario = _service.ConsultarPorId(id);

            if(usuario == null)
            {
                return new AuthResponseDTO
                {
                    status = "error",
                    message = "No se pudo renovar su token",
                    ok = false
                };
            }

            return new AuthResponseTrueDTO
            {
                status = "success",
                message = "Token renovado",
                ok = true,
                id = usuario.Id,
                usname = nombreUsuario,
                token = _tokenService.CrearToken(usuario),
                accountType = usuario.AccountType
            };
        }
        [HttpPost("new")]
        public ActionResult<AuthResponseDTO> Registro(PacienteNewDTO dto)
        {
            var result = _pacienteService.Agregar(dto);
            if (result.Success)
            {
                UsuarioDTO userdto = new UsuarioDTO
                {
                    Id = result.Id,
                    User = result.Usuario,
                    Status = result.Status,
                    Contraseña = result.Contraseña
                };
                return new AuthResponseTrueDTO
                {
                    status = "success",
                    message = "Cuenta creada con exito",
                    ok = true,
                    id = result.Id,
                    usname = result.Usuario,
                    token = _tokenService.CrearToken(userdto),
                    accountType = userdto.AccountType
                };
            }
            else
            {
                return new AuthResponseDTO
                {
                    status = "error",
                    message = result.Error,
                    ok = false
                };
            }
        }
                
    }
}
