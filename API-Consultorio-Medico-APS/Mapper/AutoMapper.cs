using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using AutoMapper;

namespace API_Consultorio_Medico_APS.Mapper
{
    public class MapperCode : Profile
    {
        public MapperCode() {
            CreateMap<CitaNewDTO, Cita>();
            CreateMap<CitaDTO,Cita>().ReverseMap();
            CreateMap<ConsultaNewDTO,Consulta>();
            CreateMap<ConsultaDTO,Consulta>().ReverseMap();
            CreateMap<DetalleConsultaNewDTO,DetalleConsulta>();
            CreateMap<DetalleConsultaDTO,DetalleConsulta>().ReverseMap();
            CreateMap<EmpleadoNewDTO,Empleado>();
            CreateMap<EmpleadoDTO,Empleado>().ReverseMap();
            CreateMap<Exp_PadNewDTO, Exp_Pad>();
            CreateMap<Exp_PadDTO, Exp_Pad>().ReverseMap();
            CreateMap<PacienteNewDTO,Paciente>();
            CreateMap<PacienteDTO,Paciente>().ReverseMap();
            CreateMap<ExpedienteNewDTO,Expediente>();
            CreateMap<ExpedienteDTO,Expediente>().ReverseMap();
            CreateMap<PadecimientoNewDTO,Padecimiento>();
            CreateMap<PadecimientoDTO,Padecimiento>().ReverseMap();
        }
    }
}
