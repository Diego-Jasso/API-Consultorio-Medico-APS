using API_Consultorio_Medico_APS.DataBase;
using API_Consultorio_Medico_APS.Mapper;
using API_Consultorio_Medico_APS.Repositories;
using API_Consultorio_Medico_APS.Repositories.Impl;
using API_Consultorio_Medico_APS.Services;
using API_Consultorio_Medico_APS.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
         connectionString ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")
    )
);

// Add respositories and services to the container.

builder.Services.AddScoped<ICitaRepository,CitaRepository>();
builder.Services.AddScoped<IConsultaRepository,ConsultaRepository>();
builder.Services.AddScoped<IDetalleConsultaRepository, DetalleConsultaRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IExp_PadRepository, Exp_PadRepository>();
builder.Services.AddScoped<IExpedienteRepository, ExpedienteRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IPadecimientoRepository, PadecimientoRepository>();

builder.Services.AddScoped<ICitaService,CitaService>();
builder.Services.AddScoped<IConsultaService,ConsultaService>();
builder.Services.AddScoped<IDetalleConsultaService, DetalleConsultaService>();
builder.Services.AddScoped<IEmpleadoService,EmpleadoService>();
builder.Services.AddScoped<IExp_PadService,Exp_PadService>();
builder.Services.AddScoped<IExpedienteService,ExpedienteService>();
builder.Services.AddScoped<IPacienteService,PacienteService>();
builder.Services.AddScoped<IPadecimientoService,PadecimientoService>();

//Add controllers.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add auto mapper
builder.Services.AddAutoMapper(typeof(MapperCode));


//Add cors configuration
string corsConfiguration = "_corsConfiguration";
string url = "https://localhost:3000";

builder.Services.AddCors(options =>
    options.AddPolicy(name: corsConfiguration,
        cors => cors.WithOrigins(url)
        .AllowAnyHeader()
        .AllowAnyMethod()
    )
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsConfiguration);

app.UseAuthorization();

app.MapControllers();

app.Run();
