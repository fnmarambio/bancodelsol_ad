﻿using System;
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
            while (inicioSesion());
        }

        private static bool inicioSesion(){
            bool continuar = true;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Inicio Sesión");
            Console.WriteLine("         Usuario: 0 y contraseña: 0 para salir");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Ingrese usuario");
            string usuario = Console.ReadLine().Trim();
            Console.WriteLine(" ");
            Console.WriteLine("Ingrese contraseña");
            string clave = Console.ReadLine().Trim();

            if (usuario.Equals("0") && clave.Equals("0"))
	        {
                continuar = false;
	        }

            if (usuario.Equals("administrador") && clave.Equals("administrador"))
	        {
                while(menuAdministrador());
	        }else
	        {
                if (usuario.Equals("ejecutivo") && clave.Equals("ejecutivo"))
	            {
                    while(menuEjecutivo());
	            }else{
                    if (usuario.Equals("cliente") && clave.Equals("cliente"))
	                {
                        while(menuCliente());
	                }else
	                {
                        Console.WriteLine("No se encuentra usuario");
	                }
                }
	        }

            return continuar;
        }

        //**********************   MENU ADMINISTRADOR  *********************************  

        private static bool menuAdministrador(){

            bool continuar = true;
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Crear Ejecutivo");
            Console.WriteLine("2. Mostrar Ejecutivos");
            Console.WriteLine("0. Ir a inicio sesión");
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

                case "0":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Debe ingresar una opción válida");
                    menuEjecutivo();
                    Console.ReadKey();
                    break;
            }

            return continuar;
        }

        //***************************          MENU EJECUTIVO          *************************************

        private static bool menuEjecutivo()
        {
            bool continuar = true;
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Crear Cliente");
            Console.WriteLine("2. Mostrar Cliente");
            Console.WriteLine("3. Crear Cuenta");
            Console.WriteLine("4. Depositar");
            Console.WriteLine("0. Ir a inicio sesión");
            Console.WriteLine("---------------------------------------");
            string opcion = Console.ReadLine().Trim();

            switch (opcion)
            {
                case "1":
                    ingresarCliente();
                    break;

                case "2":
                    mostrarCliente();
                    break;

                case "3":
                    IngresarCuenta();
                    break;

                case "4":
                    depositar();
                    break;

                case "0":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Debe ingresar una opción válida");
                    menuEjecutivo();
                    Console.ReadKey();
                    break;
            }

            return continuar;
        }

        //**************************       CREAR EJECUTIVO     ***************************

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

            bool telfValido = false;
            int telefono;
            do{
                Console.WriteLine("Ingrese el teléfono del ejecutivo");
                string telfTxt= Console.ReadLine().Trim();
                telfValido = int.TryParse(telfTxt, out telefono);
                if(telefono <= 0){
                    telfValido = false;
                }
            }while(!telfValido);

            Console.WriteLine("Ingrese la dirección del ejecutivo");
            string direccion = Console.ReadLine().Trim();
            
            Ejecutivo ejecutivo = new Ejecutivo(run, nombre, paterno, materno, telefono, direccion);

            ejecutivoDAL.Ingresar(ejecutivo);
            Console.WriteLine("---------------------------------------");
        }

        //**************************        MOSTRAR EJECUTIVOS        ***************************

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
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Ejtvo. " + e.Nombre + " " + e.Paterno);
                    if(e.Clientes.Count()<1){
                        Console.WriteLine("     No existen clientes asociados a este ejecutivo");
                    }else{
                        foreach(Cliente c in e.Clientes){
                        Console.WriteLine("     Sr.(a) " + c.Nombre + " " + c.Paterno);
                        }
                    }   
                }
            }
            Console.WriteLine("---------------------------------------");
        }

        //******************     MENU CLIENTE   ***********************
        private static bool menuCliente()
        {
            bool continuar = true;
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Transferir");
            Console.WriteLine("2. Consultar movimientos");
            Console.WriteLine("0. Ir a inicio sesión");
            Console.WriteLine("---------------------------------------");
            string opcion = Console.ReadLine().Trim();

            switch (opcion)
            {

                case "1":
                    transferir();
                    break;

                case "2":
                    mostrarMovimientos();
                    break;

                case "0":
                    continuar = false;;
                    break;

                default:
                    Console.WriteLine("Debe ingresar una opción válida");
                    menuCliente();
                    Console.ReadKey();
                    break;
            }
            
            return continuar;
        }

        // ***************************           CREAR CLIENTE             ******************************

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
            int telefono;
            do{
                Console.WriteLine("Ingrese el teléfono del cliente");
                string telfTxt= Console.ReadLine().Trim();
                telfValido = int.TryParse(telfTxt, out telefono);
                if(telefono <= 0){
                    telfValido = false;
                }
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
            int indice;
            do{
                Console.WriteLine("Ingrese el índice del ejecutivo a asociar a este cliente");
                string indicetxt = Console.ReadLine().Trim();
                indiceValido = int.TryParse(indicetxt, out indice);
                try 
	            {	        
		            ejecutivos[indice].Clientes.Add(cliente);
	            }
	            catch (Exception )
	            {
                    indiceValido = false;
	            }   
            }while(!indiceValido);
            clienteDAL.Ingresar(cliente);
        }


        //**************************   MOSTRAR CLIENTES   ************************************* 

        public static void mostrarCliente(){
            List<Cliente> clientes = clienteDAL.Mostrar();
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Mostrar Clientes");
            Console.WriteLine("---------------------------------------");
            if(clientes.Count()<1){
                Console.WriteLine("No se registran clientes");
            }else{
                foreach (Cliente c in clientes){
                    Console.WriteLine(" ");
                    Console.WriteLine("Sr.(a) "+ c.Nombre + " " + c.Paterno);
                    if(c.Cuentas.Count()<1){
                        Console.WriteLine("     No tiene cuentas");
                    }else{
                        foreach(Cuenta cuenta in c.Cuentas){
                            Console.WriteLine("     Cuenta nro: " + cuenta.Num_cuenta + " -- Saldo: $"+ cuenta.Saldo);
                        }
                    }
                }
            }
            Console.WriteLine("---------------------------------------");
        }

        //*******************************            CREAR CUENTA            *****************************

        public static void IngresarCuenta()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Crear Cuenta");
            Console.WriteLine("---------------------------------------");

            bool numValido = false, cuentaExiste = false;
            int numCuenta;
            do
            {
                Console.WriteLine("Ingrese número de cuenta");
                string numTxt = Console.ReadLine().Trim();
                numValido = int.TryParse(numTxt, out numCuenta);

                List<Cuenta> cuentas = cuentaDAL.Mostrar();
                foreach (Cuenta c in cuentas)
	            {
                    if (c.Num_cuenta == numCuenta)
	                {
                        cuentaExiste = true;
                        Console.WriteLine("Ya existe una cuenta asociada a este número");
	                }
	            }

                if(numCuenta <= 999){
                    numValido = false;
                }
            } while (!numValido && !cuentaExiste);


            bool saldoValido = false;
            int dep;
            do{
                Console.WriteLine("Ingrese el monto del primer depósito de la cuenta");
                string depTxt = Console.ReadLine().Trim();
                saldoValido = int.TryParse(depTxt, out dep);
                if(dep < 0){
                    saldoValido = false;
                    Console.WriteLine("El monto no puede ser negativo");
                }
            } while (!saldoValido);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Lista de los clientes");
            Console.WriteLine("---------------------------------------");

            List<Cliente> clientes = clienteDAL.Mostrar();
            for (int i = 0; i < clientes.Count(); i++)
            {  
                Console.WriteLine("Run: " + clientes[i].Run + ". Sr.(a) " + clientes[i].Nombre + " " + clientes[i].Paterno+ " "+clientes[i].Materno);   
            }

            bool runExiste = false;
            do
	        {
                Console.WriteLine(" ");
                Console.WriteLine("Ingrese el rut del cliente a asociar a esta cuenta");
                string run = Console.ReadLine().Trim();
                for (int i = 0; i < clientes.Count(); i++)
			    {
                    if(run == clientes[i].Run){
                        runExiste = true;
                        Cuenta cuenta = new Cuenta();
                        cuenta.Num_cuenta = numCuenta;
                        cuenta.Saldo = dep;
                        cuenta.Cuentahabiente = clientes[i];
                        cuenta.Clave = 1111;
                        if (dep != 0)
	                    {
                            Movimiento m = new Movimiento((cuenta.Movimientos.Count()+100), cuenta, "Depósito", dep);
                            cuenta.Movimientos.Add(m);
	                    }
                        clientes[i].Cuentas.Add(cuenta);
                        cuentaDAL.Ingresar(cuenta);
                    }
			    }
	        } while (!runExiste);
        }

        //************************        DEPOSITAR         *******************************

        public static void depositar(){

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Depositar");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" ");

            List<Cuenta> cuentas = cuentaDAL.Mostrar();

            if (cuentas.Count() == 0)
	        {
                Console.WriteLine("No existen cuentas");
	        }else{
                Console.WriteLine("Cuentas");
                Console.WriteLine("---------------------------------------");
            
                for (int i = 0; i < cuentas.Count(); i++)
		    	{
                    Console.WriteLine("Titular: " + cuentas[i].Cuentahabiente.Nombre + " " + cuentas[i].Cuentahabiente.Paterno + " -- Nro cuenta: " + cuentas[i].Num_cuenta);
                    Console.WriteLine(" ");
		    	}

                bool cuentaValida = false, cuentaExiste = false;
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
                   if(!cuentaExiste){          
                        cuentaValida = false;
                        Console.WriteLine(" ");
                        Console.WriteLine("No existe cuenta asociada a este número");
                   }
	            }while (!cuentaValida);

                bool montoValido = false;
                int monto;
                do
	            {
                    Console.WriteLine("Ingrese el monto del depósito");
                    string montoTxt = Console.ReadLine().Trim();
                    montoValido = int.TryParse(montoTxt, out monto);

                    if(monto < 0){
                        montoValido = false;
                        Console.WriteLine("El monto no puede ser negativo");
                    }
	            }while (!montoValido);
            
                for (int i = 0; i < cuentas.Count(); i++)
			    {
                    if(cuentas[i].Num_cuenta == numCuenta){
                        cuentas[i].Saldo = cuentas[i].Saldo + monto;
                        Movimiento m = new Movimiento((cuentas[i].Movimientos.Count+100), cuentas[i], "Depósito", monto);
                        cuentas[i].Movimientos.Add(m);
                    }
			    }
            }
        }

        //**********************            TRANSFERIR             *************************

        public static void transferir(){

            List<Cuenta> cuentas = cuentaDAL.Mostrar();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Transferir");
            Console.WriteLine("---------------------------------------");

            if (cuentas.Count() == 0 || cuentas.Count() == 1)
	        {
                Console.WriteLine("No existen cuentas suficientes para realizar transferencias");
	        }else{

                Console.WriteLine(" ");
                Console.WriteLine("Cuenta remitente");
                Console.WriteLine(" ");
            
                for (int i = 0; i < cuentas.Count(); i++)
			    {
                    Console.WriteLine("Titular: " + cuentas[i].Cuentahabiente.Nombre + " " + cuentas[i].Cuentahabiente.Paterno + " -- Nro cuenta: " + cuentas[i].Num_cuenta);
                    Console.WriteLine(" ");
			    }

                bool remitenteValido = false, remitenteExiste = false;
                int numCuentaRemitente;
                do
	            {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine(" ");
                    Console.WriteLine("Ingrese el número de cuenta remitente");
                    string remitenteTxt = Console.ReadLine().Trim();
                    remitenteValido = int.TryParse(remitenteTxt, out numCuentaRemitente);
                    for (int i = 0; i < cuentas.Count(); i++)
	                {
                        if(cuentas[i].Num_cuenta == numCuentaRemitente){
                            remitenteExiste = true;
                        }
	                }
                    if(!remitenteExiste){
                        remitenteValido = false;
                        Console.WriteLine("No existe cuenta asociada a este número");
                    }
	            } while (!remitenteValido);

                bool montoValido = false;
                int monto;
                do
	            {
                    Console.WriteLine("Ingrese el monto de la transferencia");
                    string montoTxt = Console.ReadLine().Trim();
                    montoValido = int.TryParse(montoTxt, out monto);
                    if(monto < 0){
                        montoValido = false;
                    }
	            } while (!montoValido);

                Console.WriteLine(" ");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Cuenta destino");
                Console.WriteLine(" ");
                for (int i = 0; i < cuentas.Count(); i++)
			    {
                    Console.WriteLine("Titular: " + cuentas[i].Cuentahabiente.Nombre + " " + cuentas[i].Cuentahabiente.Paterno + " -- Nro cuenta: " + cuentas[i].Num_cuenta);
                    Console.WriteLine(" ");
			    }
                
                bool destinoValido = false, destinoExiste= false;
                int numCuentaDestino;
                do
	            {
                    Console.WriteLine(" ");
                    Console.WriteLine("Ingrese el número de cuenta de destino");
                    string destinoTxt = Console.ReadLine().Trim();
                    destinoValido = int.TryParse(destinoTxt, out numCuentaDestino);
                    for (int i = 0; i < cuentas.Count(); i++)
	                {
                        if(cuentas[i].Num_cuenta == numCuentaDestino){
                            destinoExiste = true;
                        }
	                }
                    if(!destinoExiste){
                        destinoValido = false;
                        Console.WriteLine("No existe cuenta asociada a este número");
                    }
	            } while (!destinoValido);

                for (int i = 0; i < cuentas.Count(); i++)
			    {
                    for (int j = 0; j < cuentas.Count(); j++)
			        {
                        if (cuentas[i].Num_cuenta == numCuentaRemitente && cuentas[j].Num_cuenta == numCuentaDestino)
	                    {
                            if(monto > cuentas[i].Saldo){
                                int diferencia = (monto - cuentas[i].Saldo);
                                if(diferencia > cuentas[i].Credito){
                                    Console.WriteLine("El monto a transferir no puede superar su saldo y línea de crédito. Ingrese un monto menor");
                                }else{
                                    cuentas[i].Credito = cuentas[i].Credito - diferencia;
                                    cuentas[i].Saldo = 0;
                                    cuentas[j].Saldo = cuentas[j].Saldo + monto;
                                    Movimiento movRemi = new Movimiento((cuentas[i].Movimientos.Count()+100), cuentas[i], "Transferencia", monto);
                                    Movimiento movDest = new Movimiento((cuentas[j].Movimientos.Count()+100), cuentas[j], "Transferencia", monto);
                                    cuentas[i].Movimientos.Add(movRemi);
                                    cuentas[j].Movimientos.Add(movDest);
                                }
                            }else{
                                cuentas[i].Saldo = cuentas[i].Saldo - monto;
                                cuentas[j].Saldo = cuentas[j].Saldo + monto;
                                Movimiento movRemi = new Movimiento((cuentas[i].Movimientos.Count()+100), cuentas[i], "Transferencia", monto);
                                Movimiento movDest = new Movimiento((cuentas[j].Movimientos.Count()+100), cuentas[j], "Transferencia", monto);
                                cuentas[i].Movimientos.Add(movRemi);
                                cuentas[j].Movimientos.Add(movDest);
                            }     
                        }else
	                    {
                            if(numCuentaRemitente == numCuentaDestino){
                                Console.WriteLine("No se puede transferir a la misma cuenta");
                            } 
	                    }   
                    }
			    }
            }
        }

        //**********************           MOSTRAR MOVIMIENTOS           *************************

        public static void mostrarMovimientos(){

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Cuentas");
            Console.WriteLine("---------------------------------------");
            List<Cuenta> cuentas = cuentaDAL.Mostrar();
            for (int i = 0; i < cuentas.Count(); i++)
			{
                Console.WriteLine("Titular: " + cuentas[i].Cuentahabiente.Nombre + " " + cuentas[i].Cuentahabiente.Paterno + " -- Nro cuenta: " + cuentas[i].Num_cuenta);
                Console.WriteLine(" ");
			}

            bool cuentaValido = false, cuentaExiste = false;
            int numCuenta;
            do
	        {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Ingrese el número de cuenta a consultar");
                string cuentaTxt = Console.ReadLine().Trim();
                cuentaValido = int.TryParse(cuentaTxt, out numCuenta);
                for (int i = 0; i < cuentas.Count(); i++)
	            {
                    if(cuentas[i].Num_cuenta == numCuenta){
                        cuentaExiste = true;
                        if (cuentas[i].Movimientos.Count() == 0)
	                    {
                            Console.WriteLine("No se registran movimientos asociados a esta cuenta");
	                    }else{
                            Console.WriteLine(" ");
                            Console.WriteLine("Movimientos");
                            Console.WriteLine("---------------------------------------");
                            foreach  (Movimiento m in cuentas[i].Movimientos)
	                        {
                                Console.WriteLine("Tipo de movimiento: " + m.Tipo + " -- Monto: $" + m.Monto);
	                        }
                        }
                    }
	            }
                if(!cuentaExiste){
                    Console.WriteLine("No se encontró la cuenta. Ingrese nuevamente");
                    cuentaValido = false;
                }  
	        } while (!cuentaValido);          
        }
    }
}
