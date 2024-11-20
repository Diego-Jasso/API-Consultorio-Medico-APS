using System.ComponentModel.DataAnnotations;

namespace API_Consultorio_Medico_APS.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string User { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public byte[] passwordHasH { get; set; } = [];
        public byte[] passwordSalt { get; set; } = [];
    }
}
