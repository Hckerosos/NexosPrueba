using IO.Models;
using Modelo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IO.Dao
{
    public class DoctorDao
    {

        #region Obtener
        public static async Task<List<DoctorDto>> ObtenerListaDoctor()
        {
            var respuesta = new List<DoctorDto>();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var lista = await bd.Doctors.ToListAsync();

                    foreach (var row in lista)
                        respuesta.Add(new DoctorDto { IdDoctor=row.IdDoctor, Nombre = row.Nombre, Credencial = row.Credencial, Edad = row.Edad, Especialidad = row.Especialidad, Hospital = row.Hospital });

                    return respuesta;
                }

            }
            catch (Exception ex)
            {

                return null;

            }

        }

        public static async Task<DoctorDto> ObtenerDoctor(int id)
        {
            var respuesta = new DoctorDto();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var doctor = await bd.Doctors.FirstAsync(d => d.IdDoctor == id);

                    respuesta.Nombre = doctor.Nombre;
                    respuesta.Credencial = doctor.Credencial;
                    respuesta.Edad = doctor.Edad;
                    respuesta.Especialidad = doctor.Especialidad;
                    respuesta.Hospital = doctor.Hospital;

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

        public static async Task<DoctorDto> RegistrarDoctor(DoctorDto doctor)
        {
            var _doctor = new Doctor();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    _doctor.Nombre = doctor.Nombre;
                    _doctor.Credencial = doctor.Credencial;
                    _doctor.Edad = doctor.Edad;
                    _doctor.Especialidad = doctor.Especialidad;
                    _doctor.Hospital = doctor.Hospital;
                    bd.Doctors.Add(_doctor);
                    await bd.SaveChangesAsync();

                    var respuesta = await bd.Doctors.LastAsync();
                    doctor.IdDoctor = respuesta.IdDoctor;
                    doctor.Nombre = respuesta.Nombre;
                    doctor.Credencial = respuesta.Credencial;
                    doctor.Edad = respuesta.Edad;
                    doctor.Especialidad = respuesta.Especialidad;
                    doctor.Hospital = respuesta.Hospital;
                    return doctor;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion

        #region Actualizar

        public static async Task<DoctorDto> ActualizarDoctor(int id, DoctorDto doctor)
        {
            var _doctor = new Doctor();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var respuesta = await bd.Doctors.FirstAsync(d => d.IdDoctor == id);
                    respuesta.IdDoctor = doctor.IdDoctor;
                    respuesta.Nombre = doctor.Nombre;
                    respuesta.Credencial = doctor.Credencial;
                    respuesta.Edad = doctor.Edad;
                    respuesta.Especialidad = doctor.Especialidad;
                    respuesta.Hospital = doctor.Hospital;
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

        #region Borrar

        public static async Task<DoctorDto> BorrarDoctor(int id)
        {
            var doctor = new DoctorDto();
            try
            {
                using (NexoDataBase bd = new NexoDataBase())
                {
                    var respuesta = await bd.Doctors.FirstAsync(d => d.IdDoctor == id);
                    doctor.IdDoctor = respuesta.IdDoctor;
                    doctor.Nombre = respuesta.Nombre;
                    doctor.Credencial = respuesta.Credencial;
                    doctor.Edad = respuesta.Edad;
                    doctor.Especialidad = respuesta.Especialidad;
                    doctor.Hospital = respuesta.Hospital;
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
