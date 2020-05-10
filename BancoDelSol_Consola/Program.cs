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
        private static EjecutivoDAL ejecutivoDAL = new EjecutivoDAL();
        private static ClienteDAL clienteDAL = new ClienteDAL();
        private static CuentaDAL cuentaDAL = new CuentaDAL();

        static void Main(string[] args)
        {
            while (Menu());

        }

        private static bool Menu(){
            bool continuar = true;
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("BancoDelSol");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Menú Ejecutivo");
           // Console.WriteLine("2. Mostrar Ejecutivo");
            Console.WriteLine("3. Menú Cliente");
           // Console.WriteLine("4. Mostrar Cliente");
            Console.WriteLine("0. Salir de Programa");
            Console.WriteLine("---------------------------------------");
            string opcion = Console.ReadLine().Trim();

            switch(opcion){

                case "1": 
                    menuEjecutivo();
                    //ingresarEjecutivo
                    break;

                case "2": 
                    mostrarEjecutivo();
                    break;

                case "3": 
                    menuCliente();
                    //ingresarCliente();
                    break;

                case "4":
                    mostrarCLiente();
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

        //Menu Ejecutivo
        private static void menuEjecutivo()
        {
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Crear Ejecutivo");
            Console.WriteLine("2. Crear Cliente");
            Console.WriteLine("3. Crear Cuenta");
            Console.WriteLine("0. Menú Principal");
            Console.WriteLine("---------------------------------------");
            string opcion = Console.ReadLine().Trim();

            switch (opcion)
            {

                case "1":
                    ingresarEjecutivo();
                    break;

                case "2":
                    ingresarCliente();
                    break;

                case "3":
                    IngresarCuenta();
                    break;

                case "0":
                    Menu();
                    break;

                default:
                    Console.WriteLine("Debe ingresar una opción válida");
                    menuEjecutivo();
                    Console.ReadKey();
                    break;
            }

        }

        private static void ingresarEjecutivo(){
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Ingresar Ejecutivo");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Ingrese run");
            string run = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el nombre del ejecutivo");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el apellido paterno del ejecutivo");
            string paterno = Console.ReadLine().Trim();      
            Console.WriteLine("Ingrese el apellido materno del ejecutivo");
            string materno = Console.ReadLine().Trim();
            bool telfValido=false;
            Int16 telefono;
            do{
                Console.WriteLine("Ingrese el telefono del ejecutivo");
                string telfTxt= Console.ReadLine().Trim();
                telfValido = Int16.TryParse(telfTxt, out telefono);
            }while(!telfValido);
            Console.WriteLine("Ingrese la dirección del ejecutivo");
            string direccion = Console.ReadLine().Trim();
            
            Ejecutivo ejecutivo = new Ejecutivo(run, nombre, paterno, materno, telefono, direccion);

            ejecutivoDAL.Ingresar(ejecutivo);
            Console.WriteLine("---------------------------------------");
        }

        private static void mostrarEjecutivo(){
            List<Ejecutivo> ejecutivos = ejecutivoDAL.Mostrar();
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Mostrar Ejecutivos");
            if(ejecutivos.Count()<1){
                Console.WriteLine("No se registran ejecutivos");
            }else{
                foreach (Ejecutivo e in ejecutivos){
                    Console.WriteLine(" ");
                    Console.WriteLine("Ejtvo. " + e.Nombre + " " + e.Paterno);
                    Console.WriteLine(" ");
                    Console.WriteLine("---------------------------------------");
                    if(e.Clientes.Count()<1){
                        Console.WriteLine("No existen clientes asociados a este ejecutivo");
                    }else{
                        foreach(Cliente c in e.Clientes){
                        Console.WriteLine("Sr.(a) " + c.Nombre + " " + c.Paterno);
                        Console.WriteLine("---------------------------------------");
                        }
                    }
                    
                }
            }
            Console.WriteLine("---------------------------------------");
        }

        //menu para el cliente
        private static void menuCliente()
        {
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Crear Cliente");
            Console.WriteLine("2. Asociar Cuenta a Cliente");
            Console.WriteLine("0. Menú Principal");
            Console.WriteLine("---------------------------------------");
            string opcion = Console.ReadLine().Trim();

            switch (opcion)
            {

                case "1":
                    ingresarCliente();
                    break;

                case "2":
                    //asociarCuenta();
                    break;

                case "0":
                    Menu();
                    break;

                default:
                    Console.WriteLine("Debe ingresar una opción válida");
                    menuCliente();
                    Console.ReadKey();
                    break;
            }
            
        }

        public static void ingresarCliente(){
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Ingresar Cliente");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Ingrese run");
            string run = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el nombre del cliente");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el apellido paterno del cliente");
            string paterno = Console.ReadLine().Trim();      
            Console.WriteLine("Ingrese el apellido materno del cliente");
            string materno = Console.ReadLine().Trim();
            bool telfValido=false;
            Int16 telefono;
            do{
                Console.WriteLine("Ingrese el telefono del cliente");
                string telfTxt= Console.ReadLine().Trim();
                telfValido = Int16.TryParse(telfTxt, out telefono);
            }while(!telfValido);
            Console.WriteLine("Ingrese la dirección del cliente");
            string direccion = Console.ReadLine().Trim();
            
            Cliente cliente = new Cliente(run, nombre, paterno, materno, telefono, direccion);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" ");

            List<Ejecutivo> ejecutivos = ejecutivoDAL.Mostrar();
            for (int i = 0; i < ejecutivos.Count(); i++)
			{
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Ejecutivos");
                Console.WriteLine(" ");
                Console.WriteLine(i + " -. Ejtvo. " + ejecutivos[i].Nombre + " " + ejecutivos[i].Paterno);
                Console.WriteLine("---------------------------------------");
			}

            bool indiceValido = false;
            Int16 indice;
            do{
                Console.WriteLine("Ingrese el índice del ejecutivo a asociar a este cliente");
                string indicetxt = Console.ReadLine().Trim();
                indiceValido = Int16.TryParse(indicetxt, out indice);
                ejecutivos[indice].Clientes.Add(cliente);
            }while(!indiceValido && indice < ejecutivos.Count());
            clienteDAL.Ingresar(cliente);
        }

        public static void mostrarCLiente(){
            List<Cliente> clientes = clienteDAL.Mostrar();
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Mostrar Clientes");
            if(clientes.Count()<1){
                Console.WriteLine("No se registran clientes");
            }else{
                foreach (Cliente c in clientes){
                    Console.WriteLine(" ");
                    Console.WriteLine(c.Nombre);
                }
            }
            Console.WriteLine("---------------------------------------");
        }

        //Crear Cuenta
        public static void IngresarCuenta()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Ingresar Cuenta");
            Console.WriteLine("---------------------------------------");

            bool claveValido = false;
            Int16 clave;
            do
            {
                Console.WriteLine("Ingrese una clave para la Cuenta (Solo numeros):");
                string telfTxt = Console.ReadLine().Trim();
                claveValido = Int16.TryParse(telfTxt, out clave);
            } while (!claveValido);

            
            Cuenta cuenta = new Cuenta(clave);

            Console.WriteLine("Asociar Cuenta:");

            List<Cliente> clientes = clienteDAL.Mostrar();
            for (int i = 0; i < clientes.Count(); i++)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Lista de los clientes");
                Console.WriteLine(" ");
                Console.WriteLine(i + " -. Cliente. " + clientes[i].Nombre + " " + clientes[i].Paterno+ " "+clientes[i].Materno);
                Console.WriteLine("---------------------------------------");
            }

            bool indiceValido = false;
            Int16 indice;
            do
            {
                Console.WriteLine("Seleccione el índice del cliente que estara asociado a esta cuenta:");
                string indicetxt = Console.ReadLine().Trim();
                indiceValido = Int16.TryParse(indicetxt, out indice);
                clientes[indice].Cuentas.Add(cuenta);
            } while (!indiceValido && indice < clientes.Count());
            cuentaDAL.Ingresar(cuenta);

        }
    }
}
