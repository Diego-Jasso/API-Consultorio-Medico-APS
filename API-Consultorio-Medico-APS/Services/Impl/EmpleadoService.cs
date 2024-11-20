using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class EmpleadoService(IEmpleadoRepository repository, IUsuarioRepository usuarioRepository, IMapper mapper) : IEmpleadoService
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

        public List<TimeOnly> ConsultarHorario(int id, DateOnly date)
        {
            return _repository.ConsultarHorario(id,date).ToList();
        }

        public EmpleadoDTO Agregar(EmpleadoNewDTO dto)
        {
            Empleado Empleado = _mapper.Map<Empleado>(dto);
            ConvertirPass(Empleado, dto.Contraseña);
            Empleado.Status = true;
            EmpleadoValidatorService validator = new(usuarioRepository);
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
            Empleado Empleado = _repository.ConsultarPorId(dto.Id);
            _mapper.Map(dto, Empleado);
            Empleado.passwordSalt = Empleado.passwordSalt;
            Empleado.passwordHasH = Empleado.passwordHasH;
            EmpleadoValidatorService validator = new(usuarioRepository);
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

        public EmpleadoDTO DarDeBaja(int id)
        {
            Empleado empleado = _repository.ConsultarPorId(id);
            empleado.Status = false;
            EmpleadoValidatorService validator = new(usuarioRepository);
            ValidationResult result = validator.Validate(empleado);
            if (result.IsValid)
            {
                _repository.Editar(empleado);
                return _mapper.Map<EmpleadoDTO>(empleado);
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
            EmpleadoValidatorService validator = new(usuarioRepository);
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
        private static void ConvertirPass(Empleado empleado, string pass)
        {
            var password = Password.Convertir(pass);
            empleado.passwordHasH = password.passwordHasH;
            empleado.passwordSalt = password.passwordSalt;
        }
    }
}
