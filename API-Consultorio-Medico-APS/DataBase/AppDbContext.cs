using API_Consultorio_Medico_APS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Consultorio_Medico_APS.DataBase
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Paciente> Paciente { get; set; } = default!;
        public DbSet<Empleado> Empleado { get; set; } = default!;
        public DbSet<Padecimiento> Padecimiento { get; set; } = default!;
        public DbSet<Expediente> Expediente { get; set; } = default!;
        public DbSet<Exp_Pad> Exp_Pad { get; set; } = default!;
        public DbSet<Cita> Cita { get; set; } = default!;
        public DbSet<Consulta> Consulta { get; set; } = default!;
        public DbSet<DetalleConsulta> DetalleConsulta { get; set; } = default!;
        public DbSet<TipoDeCita> TipoDeCita { get; set; } = default!;

    }
}
