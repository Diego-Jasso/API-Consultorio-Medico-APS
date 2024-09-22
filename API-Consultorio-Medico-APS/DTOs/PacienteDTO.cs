namespace API_Consultorio_Medico_APS.DTOs
{
    public class PacienteNewDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string APaterno { get; set; } = string.Empty;
        public string AMaterno { get; set; } = string.Empty;
        public string NumTelefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string HistorialMed { get; set; } = string.Empty;
        public DateOnly FechaNac { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
    }
    public class PacienteDTO: PacienteNewDTO
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static PacienteDTO ToError(string error)
        {
            return new PacienteDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
