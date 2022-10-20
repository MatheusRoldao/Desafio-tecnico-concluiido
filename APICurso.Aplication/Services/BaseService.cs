using WebApresentacao.Application.IServices;
using WebApresentacao.Infra.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApresentacao.Application.Services
{
    public abstract class BaseService<T> : IDisposable, IBaseService<T> where T : class
    {
        //Classe abstrata de serviços base onde ficam metodos que podem ser extendidos por varios serviços
        private readonly IBaseRepository<T> repository;
        public BaseService(IBaseRepository<T> _repository)
        {
            repository = _repository;
        }

        public virtual bool Delete(T obj)
        {
            return repository.Delete(obj);
        }

        public virtual bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return repository.Find(predicate);
        }

        public virtual T FindById(int id)
        {
            return repository.FindById(id);
        }

        public virtual ICollection<T> Get()
        {
            return repository.Get();
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> predicate)
        {
            return repository.Get(predicate);
        }

        public virtual void Save(T obj)
        {
            repository.Save(obj);
        }
        public virtual void Save(List<T> obj)
        {
            repository.Save(obj);
        }

        public virtual void Dispose()
        {
            repository.Dispose();
        }
    }
}
