using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Entidades
{
    public class Venda
    {
        public int VendaID { get; set; }

        public virtual Cliente Cliente { get; set; }
        public int ClienteID { get; set; }

        public virtual IList<ProdutoVenda> ProdutoVenda { get; set; }

    }
}
