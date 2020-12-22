using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Dtos;
using Modelos;
using Negocio.Paciente;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        #region Obtener

        [HttpGet]
        public async Task<ActionResult<Respuesta<List<PacienteDto>>>> ObtenerListaPaciente()
        {
            var paciente = new PacienteManager();
            var respuesta = await paciente.ObtenerListaPacienteManager();

            if (paciente == null)
                return NotFound();

            return respuesta;
        }

        [HttpGet]
        [Route("doctor")]
        public async Task<ActionResult<Respuesta<List<DoctorPacienteDto>>>> ObtenerListaDoctorPaciente()
        {
            var paciente = new PacienteManager();
            var respuesta = await paciente.ObtenerListaPacienteDoctorManager();

            if (paciente == null)
                return NotFound();

            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Respuesta<PacienteDto>>> ObtenerPaciente(int id)
        {
            var paciente = new PacienteManager();
            var respuesta = await paciente.ObtenerPacienteManager(id);

            if (paciente == null)
                return NotFound();

            return respuesta;
        }


        #endregion

        #region Registrar

        [HttpPost]
        public async Task<ActionResult<Respuesta<PacienteDto>>> RegistrarPaciente(PacienteDto paciente)
        {
            var _paciente = new PacienteManager();
            var respuesta = await _paciente.RegistrarPacienteManager(paciente);

            if (paciente == null)
                return NotFound();

            return respuesta;
        }


        [HttpPost]
        [Route("doctorpaciente")]
        public async Task<ActionResult<Respuesta<DoctorPacienteDto>>> RegistrarDoctorPaciente([FromBody] DoctorPacienteDto DoctorPaciente )
        {
            var _paciente = new PacienteManager();
            var respuesta = await _paciente.RegistrarDoctorPacienteManager(DoctorPaciente);

            if (respuesta == null)
                return NotFound();

            return respuesta;
        }

        #endregion

        #region Actualizar

        [HttpPut("{id}")]
        public async Task<ActionResult<Respuesta<PacienteDto>>> ActualizarPaciente(int id, PacienteDto paciente)
        {
            var _paciente = new PacienteManager();
            var respuesta = await _paciente.ActualizarPacienteManager(id,paciente);

            if (paciente == null)
            {
                return NotFound();
            }

            return respuesta;
        }


        #endregion

        #region Borrar

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Respuesta<PacienteDto>>> BorrarPaciente(int id)
        {
            var respuesta = new PacienteManager();
            var paciente = await respuesta.BorrarPacienteManager(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        [HttpDelete]
        public async Task<ActionResult<Respuesta<DoctorPacienteDto>>> BorrarDoctorPaciente(DoctorPacienteDto doctorPaciente)
        {
            var respuesta = new PacienteManager();
            var paciente = await respuesta.BorrarDoctorPacienteManager(doctorPaciente);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        #endregion


    }
}
