using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //entidades..

namespace Projeto.BLL.Contracts
{
    public interface IProdutoBusiness
        : IGenericBusiness<Produto>
    {
        List<Produto> ListarPorPreco(decimal precoIni, decimal precoFim);
    }
}
