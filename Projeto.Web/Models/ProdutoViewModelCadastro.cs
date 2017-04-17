using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models
{
    public class ProdutoViewModelCadastro
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int Categoria { get; set; }
    }
}