using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class ExpedienteService(IExpedienteRepository repository, IMapper mapper) : IExpedienteService
    {
        private readonly IExpedienteRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<ExpedienteDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public ExpedienteDTO ConsultarPorId(int id)
        {
            Expediente Expediente = _repository.ConsultarPorId(id);
            return _mapper.Map<ExpedienteDTO>(Expediente);
        }
        public ExpedienteDTO ConsultarPorPacienteId(int id)
        {
            Expediente Expediente = _repository.ConsultarPorPacienteId(id);
            return _mapper.Map<ExpedienteDTO>(Expediente);
        }
        public ExpedienteDTO Agregar(ExpedienteNewDTO dto)
        {
            Expediente Expediente = _mapper.Map<Expediente>(dto);
            ExpedienteValidatorService validator = new();
            ValidationResult result = validator.Validate(Expediente);
            if (result.IsValid)
            {
                _repository.Agregar(Expediente);
                return _mapper.Map<ExpedienteDTO>(Expediente);
            }
            else
            {
                return ExpedienteDTO.ToError(
                    result.ToString(", "));
            }
        }

        public ExpedienteDTO Editar(ExpedienteDTO dto)
        {
            Expediente Expediente = _mapper.Map<Expediente>(dto);
            ExpedienteValidatorService validator = new();
            ValidationResult result = validator.Validate(Expediente);
            if (result.IsValid)
            {
                _repository.Editar(Expediente);
                return _mapper.Map<ExpedienteDTO>(Expediente);
            }
            else
            {
                return ExpedienteDTO.ToError(
                    result.ToString(", "));
            }
        }

        public ExpedienteDTO Eliminar(int id)
        {
            Expediente Expediente = _repository.ConsultarPorId(id);
            ExpedienteValidatorService validator = new();
            ValidationResult result = validator.Validate(Expediente);
            if (result.IsValid)
            {
                _repository.Eliminar(Expediente);
                return _mapper.Map<ExpedienteDTO>(Expediente);
            }
            else
            {
                return ExpedienteDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
