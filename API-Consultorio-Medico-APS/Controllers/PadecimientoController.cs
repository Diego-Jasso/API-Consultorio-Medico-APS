﻿using API_Consultorio_Medico_APS.Base.Impl;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultorio_Medico_APS.Controllers
{
    public class PadecimientoController(IPadecimientoService service) : BaseApiController
    {
        [HttpGet]

        public ActionResult<List<PadecimientoDTO>> ConsultarDTO()
        {
            return service.ConsultarDTO();
        }

        [HttpGet("{id}")]

        public ActionResult<PadecimientoDTO> ConsultarPorId(int id)
        {
            return service.ConsultarPorId(id);
        }

        [HttpPost]

        public ActionResult<PadecimientoDTO> Agregar(PadecimientoNewDTO dto)
        {
            var result = service.Agregar(dto);
            if (result.Success)
                return Ok();
            else
                return BadRequest(result.Error);
        }

        [HttpPut("{id}")]

        public ActionResult<PadecimientoDTO> Editar(PadecimientoDTO dto)
        {
            var result = service.Editar(dto);
            if (result.Success)
                return Ok();
            else
                return BadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        public ActionResult<PadecimientoDTO> Eliminar(int id)
        {
            var result = service.Eliminar(id);
            if (result.Success)
                return NoContent();
            else
                return BadRequest(result.Error);
        }
    }
}