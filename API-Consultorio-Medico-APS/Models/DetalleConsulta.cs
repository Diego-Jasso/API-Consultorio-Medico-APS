using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Consultorio_Medico_APS.Models
{
    public class DetalleConsulta
    {
        [Key]
        public int Id { get; set; }
        public int Consulta_ID { get; set; }
        public string Padecimiento { get; set; } = string.Empty;
        public string Tratamiento { get; set; } = string.Empty;   
        public TimeOnly Duracion { get; set; }
        public string Comentarios { get; set; } = string.Empty;

        [ForeignKey("Consulta_ID")]
        public virtual Consulta? Consulta { get; set; }
    }
}
