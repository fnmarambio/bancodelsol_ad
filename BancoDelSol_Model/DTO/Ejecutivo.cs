using BancoDelSol_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Model.DTO
{
    public class Ejecutivo : Persona
    {
        private int cod_ejecutivo;
        private Cliente clientes;

        public Ejecutivo(int cod_ejecutivo, Cliente clientes)  
        {
            this.Cod_ejecutivo = cod_ejecutivo;
            this.Clientes = clientes;
        }

        public int Cod_ejecutivo { get => cod_ejecutivo; set => cod_ejecutivo = value; }
        internal Cliente Clientes { get => clientes; set => clientes = value; }
    }
}
