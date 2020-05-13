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
                    mostrarCliente();
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
            Console.WriteLine("2. Mostrar Ejecutivos");
            Console.WriteLine("3. Crear Cliente");
            Console.WriteLine("4. Crear Cuenta");
            Console.WriteLine("5. Depositar");
            Console.WriteLine("0. Menú Principal");
            Console.WriteLine("---------------------------------------");
            string opcion = Console.ReadLine().Trim();

            switch (opcion)
            {

                case "1":
                    ingresarEjecutivo();
                    break;

                case "2":
                    mostrarEjecutivo();
                    break;

                case "3":
                    ingresarCliente();
                    break;

                case "4":
                    IngresarCuenta();
                    break;

                case "5":
                    depositar();
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
            Console.WriteLine("1. Mostrar Clientes");
            Console.WriteLine("2. Asociar Cuenta a Cliente");
            Console.WriteLine("0. Menú Principal");
            Console.WriteLine("---------------------------------------");
            string opcion = Console.ReadLine().Trim();

            switch (opcion)
            {

                case "1":
                    mostrarCliente();
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

        public static void mostrarCliente(){
            List<Cliente> clientes = clienteDAL.Mostrar();
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Mostrar Clientes");
            if(clientes.Count()<1){
                Console.WriteLine("No se registran clientes");
            }else{
                foreach (Cliente c in clientes){
                    Console.WriteLine(" ");
                    Console.WriteLine("Sr.(a) "+ c.Nombre + " " + c.Paterno);
                    if(c.Cuentas.Count()<1){
                        Console.WriteLine("No tiene cuentas");
                    }else{
                        foreach(Cuenta cuenta in c.Cuentas){
                            Console.WriteLine("Cuenta nro: " + cuenta.Num_cuenta + " -- Saldo: $"+ cuenta.Saldo);
                        }
                    }
                }
            }
            Console.WriteLine("---------------------------------------");
        }

        //CREAR CUENTA
        public static void IngresarCuenta()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Crear Cuenta");
            Console.WriteLine("---------------------------------------");

            bool numValido = false;
            int numCuenta;
            do
            {
                Console.WriteLine("Ingrese número de cuenta");
                string numTxt = Console.ReadLine().Trim();
                numValido = int.TryParse(numTxt, out numCuenta);
            } while (!numValido);


            bool saldoValido = false;
            int dep;
            do{
                Console.WriteLine("Ingrese el monto del primer depósito de la cuenta");
                string depTxt = Console.ReadLine().Trim();
                saldoValido = int.TryParse(depTxt, out dep);
            } while (!saldoValido);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Lista de los clientes");

            List<Cliente> clientes = clienteDAL.Mostrar();
            for (int i = 0; i < clientes.Count(); i++)
            {  
                Console.WriteLine(" ");
                Console.WriteLine("Run: " + clientes[i].Run + ". Sr.(a)" + clientes[i].Nombre + " " + clientes[i].Paterno+ " "+clientes[i].Materno);   
            }

            Console.WriteLine("Ingrese el rut del cliente a asociar a esta cuenta");
            string run = Console.ReadLine().Trim();

            //Asociar cuenta a cliente (chamullento)
            for (int i = 0; i < clientes.Count(); i++)
			{
                if(run == clientes[i].Run){
                    Cuenta cuenta = new Cuenta();
                    cuenta.Num_cuenta = numCuenta;
                    cuenta.Saldo = dep;
                    cuenta.Cuentahabiente = clientes[i];
                    clientes[i].Cuentas.Add(cuenta);
                    cuentaDAL.Ingresar(cuenta);
                }
			}
        }

        //DEPOSITAR
        public static void depositar(){

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Depositar");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" ");

            Console.WriteLine("Cuentas");
            Console.WriteLine("---------------------------------------");
            List<Cuenta> cuentas = cuentaDAL.Mostrar();
            for (int i = 0; i < cuentas.Count(); i++)
			{
                Console.WriteLine("Titular: " + cuentas[i].Cuentahabiente.Nombre + " " + cuentas[i].Cuentahabiente.Paterno + " -- Nro cuenta: " + cuentas[i].Num_cuenta);
                Console.WriteLine(" ");
			}
            

            bool cuentaValida, cuentaExiste = false;
            int numCuenta;
            do
	        {
                Console.WriteLine("Ingrese el número de cuenta");
                string numCuentaTxt = Console.ReadLine().Trim();
                cuentaValida = int.TryParse(numCuentaTxt, out numCuenta);
                foreach  (Cuenta c in cuentas)
	            {
                    if(c.Num_cuenta == numCuenta){
                        cuentaExiste = true;
                    }
	            }
	        } while (!cuentaValida && !cuentaExiste);

            bool montoValido = false;
            int monto;
            do
	        {
                Console.WriteLine("Ingrese el monto del depósito");
                string montoTxt = Console.ReadLine().Trim();
                montoValido = int.TryParse(montoTxt, out monto);
	        } while (!montoValido);
            
            for (int i = 0; i < cuentas.Count(); i++)
			{
                if(cuentas[i].Num_cuenta == numCuenta){
                    Console.WriteLine(cuentas[i].Saldo);
                    cuentas[i].Saldo = cuentas[i].Saldo + monto;
                    Console.WriteLine(cuentas[i].Saldo);
                }
			}
        }
    }
}
