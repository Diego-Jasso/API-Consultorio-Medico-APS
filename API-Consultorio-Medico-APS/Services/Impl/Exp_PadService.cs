using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class Exp_PadService(IExp_PadRepository repository, IMapper mapper) : IExp_PadService
    {
        private readonly IExp_PadRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<Exp_PadDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public Exp_PadDTO ConsultarPorId(int id)
        {
            Exp_Pad Exp_Pad = _repository.ConsultarPorId(id);
            return _mapper.Map<Exp_PadDTO>(Exp_Pad);
        }
        public Exp_PadDTO Agregar(Exp_PadNewDTO dto)
        {
            Exp_Pad Exp_Pad = _mapper.Map<Exp_Pad>(dto);
            Exp_PadValidatorService validator = new();
            ValidationResult result = validator.Validate(Exp_Pad);
            if (result.IsValid)
            {
                _repository.Agregar(Exp_Pad);
                return _mapper.Map<Exp_PadDTO>(Exp_Pad);
            }
            else
            {
                return Exp_PadDTO.ToError(
                    result.ToString(", "));
            }
        }

        public Exp_PadDTO Editar(Exp_PadDTO dto)
        {
            Exp_Pad Exp_Pad = _mapper.Map<Exp_Pad>(dto);
            Exp_PadValidatorService validator = new();
            ValidationResult result = validator.Validate(Exp_Pad);
            if (result.IsValid)
            {
                _repository.Editar(Exp_Pad);
                return _mapper.Map<Exp_PadDTO>(Exp_Pad);
            }
            else
            {
                return Exp_PadDTO.ToError(
                    result.ToString(", "));
            }
        }

        public Exp_PadDTO Eliminar(int id)
        {
            Exp_Pad Exp_Pad = _repository.ConsultarPorId(id);
            Exp_PadValidatorService validator = new();
            ValidationResult result = validator.Validate(Exp_Pad);
            if (result.IsValid)
            {
                _repository.Eliminar(Exp_Pad);
                return _mapper.Map<Exp_PadDTO>(Exp_Pad);
            }
            else
            {
                return Exp_PadDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
