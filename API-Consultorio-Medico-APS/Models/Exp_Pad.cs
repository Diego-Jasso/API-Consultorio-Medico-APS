using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Consultorio_Medico_APS.Models
{
    public class Exp_Pad
    {
        [Key]
        public int Id { get; set; }
        public int Expediente_Id { get; set; }
        public int Padecimiento_Id { get; set; }

        [ForeignKey("Expediente_Id")]
        public virtual Expediente? Expediente { get; set; }

        [ForeignKey("Padecimiento_Id")]
        public virtual Padecimiento? Padecimiento { get; set; }
    }
}
