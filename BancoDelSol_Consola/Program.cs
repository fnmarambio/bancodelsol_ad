using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Consola
{
    class Program
    {
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
                    //ingresar();
                    break;

                case "2": 
                    //mostrar();
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
    }
}
