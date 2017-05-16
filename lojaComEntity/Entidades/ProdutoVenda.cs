using System.ComponentModel.DataAnnotations;

namespace lojaComEntity.Entidades
{
    public class ProdutoVenda
    {

        public virtual ProdutoTop ProdutoTop { get; set; }
        public virtual Venda Venda { get; set; }

        public int ProdutoTopID { get; set; }
        public int VendaID { get; set; }

    }
}