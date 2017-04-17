using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models
{
    public class ProdutoViewModelConsulta
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public string Categoria { get; set; }
    }
}