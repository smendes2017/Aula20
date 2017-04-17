using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.DAL.Contracts;
using Projeto.BLL.Contracts;

namespace Projeto.BLL.Business
{
    public class ProdutoBusiness : IProdutoBusiness 
    {
        //atributo para utilizar o conteudo do repositorio..
        private readonly IProdutoRepository repository;

        //construtor para receber a instancia da interface..
        public ProdutoBusiness(IProdutoRepository repository)
        {
            this.repository = repository;
        }

        public void Cadastrar(Produto obj)
        {
            repository.Insert(obj);
        }

        public void Atualizar(Produto obj)
        {
            repository.Update(obj);
        }        

        public void Excluir(Produto obj)
        {
            repository.Delete(obj);
        }

        public List<Produto> ListarTodos()
        {
            return repository.FindAll();
        }

        public Produto ObterPorId(int id)
        {
            return repository.FindById(id);
        }

        public List<Produto> ListarPorPreco(decimal precoIni, decimal precoFim)
        {
            return repository.FindByPreco(precoIni, precoFim);
        }        
    }
}
