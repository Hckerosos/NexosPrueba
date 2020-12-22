using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelos
{

    public enum EstadoRespuesta { Correcta = 1, ConError, ErrorControlado, SesionExpirada }
    public class Respuesta<T>
    {

        public Respuesta()
        {
            this.estado = EstadoRespuesta.Correcta;
        }
        public Respuesta(EstadoRespuesta _estado) : this()
        {
            this.estado = _estado;
        }
        public Respuesta(string _mensaje) : this()
        {
            this.estado = EstadoRespuesta.ErrorControlado;
            this.mensaje = _mensaje;
        }
        public Respuesta(T _obj) : this()
        {
            this.objeto = _obj;
        }

        public Respuesta(ICollection<T> collection, int _total = 0) : this()
        {
            this.lista = collection;
            this.cantTotal = _total;
        }


        public void addObjeto(T _obj)
        {
            if (lista == null) { this.lista = new List<T>(); }
            lista.Add(_obj);
        }

        public EstadoRespuesta estado { get; set; }
        public ICollection<T> lista { get; set; }
        public T objeto { get; set; }
        public string mensaje { get; set; }
        public int cantTotal { get; set; }
    }
}
