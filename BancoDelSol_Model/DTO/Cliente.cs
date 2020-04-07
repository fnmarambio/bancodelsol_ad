using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Model.DTO
{
    public class Cliente : Persona
    {
        //Atibutos
        private int cod_cliente;
        private List<Cuenta> cuentas;
        private Ejecutivo ejecutivo;

      

        public Cliente(int cod_cliente, List<Cuenta> cuentas, Ejecutivo ejecutivo, string run, string nombre, string paterno, string materno, int telefono, string direccion)
            : base (run, nombre, paterno, materno, telefono, direccion) 
        {
            this.cod_cliente = cod_cliente;
            this.Cuentas = cuentas;
            this.ejecutivo = ejecutivo;
        }

        public int Cod_cliente { get => cod_cliente; set => cod_cliente = value; }
        
        public Ejecutivo Ejecutivo { get => ejecutivo; set => ejecutivo = value; }
        public List<Cuenta> Cuentas { get => cuentas; set => cuentas = value; }
    }
}
