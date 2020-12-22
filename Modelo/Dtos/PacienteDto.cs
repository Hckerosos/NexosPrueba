using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dtos
{
   public class PacienteDto
    {

        #region Propiedades
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Seguro { get; set; }
        #endregion

    }
}
