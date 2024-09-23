using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class EmpleadoService(IEmpleadoRepository repository, IMapper mapper) : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public List<EmpleadoDTO> ConsultarDTO()
        {
            return _repository.ConsultarDTO().ToList();
        }

        public EmpleadoDTO ConsultarPorId(int id)
        {
            Empleado Empleado = _repository.ConsultarPorId(id);
            return _mapper.Map<EmpleadoDTO>(Empleado);
        }
        public EmpleadoDTO Agregar(EmpleadoNewDTO dto)
        {
            Empleado Empleado = _mapper.Map<Empleado>(dto);
            EmpleadoValidatorService validator = new();
            ValidationResult result = validator.Validate(Empleado);
            if (result.IsValid)
            {
                _repository.Agregar(Empleado);
                return _mapper.Map<EmpleadoDTO>(Empleado);
            }
            else
            {
                return EmpleadoDTO.ToError(
                    result.ToString(", "));
            }
        }

        public EmpleadoDTO Editar(EmpleadoDTO dto)
        {
            Empleado Empleado = _mapper.Map<Empleado>(dto);
            EmpleadoValidatorService validator = new();
            ValidationResult result = validator.Validate(Empleado);
            if (result.IsValid)
            {
                _repository.Editar(Empleado);
                return _mapper.Map<EmpleadoDTO>(Empleado);
            }
            else
            {
                return EmpleadoDTO.ToError(
                    result.ToString(", "));
            }
        }

        public EmpleadoDTO Eliminar(int id)
        {
            Empleado Empleado = _repository.ConsultarPorId(id);
            EmpleadoValidatorService validator = new();
            ValidationResult result = validator.Validate(Empleado);
            if (result.IsValid)
            {
                _repository.Eliminar(Empleado);
                return _mapper.Map<EmpleadoDTO>(Empleado);
            }
            else
            {
                return EmpleadoDTO.ToError(
                    result.ToString(", "));
            }
        }
    }
}
