namespace API_Consultorio_Medico_APS.DTOs
{
    public class PadecimientoNewDTO
    {

        public string Descripcion { get; set; } = string.Empty;
    }
    public class PadecimientoDTO : PadecimientoNewDTO
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static PadecimientoDTO ToError(string error)
        {
            return new PadecimientoDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
