using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.Entities.Types;
using Projeto.BLL.Contracts;
using Projeto.Web.Models;

namespace Projeto.Web.Controllers
{
    public class ProdutoController : Controller
    {
        //atributo para a interface da camada de negocio..
        private readonly IProdutoBusiness business;

        //construtor para injeção de dependencia da camada BLL..
        public ProdutoController(IProdutoBusiness business)
        {
            this.business = business;
        }

        // GET: Produto/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Produto/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        //método para receber a requisição AJAX do JQuery..
        public JsonResult CadastrarProduto(ProdutoViewModelCadastro model)
        {
            try
            {
                Produto p = new Produto();
                p.Nome = model.Nome;
                p.Preco = model.Preco;
                p.Quantidade = model.Quantidade;
                p.Categoria = (Categoria) model.Categoria;

                //cadastrando..
                business.Cadastrar(p);

                //retornando mensagem..
                return Json($"Produto {p.Nome}, cadastrado com sucesso");
            }
            catch(Exception e)
            {
                //retornando mensagem de erro para o jquery..
                return Json("Erro: " + e.Message);
            }
        }

        //método para responder a requisição Ajax da página de consulta..
        public JsonResult ConsultarProdutos()
        {
            try
            {
                //enviando uma lista para a página..
                List<ProdutoViewModelConsulta> lista = new List<ProdutoViewModelConsulta>();

                //varrer a consulta de produtos obtida pela camada business..
                foreach(Produto p in business.ListarTodos())
                {
                    ProdutoViewModelConsulta model = new ProdutoViewModelConsulta();
                    model.IdProduto = p.IdProduto;
                    model.Nome = p.Nome;
                    model.Preco = p.Preco;
                    model.Quantidade = p.Quantidade;
                    model.Total = p.Preco * p.Quantidade;
                    model.Categoria = p.Categoria.ToString();

                    lista.Add(model); //adicionar na lista..
                }

                //enviando a lista para a página..
                return Json(lista);
            }
            catch(Exception e)
            {
                //retornar mensagem de erro..
                return Json("Erro: " + e.Message);
            }
        }

        //método para buscar 1 produto para a edição..
        public JsonResult ObterProdutoEdicao(int idProduto)
        {
            try
            {
                //classe de modelo..
                ProdutoViewModelEdicao model = new ProdutoViewModelEdicao();

                //buscar 1 produto na camada de negocio..
                Produto p = business.ObterPorId(idProduto);

                model.IdProduto = p.IdProduto;
                model.Nome = p.Nome;
                model.Preco = p.Preco;
                model.Quantidade = p.Quantidade;
                model.Categoria = (int) p.Categoria;

                //retornando a model..
                return Json(model);
            }
            catch(Exception e)
            {
                return Json("Erro: " + e.Message);
            }
        }

        //método para receber a requisição de atualizar..
        public JsonResult AtualizarProduto(ProdutoViewModelEdicao model)
        {
            try
            {
                Produto p = new Produto(); //entidade..

                p.IdProduto = model.IdProduto;
                p.Nome = model.Nome;
                p.Preco = model.Preco;
                p.Quantidade = model.Quantidade;
                p.Categoria = (Categoria) model.Categoria;

                business.Atualizar(p);

                return Json($"Produto {p.Nome} atualizado com sucesso");
            }
            catch(Exception e)
            {
                //retornar mensagem de erro..
                return Json("Erro: " + e.Message);
            }
        }

        //método para excluir um produto..
        public JsonResult ExcluirProduto(int idProduto)
        {
            try
            {
                //buscar o produto pelo id..
                Produto p = business.ObterPorId(idProduto);

                //excluindo..
                business.Excluir(p);

                //retornar mensagem..
                return Json($"Produto {p.Nome} excluido com sucesso.");
            }
            catch(Exception e)
            {
                return Json("Erro: " + e.Message);
            }
        }

    }
}