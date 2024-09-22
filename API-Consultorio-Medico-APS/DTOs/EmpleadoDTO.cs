namespace API_Consultorio_Medico_APS.DTOs
{
    public class EmpleadoNewDTO
    {
        public string TipoEmp { get; set; } = string.Empty;
        public double Salario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string APaterno { get; set; } = string.Empty;
        public string AMaterno { get; set; } = string.Empty;
        public string Curp { get; set; } = string.Empty;
        public string RFC { get; set; } = string.Empty;
        public string NumSeguro { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
    }
    public class EmpleadoDTO: EmpleadoNewDTO
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static EmpleadoDTO ToError(string error)
        {
            return new EmpleadoDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
