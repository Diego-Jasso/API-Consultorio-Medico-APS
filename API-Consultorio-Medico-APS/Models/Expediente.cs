using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Consultorio_Medico_APS.Models
{
    public class Expediente
    {
        [Key]
        public int Id { get; set; }
        public int Paciente_Id { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Alergias { get; set; } = string.Empty;
        public string Estudios {  get; set; } = string.Empty;

        [ForeignKey("Paciente_Id")]
        public virtual Paciente? Paciente { get; set; }
    }
}
