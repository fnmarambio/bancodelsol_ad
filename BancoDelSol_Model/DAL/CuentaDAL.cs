using BancoDelSol_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDelSol_Model.DAL
{
    public class CuentaDAL
    {
        private static List<Cuenta> cuentas = new List<Cuenta>();

        //Metodos
        public void Ingresar(Cuenta c)
        {
            cuentas.Add(c);
        }

        public List<Cuenta> Mostrar()
        {
            return cuentas;
        }

        public void Eliminar(Cuenta c)
        {
            cuentas.Remove(c);
        }
    }
}
