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
        private List<Cliente> clientes;

        public Ejecutivo(int cod_ejecutivo, List<Cliente> clientes, string run, string nombre, string paterno, string materno, int telefono, string direccion) 
            : base (run, nombre, paterno, materno, telefono, direccion)
        {
            this.cod_ejecutivo = cod_ejecutivo;
            this.clientes = clientes;
        }

        public int Cod_ejecutivo { get => cod_ejecutivo; set => cod_ejecutivo = value; }
        internal List<Cliente> Clientes { get => clientes; set => clientes = value; }
    }
}
