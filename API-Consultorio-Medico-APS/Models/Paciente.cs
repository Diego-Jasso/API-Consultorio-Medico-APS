using System.ComponentModel.DataAnnotations;

namespace API_Consultorio_Medico_APS.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string APaterno { get; set; } = string.Empty;    
        public string AMaterno { get; set; } = string.Empty;
        public string NumTelefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty; 
        public string HistorialMed { get; set; } = string.Empty;
        public DateOnly FechaNac { get; set; } 
        public string Usuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
