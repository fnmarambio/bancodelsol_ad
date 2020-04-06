using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Model.DTO
{
    public class Persona
    {
        //Atributos 
        private string run; //*
        private string nombre;
        private string paterno;
        private string materno;
        private int telefono;
        private String direccion;


        //Constructor con parametros
        public Persona(string run, string nombre, string paterno, string materno, int telefono, string direccion)
        {
            this.run = run;
            this.nombre = nombre;
            this.paterno = paterno;
            this.materno = materno;
            this.telefono = telefono;
            this.direccion = direccion;

        }

        //Getter y Setter
        public string Run { get => run; set => run = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Paterno { get => paterno; set => paterno = value; }
        public string Materno { get => materno; set => materno = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        //Metodos
        public override string ToString()
        {
            return "Sr.(a) " + this.nombre + " " + this.paterno + " " + materno;
        }

    }
}
