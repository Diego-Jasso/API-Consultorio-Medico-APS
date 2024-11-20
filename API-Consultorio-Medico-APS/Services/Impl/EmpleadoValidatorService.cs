using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using FluentValidation;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class EmpleadoValidatorService : AbstractValidator<Empleado>
    {
        public EmpleadoValidatorService(IUsuarioRepository repository)
        {
            Include(new ValidaCorreo(repository));
        }
        public class ValidaCorreo : AbstractValidator<Empleado>
        {
            private readonly IUsuarioRepository _repository;

            public ValidaCorreo(IUsuarioRepository repository)
            {
                _repository = repository;
                RuleFor(m => m.Correo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El correo es requerido");
                RuleFor(user => user)
                    .Must(ValidaCorreoRepetido).WithMessage("El correo ingresado ya pertenece a una cuenta");
            }

            public bool ValidaCorreoRepetido(Empleado usuario)
            {
                return !_repository.ExisteNombreUsuario(usuario.Id, usuario.Correo);
            }
        }
    }
}
