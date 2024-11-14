using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Consultorio_Medico_APS.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public int Paciente_Id { get; set; }
        public int Empleado_Id { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public int TipoCita { get; set; } 
        public string Asistencia { get; set; } = string.Empty;
        public bool Status { get; set; }


        [ForeignKey("Paciente_Id")]
        public virtual Paciente? Paciente { get; set; }

        [ForeignKey("Empleado_Id")]
        public virtual Empleado? Empleado { get; set; }

        [ForeignKey("TipoCita")]
        public virtual TipoDeCita? TipoDeCita { get; set; }
    }
}
