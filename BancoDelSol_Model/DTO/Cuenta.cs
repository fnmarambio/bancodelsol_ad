using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Model.DTO
{
    public class Cuenta
    {
       
        private int num_cuenta;
        private Cliente cuantahabiente;
        private int credito;
        private int clave;
        private int saldo;
        private Movimiento movimientos;

        public Cuenta(int num_cuenta, Cliente cuantahabiente, int credito, int clave, int saldo, Movimiento movimientos)
        {
            this.num_cuenta = num_cuenta;
            this.cuantahabiente = cuantahabiente;
            this.credito = credito;
            this.clave = clave;
            this.saldo = saldo;
            this.movimientos = movimientos;
        }

        public int Num_cuenta { get => num_cuenta; set => num_cuenta = value; }
        public int Credito { get => credito; set => credito = value; }
        public int Clave { get => clave; set => clave = value; }
        public int Saldo { get => saldo; set => saldo = value; }
        internal Cliente Cuantahabiente { get => cuantahabiente; set => cuantahabiente = value; }
        internal Movimiento Movimientos { get => movimientos; set => movimientos = value; }
    }
}
