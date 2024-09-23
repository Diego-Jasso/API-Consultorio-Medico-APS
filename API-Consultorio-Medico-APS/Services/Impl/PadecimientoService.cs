using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class PadecimientoService(IPadecimientoRepository repository, IMapper mapper) : IPadecimientoService
    {
        private readonly IPadecimientoRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<PadecimientoDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public PadecimientoDTO ConsultarPorId(int id)
        {
            Padecimiento Padecimiento = _repository.ConsultarPorId(id);
            return _mapper.Map<PadecimientoDTO>(Padecimiento);
        }
        public PadecimientoDTO Agregar(PadecimientoNewDTO dto)
        {
            Padecimiento Padecimiento = _mapper.Map<Padecimiento>(dto);
            PadecimientoValidatorService validator = new();
            ValidationResult result = validator.Validate(Padecimiento);
            if (result.IsValid)
            {
                _repository.Agregar(Padecimiento);
                return _mapper.Map<PadecimientoDTO>(Padecimiento);
            }
            else
            {
                return PadecimientoDTO.ToError(
                    result.ToString(", "));
            }
        }

        public PadecimientoDTO Editar(PadecimientoDTO dto)
        {
            Padecimiento Padecimiento = _mapper.Map<Padecimiento>(dto);
            PadecimientoValidatorService validator = new();
            ValidationResult result = validator.Validate(Padecimiento);
            if (result.IsValid)
            {
                _repository.Editar(Padecimiento);
                return _mapper.Map<PadecimientoDTO>(Padecimiento);
            }
            else
            {
                return PadecimientoDTO.ToError(
                    result.ToString(", "));
            }
        }

        public PadecimientoDTO Eliminar(int id)
        {
            Padecimiento Padecimiento = _repository.ConsultarPorId(id);
            PadecimientoValidatorService validator = new();
            ValidationResult result = validator.Validate(Padecimiento);
            if (result.IsValid)
            {
                _repository.Eliminar(Padecimiento);
                return _mapper.Map<PadecimientoDTO>(Padecimiento);
            }
            else
            {
                return PadecimientoDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
