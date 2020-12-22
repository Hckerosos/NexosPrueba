using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dtos
{
   public class DoctorDto
    {

        #region Propiedades
        public int IdDoctor { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Especialidad { get; set; }
        public string Credencial { get; set; }
        public string Hospital { get; set; }
        #endregion

    }
}
