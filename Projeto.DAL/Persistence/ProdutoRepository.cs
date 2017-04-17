using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Projeto.Entities;
using Projeto.DAL.Configurations;
using Projeto.DAL.Contracts;

namespace Projeto.DAL.Persistence
{
    public class ProdutoRepository
        : GenericRepository<Produto>, IProdutoRepository
    {
        public List<Produto> FindByPreco(decimal precoIni, decimal precoFim)
        {
            using (DataContext d = new DataContext())
            {
                //SQL -> select * from Produto
                //       where Preco between ? and ?
                //       order by Preco desc

                return d.Produto
                        .Where(p => p.Preco >= precoIni && p.Preco <= precoFim)
                        .OrderByDescending(p => p.Preco)
                        .ToList();
            }
        }
    }
}
