using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //connectionstring..
using System.Data.Entity; //entityframework..
using System.Data.Entity.ModelConfiguration.Conventions; //configurações..
using Projeto.Entities; //classes de entidade..
using Projeto.DAL.Mappings; //mapeamentos..

namespace Projeto.DAL.Configurations
{
    //Regra 1) Classe deverá HERDAR DbContext
    public class DataContext : DbContext
    {
        //Regra2) Criar um construtor que envie para o DbContext
        //a connectionstring do Web.config.xml
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["aula"].ConnectionString)
        {

        }

        //Regra 3) Sobrescrever o método OnModelCreating para definir
        //as classes de mapeamento do projeto..
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //desativar a configuração default do EF que gera nomes de tabelas no plural
            //quando não mapeamos o nome de uma entidade no banco de dados..
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoMap());
        }

        //Regra 4) Declarar um DbSet (CRUD) para cada classe de entidade
        public DbSet<Produto> Produto { get; set; }
    }
}
