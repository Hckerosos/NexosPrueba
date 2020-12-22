using Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Modelo.Dtos;
using IO.Dao;
using System.Threading.Tasks;

namespace Negocio.Doctor
{
    public class DoctorManager
    {
        #region Obtener 
        public async Task<Respuesta<DoctorDto>> ObtenerListaDoctorManager()
        {
            try
            {
                var rta = await DoctorDao.ObtenerListaDoctor();
                return new Respuesta<DoctorDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<DoctorDto>(ex.Message);
            }

        }
        public async Task<Respuesta<DoctorDto>> ObtenerDoctorManager(int id)
        {
            try
            {
                var rta = await DoctorDao.ObtenerDoctor(id);
                return new Respuesta<DoctorDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<DoctorDto>(ex.Message);
            }

        }

        #endregion

        #region Registrar

        public async Task<Respuesta<DoctorDto>> RegistrarDoctorManager(DoctorDto doctor)
        {
            try
            {
                var rta = await DoctorDao.RegistrarDoctor(doctor);
                return new Respuesta<DoctorDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<DoctorDto>(ex.Message);
            }

        }

        #endregion

        #region Actualizar

        public async Task<Respuesta<DoctorDto>> ActualizarDoctorManager(int id,DoctorDto doctor)
        {
            try
            {
                var rta = await DoctorDao.ActualizarDoctor(id,doctor);
                return new Respuesta<DoctorDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<DoctorDto>(ex.Message);
            }

        }

        #endregion

        #region Borrar

        public async Task<Respuesta<DoctorDto>> BorrarDoctorManager(int id)
        {
            try
            {
                var rta = await DoctorDao.BorrarDoctor(id);
                return new Respuesta<DoctorDto>(rta);
            }
            catch (Exception ex)
            {
                return new Respuesta<DoctorDto>(ex.Message);
            }

        }

        #endregion
    }
}
