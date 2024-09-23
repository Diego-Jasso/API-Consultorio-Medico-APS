using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class CitaService(ICitaRepository repository, IMapper mapper) : ICitaService
    {
        private readonly ICitaRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<CitaDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public CitaDTO ConsultarPorId(int id)
        {
            Cita cita = _repository.ConsultarPorId(id);
            return _mapper.Map<CitaDTO>(cita);
        }
        public CitaDTO Agregar(CitaNewDTO dto)
        {
            Cita Cita = _mapper.Map<Cita>(dto);
            CitaValidatorService validator = new();
            ValidationResult result = validator.Validate(Cita);
            if (result.IsValid)
            {
                _repository.Agregar(Cita);
                return _mapper.Map<CitaDTO>(Cita);
            }
            else
            {
                return CitaDTO.ToError(
                    result.ToString(", "));
            }
        }

        public CitaDTO Editar(CitaDTO dto)
        {
            Cita Cita = _mapper.Map<Cita>(dto);
            CitaValidatorService validator = new();
            ValidationResult result = validator.Validate(Cita);
            if (result.IsValid)
            {
                _repository.Editar(Cita);
                return _mapper.Map<CitaDTO>(Cita);
            }
            else
            {
                return CitaDTO.ToError(
                    result.ToString(", "));
            }
        }

        public CitaDTO Eliminar(int id)
        {
            Cita Cita = _repository.ConsultarPorId(id);
            CitaValidatorService validator = new();
            ValidationResult result = validator.Validate(Cita);
            if (result.IsValid)
            {
                _repository.Eliminar(Cita);
                return _mapper.Map<CitaDTO>(Cita);
            }
            else
            {
                return CitaDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
