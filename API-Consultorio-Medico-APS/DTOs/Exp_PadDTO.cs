namespace API_Consultorio_Medico_APS.DTOs
{
    public class Exp_PadNewDTO
    {
        public int Expediente_Id { get; set; }
        public int Padecimiento_Id { get; set; }
    }

    public class Exp_PadDTO: Exp_PadNewDTO
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public static Exp_PadDTO ToError(string error)
        {
            return new Exp_PadDTO
            {
                Error = error,
                Success = false
            };
        }
    }
}
