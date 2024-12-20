﻿using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Models;
using API_Consultorio_Medico_APS.Base;

namespace API_Consultorio_Medico_APS.Repositories
{
    public interface IExpedienteRepository : IBaseRepository<Expediente>
    {
        IEnumerable<ExpedienteDTO> ConsultarDTO();
        Expediente ConsultarPorId(int id);
        Expediente ConsultarPorPacienteId(int id);
    }
}
