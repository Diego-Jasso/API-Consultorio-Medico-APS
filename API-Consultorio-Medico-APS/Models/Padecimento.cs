using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace API_Consultorio_Medico_APS.Models
{
    public class Padecimiento
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
