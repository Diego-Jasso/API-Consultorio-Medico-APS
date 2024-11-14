using API_Consultorio_Medico_APS.Base.Impl;
using API_Consultorio_Medico_APS.DTOs;
using API_Consultorio_Medico_APS.Services;
using API_Consultorio_Medico_APS.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultorio_Medico_APS.Controllers
{
    public class DetalleConsultaController(IDetalleConsultaService service,IPadecimientoService PadecimientoService) : BaseApiController
    {
        [HttpGet]

        public ActionResult<List<DetalleConsultaDTO>> ConsultarDTO()
        {
            return service.ConsultarDTO();
        }

        [HttpGet("{id}")]

        public ActionResult<DetalleConsultaDTO> ConsultarPorId(int id)
        {
            return service.ConsultarPorId(id);
        }

        [HttpPost]

        public ActionResult<DetalleConsultaDTO> Agregar(DetalleConsultaNewDTO dto)
        {
            var result = service.Agregar(dto);
            if (result.Success)
                return Ok();
            else
                return BadRequest(result.Error);
        }

        [HttpPut("{id}")]

        public ActionResult<DetalleConsultaDTO> Editar(DetalleConsultaDTO dto)
        {
            var result = service.Editar(dto);
            if (result.Success)
                return Ok();
            else
                return BadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        public ActionResult<DetalleConsultaDTO> Eliminar(int id)
        {
            var result = service.Eliminar(id);
            if (result.Success)
                return NoContent();
            else
                return BadRequest(result.Error);
        }
    }
}
