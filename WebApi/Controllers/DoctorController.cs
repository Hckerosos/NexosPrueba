using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Dtos;
using Modelos;
using Negocio.Doctor;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        #region Obtener

        [HttpGet]
        public async Task<ActionResult<Respuesta<DoctorDto>>> ObtenerListaDoctor()
        {
            var respuesta = new DoctorManager();
            var paciente = await respuesta.ObtenerListaDoctorManager();

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Respuesta<DoctorDto>>> ObtenerDoctor(int id)
        {
            var respuesta = new DoctorManager();
            var paciente = await respuesta.ObtenerDoctorManager(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }


        #endregion

        #region Registrar

        [HttpPost]
        public async Task<ActionResult<Respuesta<DoctorDto>>> RegistrarDoctor(DoctorDto doctor)
        {
            var respuesta = new DoctorManager();
            var paciente = await respuesta.RegistrarDoctorManager(doctor);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        #endregion

        #region Actualizar

        [HttpPut("{id}")]
        public async Task<ActionResult<Respuesta<DoctorDto>>> ActualizarDoctor(int id, DoctorDto doctor)
        {
            var respuesta = new DoctorManager();
            var paciente = await respuesta.RegistrarDoctorManager(doctor);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }


        #endregion

        #region Borrar

        [HttpDelete("{id}")]
        public async Task<ActionResult<Respuesta<DoctorDto>>> BorrarDoctor(int id)
        {
            var respuesta = new DoctorManager();
            var paciente = await respuesta.BorrarDoctorManager(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        #endregion
    }
}
