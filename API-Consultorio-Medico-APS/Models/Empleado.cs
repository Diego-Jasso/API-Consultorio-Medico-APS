﻿using System.ComponentModel.DataAnnotations;

namespace API_Consultorio_Medico_APS.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string TipoEmp { get; set; } = string.Empty;
        public double Salario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string APaterno { get; set; } = string.Empty;
        public string AMaterno { get; set; } = string.Empty;
        public string Curp { get; set; } = string.Empty;
        public string RFC { get; set; } = string.Empty;
        public string NumSeguro { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public byte[] passwordHasH { get; set; } = [];
        public byte[] passwordSalt { get; set; } = [];
        public bool Status { get; set; }
        public string Correo { get; set; } = string.Empty;
    }
}
