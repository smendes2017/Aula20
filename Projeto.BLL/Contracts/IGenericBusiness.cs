using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.BLL.Contracts
{
    public interface IGenericBusiness<T>
        where T : class
    {
        void Cadastrar(T obj);

        void Atualizar(T obj);

        void Excluir(T obj);

        List<T> ListarTodos();

        T ObterPorId(int id);
    }
}
