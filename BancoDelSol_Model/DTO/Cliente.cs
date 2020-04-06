using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Model.DTO
{
    class Cliente : Persona
    {
        //Atibutos
        private int cod_cliente;
        private Cuenta cuentas;
        private Ejecutivo ejecutivo;

        public Cliente(int cod_cliente, Cuenta cuentas, Ejecutivo ejecutivo)
        {
            this.cod_cliente = cod_cliente;
            this.cuentas = cuentas;
            this.ejecutivo = ejecutivo;
        }

        public int Cod_cliente { get => cod_cliente; set => cod_cliente = value; }
        public Cuenta Cuenta { get => cuentas; set => cuentas = value; }
        public Ejecutivo Ejecutivo { get => ejecutivo; set => ejecutivo = value; }
    }
}
