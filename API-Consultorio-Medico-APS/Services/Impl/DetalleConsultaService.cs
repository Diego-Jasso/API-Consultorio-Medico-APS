using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace API_Consultorio_Medico_APS.Services.Impl
{
    public class DetalleConsultaService(IDetalleConsultaRepository repository,IPadecimientoService service,IExpedienteService expedienteService,IExp_PadService expPadService,IMapper mapper) : IDetalleConsultaService
    {
        private readonly IDetalleConsultaRepository _repository = repository;
        private readonly IPadecimientoService _service = service;
        private readonly IExpedienteService _expedienteService = expedienteService;
        private readonly IExp_PadService _expPadService = expPadService;
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
                int idPad;
                int idExp;
                _repository.Agregar(DetalleConsulta);
                PadecimientoDTO Padecimiento = _service.ConsultarPorNombre(dto.Padecimiento);
                if (Padecimiento == null)
                {
                    PadecimientoNewDTO pad = new();
                    pad.Descripcion = dto.Padecimiento;
                    var resultPadecimiento = _service.Agregar(pad);
                    if (!resultPadecimiento.Success)
                        return DetalleConsultaDTO.ToError("Eror al intentar crear el Padecimiento.");
                    idPad = resultPadecimiento.Id;
                }
                else
                    idPad = Padecimiento.Id;
                Cita Cita = _repository.ConsultarCitaDesdeDetalle(DetalleConsulta.Id);
                ExpedienteDTO expediente = _expedienteService.ConsultarPorPacienteId(Cita.Paciente_Id);
                if (expediente == null)
                {
                    ExpedienteNewDTO exp = new();
                    exp.Paciente_Id = Cita.Paciente_Id;
                    var resultExpediente = _expedienteService.Agregar(exp);
                    if (!resultExpediente.Success)
                        return DetalleConsultaDTO.ToError("Eror al intentar crear el expediente.");
                    idExp = resultExpediente.Id;
                } else
                    idExp = expediente.Id;
                Exp_PadNewDTO exp_Pad = new();
                exp_Pad.Expediente_Id = idExp;
                exp_Pad.Padecimiento_Id = idPad;
                _expPadService.Agregar(exp_Pad);
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
