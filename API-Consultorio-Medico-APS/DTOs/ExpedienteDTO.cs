namespace API_Consultorio_Medico_APS.DTOs
{
    public class ExpedienteNewDTO
    {
        public int Paciente_Id { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Alergias { get; set; } = string.Empty;
        public string Estudios { get; set; } = string.Empty;

    }
    public class ExpedienteDTO:ExpedienteNewDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string APaterno { get; set; } = string.Empty;
        public string AMaterno { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static ExpedienteDTO ToError(string error)
        {
            return new ExpedienteDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
