using System;
using System.Collections.Generic;

#nullable disable

namespace IO.Models
{
    public partial class DoctorPaciente
    {
        public int IdDoctorPaciente { get; set; }
        public int Doctor { get; set; }
        public int Paciente { get; set; }
        public int Estado { get; set; }

        public virtual Doctor DoctorNavigation { get; set; }
        public virtual Paciente PacienteNavigation { get; set; }
    }
}
