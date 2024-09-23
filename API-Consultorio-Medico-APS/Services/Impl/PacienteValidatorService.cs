using API_Consultorio_Medico_APS.Models;
using FluentValidation;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class PacienteValidatorService : AbstractValidator<Paciente>
    {
        public PacienteValidatorService() { }
    }
}
