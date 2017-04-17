using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //entidades..

namespace Projeto.DAL.Contracts
{
    public interface IProdutoRepository
        : IGenericRepository<Produto>
    {
        List<Produto> FindByPreco(decimal precoIni, decimal precoFim);

    }
}
