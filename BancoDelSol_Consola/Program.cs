using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDelSol_Model.DAL;
using BancoDelSol_Model.DTO;

namespace BancoDelSol_Consola
{
    class Program
    {
        private static PersonaDAL personaDAL = new PersonaDAL();

        static void Main(string[] args)
        {
            while (Menu());

        }

        private static bool Menu(){
            bool continuar = true;
            Console.WriteLine("BancoDelSol");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Crear Persona");
            Console.WriteLine("2. Mostrar Persona");
            Console.WriteLine("3. Eliminar Persona");
            Console.WriteLine("0. Salir de Programa");
            Console.WriteLine("------------------------");
            string opcion = Console.ReadLine().Trim();

            switch(opcion){

                case "1": 
                    insertar();
                    break;

                case "2": 
                    mostrar();
                    break;

                case "3": 
                    //eliminar();
                    break;

                case "0": 
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Debe ingresar una opción válida");
                    Console.ReadKey();
                    break;
            }
            return continuar;
        }

        private static void insertar(){
            Console.WriteLine(" ");
            Console.WriteLine("Ingresar Persona");
            Console.WriteLine(" ");
            Console.WriteLine("Ingrese run");
            string run = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el nombre de la persona");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el apellido paterno de la persona");
            string paterno = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el apellido materno de la persona");
            string materno = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el telefono de la persona");
            string telfTxt= Console.ReadLine().Trim();
            bool telfValido;
            Int16 telefono;
            telfValido = Int16.TryParse(telfTxt, out telefono);
            Console.WriteLine("Ingrese la dirección de la persona");
            string direccion = Console.ReadLine().Trim();
            
            Persona personita = new Persona(run, nombre, paterno, materno, telefono, direccion);

            personaDAL.Ingresar(personita);
        }

        private static void mostrar(){
            List<Persona> convives = personaDAL.Mostrar();
            Console.WriteLine(" ");
            Console.WriteLine("Mostrar Personas");
            if(convives.Count()<1){
                Console.WriteLine("No se registran personas");
            }else{
                foreach (Persona p in convives){
                    Console.WriteLine(p);
                }
            }
        }
    }
}
