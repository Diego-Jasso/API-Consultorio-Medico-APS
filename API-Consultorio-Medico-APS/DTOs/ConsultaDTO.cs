namespace API_Consultorio_Medico_APS.DTOs
{
    public class ConsultaNewDTO
    {
        public int Cita_Id { get; set; }
        public string Procedimiento { get; set; } = string.Empty;
        public double Costo { get; set; }
        public string Comentarios { get; set; } = string.Empty;
    }
    public class ConsultaDTO:ConsultaNewDTO
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static ConsultaDTO ToError(string error)
        {
            return new ConsultaDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
