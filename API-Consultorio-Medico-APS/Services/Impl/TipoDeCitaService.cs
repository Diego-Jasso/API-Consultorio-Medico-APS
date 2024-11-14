using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class TipoDeCitaService(ITipoDeCitaRepository repository,IMapper mapper): ITipoDeCitaService
    {
        private readonly ITipoDeCitaRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<TipoDeCitaDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public TipoDeCitaDTO ConsultarPorId(int id)
        {
            TipoDeCita TipoDeCita = _repository.ConsultarPorId(id);
            return _mapper.Map<TipoDeCitaDTO>(TipoDeCita);
        }
        public TipoDeCitaDTO Agregar(TipoDeCitaNewDTO dto)
        {
            TipoDeCita TipoDeCita = _mapper.Map<TipoDeCita>(dto);
            TipoDeCitaValidatorService validator = new();
            ValidationResult result = validator.Validate(TipoDeCita);
            if (result.IsValid)
            {
                _repository.Agregar(TipoDeCita);
                return _mapper.Map<TipoDeCitaDTO>(TipoDeCita);
            }
            else
            {
                return TipoDeCitaDTO.ToError(
                    result.ToString(", "));
            }
        }

        public TipoDeCitaDTO Editar(TipoDeCitaDTO dto)
        {
            TipoDeCita TipoDeCita = _mapper.Map<TipoDeCita>(dto);
            TipoDeCitaValidatorService validator = new();
            ValidationResult result = validator.Validate(TipoDeCita);
            if (result.IsValid)
            {
                _repository.Editar(TipoDeCita);
                return _mapper.Map<TipoDeCitaDTO>(TipoDeCita);
            }
            else
            {
                return TipoDeCitaDTO.ToError(
                    result.ToString(", "));
            }
        }

        public TipoDeCitaDTO Eliminar(int id)
        {
            TipoDeCita TipoDeCita = _repository.ConsultarPorId(id);
            TipoDeCitaValidatorService validator = new();
            ValidationResult result = validator.Validate(TipoDeCita);
            if (result.IsValid)
            {
                _repository.Eliminar(TipoDeCita);
                return _mapper.Map<TipoDeCitaDTO>(TipoDeCita);
            }
            else
            {
                return TipoDeCitaDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
