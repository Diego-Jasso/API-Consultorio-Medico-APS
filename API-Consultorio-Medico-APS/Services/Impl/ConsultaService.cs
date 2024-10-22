using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class ConsultaService(IConsultaRepository repository,ICitaRepository citaRepository,ICitaService service, IMapper mapper) : IConsultaService
    {
        private readonly IConsultaRepository _repository = repository;
        private readonly ICitaRepository _citaRepository = citaRepository;
        private readonly ICitaService _service = service;
        private readonly IMapper _mapper = mapper;

        public List<ConsultaDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public ConsultaDTO ConsultarPorId(int id)
        {
            Consulta Consulta = _repository.ConsultarPorId(id);
            return _mapper.Map<ConsultaDTO>(Consulta);
        }
        public ConsultaDTO Agregar(ConsultaNewDTO dto)
        {
            Consulta Consulta = _mapper.Map<Consulta>(dto);
            ConsultaValidatorService validator = new();
            ValidationResult result = validator.Validate(Consulta);
            if (result.IsValid)
            {
                _repository.Agregar(Consulta);
                Cita cita = _citaRepository.ConsultarPorId(Consulta.Cita_Id);
                cita.Status = false;
                _citaRepository.Editar(cita);
                return _mapper.Map<ConsultaDTO>(Consulta);
            }
            else
            {
                return ConsultaDTO.ToError(
                    result.ToString(", "));
            }
        }

        public ConsultaDTO Editar(ConsultaDTO dto)
        {
            Consulta Consulta = _mapper.Map<Consulta>(dto);
            ConsultaValidatorService validator = new();
            ValidationResult result = validator.Validate(Consulta);
            if (result.IsValid)
            {
                _repository.Editar(Consulta);
                return _mapper.Map<ConsultaDTO>(Consulta);
            }
            else
            {
                return ConsultaDTO.ToError(
                    result.ToString(", "));
            }
        }

        public ConsultaDTO Eliminar(int id)
        {
            Consulta Consulta = _repository.ConsultarPorId(id);
            ConsultaValidatorService validator = new();
            ValidationResult result = validator.Validate(Consulta);
            if (result.IsValid)
            {
                _repository.Eliminar(Consulta);
                return _mapper.Map<ConsultaDTO>(Consulta);
            }
            else
            {
                return ConsultaDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
