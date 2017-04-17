﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL.Contracts
{
    //interface para repositorio generico..
    public interface IGenericRepository<T>
        where T : class
    {
        //métodos abstratos..

        void Insert(T obj);

        void Update(T obj);

        void Delete(T obj);

        List<T> FindAll();

        T FindById(int id);
    }
}
