using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDelSol_Model.DTO;

namespace BancoDelSol_Model.DAL
{
    public class ClienteDAL
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public void Ingresar(Cliente c)
        {
            clientes.Add(c);
        }

        public List<Cliente> Mostrar()
        {
            return clientes;
        }
    }
}
