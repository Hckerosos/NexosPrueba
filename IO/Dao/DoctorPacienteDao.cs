using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IO.Models;
using Microsoft.EntityFrameworkCore;
using Modelo.Dtos;

namespace IO.Dao
{
    public class DoctorPacienteDao
    {
        #region Obtener
        public static async Task<List<DoctorPacienteDto>> ObtenerListaDoctorPaciente()
        {
            var respuesta = new List<DoctorPacienteDto>();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var lista = await bd.DoctorPacientes.ToListAsync();

                    foreach (var row in lista)
                        respuesta.Add(new DoctorPacienteDto { IdDoctorPaciente=row.IdDoctorPaciente,Doctor=row.Doctor,Paciente= row.Paciente });
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

        public static async Task<DoctorPacienteDto> RegistrarDoctorPaciente(DoctorPacienteDto DoctorPaciente)
        {
            var _doctorPaciente = new DoctorPaciente();
            var doctorPaciente = new DoctorPacienteDto();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    _doctorPaciente.Paciente = DoctorPaciente.Paciente;
                    _doctorPaciente.Doctor = DoctorPaciente.Doctor;
                    _doctorPaciente.Estado = 1;
                    bd.DoctorPacientes.Add(_doctorPaciente);
                    await bd.SaveChangesAsync();

                    var respuesta = await bd.DoctorPacientes.LastAsync();
                    doctorPaciente.Doctor = respuesta.Doctor;
                    doctorPaciente.Paciente = respuesta.Paciente;
                    doctorPaciente.Estado = respuesta.Estado;

                    return doctorPaciente;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion

        #region Borrrar

        public static async Task<DoctorPacienteDto> BorrarDoctorPaciente(DoctorPacienteDto doctorPaciente)
        {
            var doctor = new DoctorPacienteDto();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var respuesta = await bd.DoctorPacientes.FirstAsync(d => d.Doctor == doctorPaciente.Doctor && d.Paciente== doctorPaciente.Paciente);
                    doctor.IdDoctorPaciente = respuesta.IdDoctorPaciente;
                    doctor.Doctor = respuesta.Doctor;
                    doctor.Paciente = respuesta.Paciente;
                    doctor.Estado = respuesta.Estado;
                    bd.Remove(respuesta);
                    bd.SaveChanges();
                    return doctor;
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
