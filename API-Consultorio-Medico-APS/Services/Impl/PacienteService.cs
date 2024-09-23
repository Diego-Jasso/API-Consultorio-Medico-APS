using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class PacienteService(IPacienteRepository repository, IMapper mapper) : IPacienteService
    {
        private readonly IPacienteRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<PacienteDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public PacienteDTO ConsultarPorId(int id)
        {
            Paciente Paciente = _repository.ConsultarPorId(id);
            return _mapper.Map<PacienteDTO>(Paciente);
        }
        public PacienteDTO Agregar(PacienteNewDTO dto)
        {
            Paciente Paciente = _mapper.Map<Paciente>(dto);
            PacienteValidatorService validator = new();
            ValidationResult result = validator.Validate(Paciente);
            if (result.IsValid)
            {
                _repository.Agregar(Paciente);
                return _mapper.Map<PacienteDTO>(Paciente);
            }
            else
            {
                return PacienteDTO.ToError(
                    result.ToString(", "));
            }
        }

        public PacienteDTO Editar(PacienteDTO dto)
        {
            Paciente Paciente = _mapper.Map<Paciente>(dto);
            PacienteValidatorService validator = new();
            ValidationResult result = validator.Validate(Paciente);
            if (result.IsValid)
            {
                _repository.Editar(Paciente);
                return _mapper.Map<PacienteDTO>(Paciente);
            }
            else
            {
                return PacienteDTO.ToError(
                    result.ToString(", "));
            }
        }

        public PacienteDTO Eliminar(int id)
        {
            Paciente Paciente = _repository.ConsultarPorId(id);
            PacienteValidatorService validator = new();
            ValidationResult result = validator.Validate(Paciente);
            if (result.IsValid)
            {
                _repository.Eliminar(Paciente);
                return _mapper.Map<PacienteDTO>(Paciente);
            }
            else
            {
                return PacienteDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
