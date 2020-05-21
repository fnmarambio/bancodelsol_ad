using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDelSol_Model.DTO;

namespace BancoDelSol_Model.DAL
{
    class MovimientoDAL
    {

        private static List<Movimiento> movimientos = new List<Movimiento>();

        public void Ingresar(Movimiento m){
            movimientos.Add(m);
        }

        public List<Movimiento> Mostrar(){
            return movimientos;
        }
    }
}
