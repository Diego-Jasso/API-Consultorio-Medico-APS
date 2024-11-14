namespace API_Consultorio_Medico_APS.DTOs
{
    public class TipoDeCitaNewDTO
    {
        public string Descripcion { get; set; } = string.Empty;
    }

    public class TipoDeCitaDTO : TipoDeCitaNewDTO
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static TipoDeCitaDTO ToError(string error)
        {
            return new TipoDeCitaDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
