using BancoDelSol_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Model.DAL
{
    public class PersonaDAL
    {
        //Atributos
        //Creamos una lista vacia para almacenar los objetos
        private static List<Persona> personas = new List<Persona>();

        //Metodos
        public void Ingresar(Persona p)
        {
            personas.Add(p);
        }

        public List<Persona> Mostrar()
        {
            return personas;
        }

        public void Eliminar(Persona p)
        {
            personas.Remove(p);
        }
    }
}
