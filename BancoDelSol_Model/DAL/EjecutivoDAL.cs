using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDelSol_Model.DTO;

namespace BancoDelSol_Model.DAL
{
    public class EjecutivoDAL
    {
        private static List<Ejecutivo> ejecutivos = new List<Ejecutivo>();

        public void Ingresar(Ejecutivo e)
        {
            ejecutivos.Add(e);
        }

        public List<Ejecutivo> Mostrar()
        {
            return ejecutivos;
        }
    }
}
