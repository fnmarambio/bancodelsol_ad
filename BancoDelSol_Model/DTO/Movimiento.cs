using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Model.DTO
{
    public class Movimiento
    {
        private int num_movimiento;
        private Cuenta cuenta_asoc;
        private String tipo;
        private int monto;

        public Movimiento(int num_movimiento, Cuenta cuenta_asoc, string tipo, int monto)
        {
            this.Num_movimiento = num_movimiento;
            this.Cuenta_asoc = cuenta_asoc;
            this.Tipo = tipo;
            this.Monto = monto;
        }

        public int Num_movimiento { get => num_movimiento; set => num_movimiento = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Monto { get => monto; set => monto = value; }
        public Cuenta Cuenta_asoc { get => cuenta_asoc; set => cuenta_asoc = value; }
    }
}
