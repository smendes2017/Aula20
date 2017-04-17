using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities.Types; //enums..

namespace Projeto.Entities
{
    public class Produto
    {
        //propriedades..
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public Categoria Categoria { get; set; }
    }
}
