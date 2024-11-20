using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.Base.Impl;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using API_Consultorio_Medico_APS.Repositories;

namespace API_Consultorio_Medico_APS.Repositories.Impl
{
    public class UsuarioRepository(AppDbContext context) : BaseRepository<Usuario>(context), IUsuarioRepository
    {
        private readonly AppDbContext _context = context;

        public bool ExisteNombreUsuario(int id, string nombreUsuario)
        {
            return _context.Paciente.Any(x => x.Id != id && x.Correo == nombreUsuario) || _context.Empleado.Any(x => x.Id != id && x.Correo == nombreUsuario);
        }

        public Usuario ConsultarPorCorreo(string correo)
        {

            Usuario? usuario = (from user in context.Paciente
                               where user.Correo == correo && user.Status 
                               select new Usuario
                               {
                                   Id = user.Id,
                                   Nombre = user.Nombre,
                                   Status = user.Status,
                                   User = user.Correo,
                                   passwordHasH = user.passwordHasH,
                                   passwordSalt = user.passwordSalt,
                                   AccountType = "PAC"
                               }).FirstOrDefault();
            if (usuario == null)
            {
                usuario = (from user in context.Empleado
                           where user.Correo == correo && user.Status
                           select new Usuario
                           {
                               Id = user.Id,
                               Nombre = user.Nombre,
                               Status = user.Status,
                               User = user.Correo,
                               passwordHasH = user.passwordHasH,
                               passwordSalt = user.passwordSalt,
                               AccountType = "EMP"
                           }).FirstOrDefault();
            }
            return usuario;
        }
    }
}
