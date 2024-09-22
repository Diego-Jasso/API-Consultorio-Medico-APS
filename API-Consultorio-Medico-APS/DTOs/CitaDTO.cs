namespace API_Consultorio_Medico_APS.DTOs
{
    public class CitaNewDTO
    {
        public int Paciente_Id { get; set; }
        public int Empleado_Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoCita { get; set; } = string.Empty;
        public string Asistencia { get; set; } = string.Empty;
    }
    public class CitaDTO : CitaNewDTO
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; } = string.Empty;
        public string APaternoEmpleado { get; set; } = string.Empty;
        public string AMaternoEmpleado { get; set; } = string.Empty;
        public string NombrePaciente { get; set; } = string.Empty;
        public string APaternoPaciente { get; set; } = string.Empty;
        public string AMaternoPaciente { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static CitaDTO ToError(string error)
        {
            return new CitaDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
