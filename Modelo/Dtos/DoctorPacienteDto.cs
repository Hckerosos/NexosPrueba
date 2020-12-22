using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dtos
{
    public class DoctorPacienteDto
    {

        #region Propiedades
        public int IdDoctorPaciente { get; set; }
        public int Doctor { get; set; }
        public int Paciente { get; set; }
        public int Estado { get; set; }
        #endregion

    }
}
