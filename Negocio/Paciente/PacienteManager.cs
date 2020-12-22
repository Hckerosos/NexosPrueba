using IO.Dao;
using Modelo.Dtos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Paciente
{
    public class PacienteManager
    {
        #region Obtener 
        public async Task<Respuesta<List<PacienteDto>>> ObtenerListaPacienteManager()
        {
            try
            {
                var rta = await PacienteDao.ObtenerListaPaciente();
                return new Respuesta<List<PacienteDto>>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<List<PacienteDto>>(ex.Message);
            }

        }
        public async Task<Respuesta<List<DoctorPacienteDto>>> ObtenerListaPacienteDoctorManager()
        {
            try
            {
                var rta = await DoctorPacienteDao.ObtenerListaDoctorPaciente();
                return new Respuesta<List<DoctorPacienteDto>>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<List<DoctorPacienteDto>>(ex.Message);
            }

        }
        public async Task<Respuesta<PacienteDto>> ObtenerPacienteManager(int id)
        {
            try
            {
                var rta = await PacienteDao.ObtenerPaciente(id);
                return new Respuesta<PacienteDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<PacienteDto>(ex.Message);
            }

        }

        #endregion

        #region Registrar

        public async Task<Respuesta<PacienteDto>> RegistrarPacienteManager(PacienteDto paciente)
        {
            try
            {
                var rta = await PacienteDao.RegistrarPaciente(paciente);
                return new Respuesta<PacienteDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<PacienteDto>(ex.Message);
            }

        }

        public async Task<Respuesta<DoctorPacienteDto>> RegistrarDoctorPacienteManager(DoctorPacienteDto DoctorPaciente)
        {
            try
            {
                var rta = await DoctorPacienteDao.RegistrarDoctorPaciente(DoctorPaciente);
                return new Respuesta<DoctorPacienteDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<DoctorPacienteDto>(ex.Message);
            }

        }

        #endregion

        #region Actualizar

        public async Task<Respuesta<PacienteDto>> ActualizarPacienteManager(int id, PacienteDto paciente)
        {
            try
            {
                var rta = await PacienteDao.ActualizarPaciente(id, paciente);
                return new Respuesta<PacienteDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<PacienteDto>(ex.Message);
            }

        }

        #endregion

        #region Borrrar

        public async Task<Respuesta<PacienteDto>> BorrarPacienteManager(int id)
        {
            try
            {
                var rta = await PacienteDao.BorrarPaciente(id);
                return new Respuesta<PacienteDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<PacienteDto>(ex.Message);
            }

        }

        public async Task<Respuesta<DoctorPacienteDto>> BorrarDoctorPacienteManager(DoctorPacienteDto doctorPaciente)
        {
            try
            {
                var rta = await DoctorPacienteDao.BorrarDoctorPaciente( doctorPaciente);
                return new Respuesta<DoctorPacienteDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<DoctorPacienteDto>(ex.Message);
            }

        }

        #endregion

    }
}
