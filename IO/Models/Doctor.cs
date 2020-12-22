using System;
using System.Collections.Generic;

#nullable disable

namespace IO.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            DoctorPacientes = new HashSet<DoctorPaciente>();
        }

        public int IdDoctor { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Especialidad { get; set; }
        public string Credencial { get; set; }
        public string Hospital { get; set; }

        public virtual ICollection<DoctorPaciente> DoctorPacientes { get; set; }
    }
}
