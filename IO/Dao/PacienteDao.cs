using IO.Models;
using Modelo.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IO.Dao
{
   public class PacienteDao
    {
        #region Obtener
        public static async Task<List<PacienteDto>> ObtenerListaPaciente()
        {
            var respuesta = new List<PacienteDto>();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var lista = await bd.Pacientes.ToListAsync();

                    foreach (var row in lista)
                        respuesta.Add(new PacienteDto { IdPaciente = row.IdPaciente, Nombre = row.Nombre, Edad = row.Edad, Identificacion = row.Identificacion, Correo = row.Correo,Seguro=row.Seguro });

                    return respuesta;
                }

            }
            catch (Exception ex)
            {

                return null;

            }

        }

        public static async Task<PacienteDto> ObtenerPaciente(int id)
        {
            var respuesta = new PacienteDto();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var paciente = await bd.Pacientes.FirstAsync(d => d.IdPaciente == id);
                    respuesta.Identificacion = paciente.Identificacion;
                    respuesta.Nombre = paciente.Nombre;
                    respuesta.Edad = paciente.Edad;
                    respuesta.Identificacion = paciente.Identificacion;
                    respuesta.Correo = paciente.Correo;
                    respuesta.Seguro = paciente.Seguro;
                    return respuesta;
                }

            }
            catch (Exception ex)
            {

                return null;

            }

        }

        #endregion

        #region Registrar

        public static async Task<PacienteDto> RegistrarPaciente(PacienteDto paciente)
        {
            var _paciente = new Paciente();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    _paciente.Nombre = paciente.Nombre;
                    _paciente.Edad = paciente.Edad;
                    _paciente.Identificacion = paciente.Identificacion;
                    _paciente.Correo = paciente.Correo;
                    _paciente.Seguro = paciente.Seguro;

                    bd.Pacientes.Add(_paciente);
                    await bd.SaveChangesAsync();

                    var respuesta = await bd.Pacientes.LastAsync();
                    paciente.IdPaciente = respuesta.IdPaciente;
                    paciente.Nombre = respuesta.Nombre;
                    paciente.Edad = paciente.Edad;
                    paciente.Identificacion = paciente.Identificacion;
                    paciente.Correo = paciente.Correo;
                    paciente.Seguro = paciente.Seguro;
                    return paciente;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion

        #region Actualizar

        public static async Task<PacienteDto> ActualizarPaciente(int id, PacienteDto paciente)
        {
            var _paciente = new Paciente();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var respuesta = await bd.Pacientes.FirstAsync(d => d.IdPaciente == id);
                    respuesta.IdPaciente = paciente.IdPaciente;
                    respuesta.Nombre = paciente.Nombre;
                    respuesta.Edad = paciente.Edad;
                    respuesta.Identificacion = paciente.Identificacion;
                    respuesta.Correo = paciente.Correo;
                    respuesta.Seguro = paciente.Seguro;
                    bd.SaveChanges();
                    return paciente;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        #endregion

        #region Borrrar

        public static async Task<PacienteDto> BorrarPaciente(int id)
        {
            var respuesta = new PacienteDto();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var paciente = await bd.Pacientes.FirstAsync(d => d.IdPaciente == id);
                    respuesta.IdPaciente = paciente.IdPaciente;
                    respuesta.Nombre = paciente.Nombre;
                    respuesta.Edad = paciente.Edad;
                    respuesta.Identificacion = paciente.Identificacion;
                    respuesta.Correo = paciente.Correo;
                    respuesta.Seguro = paciente.Seguro;
                    bd.Remove(paciente);
                    bd.SaveChanges();
                    return respuesta;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion

    }
}
