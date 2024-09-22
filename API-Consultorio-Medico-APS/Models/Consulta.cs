using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Consultorio_Medico_APS.Models
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }
        public int Cita_Id { get; set; }
        public string Procedimiento { get; set; } = string.Empty;
        public double Costo { get; set; }
        public string Comentarios {  get; set; } = string.Empty;

        [ForeignKey("Cita_Id")]
        public virtual Cita? Cita { get; set; }
    }
}
