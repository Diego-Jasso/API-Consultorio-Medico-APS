namespace API_Consultorio_Medico_APS.DTOs
{
    public class ConsultaConDetalleDTO
    {
        public ConsultaNewDTO Consulta { get; set; } = new();

        public List<DetalleConsultaNewDTO> Detalles { get; set; } = [];
    }
}
