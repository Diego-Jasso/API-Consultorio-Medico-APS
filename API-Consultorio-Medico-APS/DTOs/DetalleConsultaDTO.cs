namespace API_Consultorio_Medico_APS.DTOs
{
    public class DetalleConsultaNewDTO
    {
        public int Consulta_Id { get; set; }
        public string Padecimiento { get; set; } = string.Empty;
        public string Tratamiento { get; set; } = string.Empty;
        public TimeOnly Duracion { get; set; }
        public string Comentarios { get; set; } = string.Empty;
    }
    public class DetalleConsultaDTO:DetalleConsultaNewDTO
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static DetalleConsultaDTO ToError(string error)
        {
            return new DetalleConsultaDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
