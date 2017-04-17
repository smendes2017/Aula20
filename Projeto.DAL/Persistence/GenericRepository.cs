using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //entityframework..
using Projeto.DAL.Configurations; //datacontext..
using Projeto.DAL.Contracts; //interfaces..

namespace Projeto.DAL.Persistence
{
    //classe de repositorio de dados generica..
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        public virtual void Insert(T obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Added; //insert..
                d.SaveChanges(); //executando..
            }
        }

        public virtual void Update(T obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Modified; //update..
                d.SaveChanges(); //executando..
            }
        }

        public virtual void Delete(T obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Deleted; //delete..
                d.SaveChanges(); //executando..
            }
        }

        public virtual List<T> FindAll()
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<T>().ToList(); //todos os registros..
            }
        }

        public virtual T FindById(int id)
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<T>().Find(id); //buscar por id..
            }
        }
    }
}
