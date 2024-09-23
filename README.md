# API-Consultorio-Medico-APS

## Overview
Esta API se conecta directamente a nuestro front creado con React.

## API Endpoints
A continuación se muestran los endpoints del API

##Cita
  GET /api/Cita
  GET /api/Cita/id
  POST /api/Cita
  PUT /api/Cita/id
  DELETE /api/Cita/id

##Consulta
  GET /api/Consulta
  GET /api/Consulta/id
  POST /api/Consulta
  PUT /api/Consulta/id
  DELETE /api/Consulta/id

##DetalleConsulta
  GET /api/DetalleConsulta
  GET /api/DetalleConsulta/id
  POST /api/DetalleConsulta
  PUT /api/DetalleConsulta/id
  DELETE /api/DetalleConsulta/id
  
##Empleado
  GET /api/Empleado
  GET /api/Empleado/id
  POST /api/Empleado
  PUT /api/Empleado/id
  DELETE /api/Empleado/id

##Exp_Pad
  GET /api/Exp_Pad
  GET /api/Exp_Pad/id
  POST /api/Exp_Pad
  PUT /api/Exp_Pad/id
  DELETE /api/Exp_Pad/id

##Expediente
  GET /api/Expediente
  GET /api/Expediente/id
  POST /api/Expediente
  PUT /api/Expediente/id
  DELETE /api/Expediente/id

##Paciente
  GET /api/Paciente
  GET /api/Paciente/id
  POST /api/Paciente
  PUT /api/Paciente/id
  DELETE /api/Paciente/id

##Padecimiento
  GET /api/Padecimiento
  GET /api/Padecimiento/id
  POST /api/Padecimiento
  PUT /api/Padecimiento/id
  DELETE /api/Padecimiento/id

#Modelos
A continuación se muestran los DTOs en formato JSON de los modelos que se utilizan en cada end point 

##Cita
{
    "paciente_Id": 0,
    "empleado_Id": 0,
    "fecha": "2024-09-23T02:47:47.818Z",
    "tipoCita": "string",
    "asistencia": "string",
    "id": 0,
    "nombreEmpleado": "string",
    "aPaternoEmpleado": "string",
    "aMaternoEmpleado": "string",
    "nombrePaciente": "string",
    "aPaternoPaciente": "string",
    "aMaternoPaciente": "string",
    "success": true,
    "error": "string"
}
  
##Consulta
{
    "cita_Id": 0,
    "procedimiento": "string",
    "costo": 0,
    "comentarios": "string",
    "id": 0,
    "success": true,
    "error": "string"
}

##DetalleConsulta
{
    "consulta_Id": 0,
    "padecimiento": "string",
    "tratamiento": "string",
    "duracion": "00:00:00",
    "comentarios": "string",
    "id": 0,
    "success": true,
    "error": "string"
}
  
##Empleado
{
    "tipoEmp": "string",
    "salario": 0,
    "nombre": "string",
    "aPaterno": "string",
    "aMaterno": "string",
    "curp": "string",
    "rfc": "string",
    "numSeguro": "string",
    "usuario": "string",
    "contraseña": "string",
    "id": 0,
    "success": true,
    "error": "string"
}

##Exp_Pad
{
    "expediente_Id": 0,
    "padecimiento_Id": 0,
    "id": 0,
    "success": true,
    "error": "string"
}

##Expediente
{
    "paciente_Id": 0,
    "altura": 0,
    "peso": 0,
    "alergias": "string",
    "estudios": "string",
    "id": 0,
    "nombre": "string",
    "aPaterno": "string",
    "aMaterno": "string",
    "success": true,
    "error": "string"
}
  
##Paciente
{
    "nombre": "string",
    "aPaterno": "string",
    "aMaterno": "string",
    "numTelefono": "string",
    "correo": "string",
    "historialMed": "string",
    "fechaNac": '1900-01-01',
    "usuario": "string",
    "contraseña": "string",
    "id": 0,
    "success": true,
    "error": "string"
}

##Padecimiento
{
    "descripcion": "string",
    "id": 0,
    "success": true,
    "error": "string"
}
