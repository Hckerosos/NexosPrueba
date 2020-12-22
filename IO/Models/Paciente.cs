using System;
using System.Collections.Generic;

#nullable disable

namespace IO.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            DoctorPacientes = new HashSet<DoctorPaciente>();
        }

        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Seguro { get; set; }

        public virtual ICollection<DoctorPaciente> DoctorPacientes { get; set; }
    }
}
