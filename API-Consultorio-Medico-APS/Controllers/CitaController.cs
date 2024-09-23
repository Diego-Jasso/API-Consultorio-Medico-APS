using API_Consultorio_Medico_APS.Base.Impl;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultorio_Medico_APS.Controllers
{
    public class CitaController(ICitaService service) : BaseApiController
    {
        [HttpGet]

        public ActionResult<List<CitaDTO>> ConsultarDTO()
        {
            return service.ConsultarDTO();
        }

        [HttpGet("{id}")]

        public ActionResult<CitaDTO> ConsultarPorId(int id)
        {
            return service.ConsultarPorId(id);
        }

        [HttpPost]

        public ActionResult<CitaDTO> Agregar(CitaNewDTO dto)
        {
            var result = service.Agregar(dto);
            if (result.Success)
                return Ok();
            else
                return BadRequest(result.Error);
        }

        [HttpPut("{id}")]

        public ActionResult<CitaDTO> Editar(CitaDTO dto)
        {
            var result = service.Editar(dto);
            if (result.Success)
                return Ok();
            else
                return BadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        public ActionResult<CitaDTO> Eliminar(int id)
        {
            var result = service.Eliminar(id);
            if (result.Success)
                return NoContent();
            else
                return BadRequest(result.Error);
        }
    }
}
