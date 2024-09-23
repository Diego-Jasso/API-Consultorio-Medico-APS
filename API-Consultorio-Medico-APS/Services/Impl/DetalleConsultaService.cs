using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class DetalleConsultaService(IDetalleConsultaRepository repository, IMapper mapper) : IDetalleConsultaService
    {
        private readonly IDetalleConsultaRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<DetalleConsultaDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public DetalleConsultaDTO ConsultarPorId(int id)
        {
            DetalleConsulta DetalleConsulta = _repository.ConsultarPorId(id);
            return _mapper.Map<DetalleConsultaDTO>(DetalleConsulta);
        }
        public DetalleConsultaDTO Agregar(DetalleConsultaNewDTO dto)
        {
            DetalleConsulta DetalleConsulta = _mapper.Map<DetalleConsulta>(dto);
            DetalleConsultaValidatorService validator = new();
            ValidationResult result = validator.Validate(DetalleConsulta);
            if (result.IsValid)
            {
                _repository.Agregar(DetalleConsulta);
                return _mapper.Map<DetalleConsultaDTO>(DetalleConsulta);
            }
            else
            {
                return DetalleConsultaDTO.ToError(
                    result.ToString(", "));
            }
        }

        public DetalleConsultaDTO Editar(DetalleConsultaDTO dto)
        {
            DetalleConsulta DetalleConsulta = _mapper.Map<DetalleConsulta>(dto);
            DetalleConsultaValidatorService validator = new();
            ValidationResult result = validator.Validate(DetalleConsulta);
            if (result.IsValid)
            {
                _repository.Editar(DetalleConsulta);
                return _mapper.Map<DetalleConsultaDTO>(DetalleConsulta);
            }
            else
            {
                return DetalleConsultaDTO.ToError(
                    result.ToString(", "));
            }
        }

        public DetalleConsultaDTO Eliminar(int id)
        {
            DetalleConsulta DetalleConsulta = _repository.ConsultarPorId(id);
            DetalleConsultaValidatorService validator = new();
            ValidationResult result = validator.Validate(DetalleConsulta);
            if (result.IsValid)
            {
                _repository.Eliminar(DetalleConsulta);
                return _mapper.Map<DetalleConsultaDTO>(DetalleConsulta);
            }
            else
            {
                return DetalleConsultaDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
