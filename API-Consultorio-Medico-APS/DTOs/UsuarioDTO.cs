
namespace API_Consultorio_Medico_APS.DTOs
{
    public class UsuarioNewDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public bool Status {  get; set; }
        public string User { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
    }

    public class UsuarioDTO : UsuarioNewDTO
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;

        public static UsuarioDTO ToError(string error)
        {
            return new UsuarioDTO
            {
                Error = error,
                Success = false
            };
        }
    } 
}
