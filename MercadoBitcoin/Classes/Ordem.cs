using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoBitcoin.Classes
{
    public class Ordem
    {
        public enum TipoOrdem
        {
            Compra,
            Venda
        }

        public TipoOrdem Tipo { get; set; }
        public float ValorUnitario { get; set; }
        public float Quantidade { get; set; }

    }
}
