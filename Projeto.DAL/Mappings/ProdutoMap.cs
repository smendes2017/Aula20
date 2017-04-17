using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //classes de entidade..
using System.Data.Entity.ModelConfiguration; //mapeamento..

namespace Projeto.DAL.Mappings
{
    //classe de mapeamento para a entidade Produto..
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        //construtor..
        public ProdutoMap()
        {
            //chave primária..
            HasKey(p => p.IdProduto);

            //demais propriedades..
            Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Preco)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(p => p.Quantidade)
                .IsRequired();

            Property(p => p.Categoria)
                .IsRequired();
        }
    }
}
