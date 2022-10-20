using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApresentacao.Application.IServices
{
    public interface IBaseService<T> where T : class
    {
        //interface base onde fica metodos que podem ser usados por varias intefaces de serviços 
        void Save(T obj);
        void Save(List<T> obj);
        T FindById(int id);
        T Find(Expression<Func<T, bool>> predicate);
        ICollection<T> Get();
        ICollection<T> Get(Expression<Func<T, bool>> predicate);
        bool Delete(T obj);
        bool Delete(int id);
        void Dispose();
    }
}
