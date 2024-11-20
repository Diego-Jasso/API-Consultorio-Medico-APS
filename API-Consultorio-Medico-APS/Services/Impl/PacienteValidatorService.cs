using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using FluentValidation;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class PacienteValidatorService : AbstractValidator<Paciente>
    {
        public PacienteValidatorService(IUsuarioRepository repository) 
        { 
            Include(new ValidaCorreo(repository));
        }
        public class ValidaCorreo : AbstractValidator<Paciente>
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

            public bool ValidaCorreoRepetido(Paciente usuario)
            {
                return !_repository.ExisteNombreUsuario(usuario.Id, usuario.Correo);
            }
        }
    }
}
