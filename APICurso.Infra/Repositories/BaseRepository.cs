using WebApresentacao.Domain.Entities;
using WebApresentacao.Infra.Contexts;
using WebApresentacao.Infra.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebApresentacao.Infra.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private readonly Context context;
        public BaseRepository(Context _context)
        {
            context = _context;
        }

        public virtual bool Delete(T obj)
        {
            bool result = false;
            if (obj != null)
            {

                try
                {
                    context.Remove(obj);
                    context.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }

            }
            return result;

        }

        public virtual bool Delete(int id)
        {
            return this.Delete(this.FindById(id));
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return (T)context.Set<T>().FirstOrDefault(predicate);

        }

        public virtual T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual ICollection<T> Get()
        {
            return context.Set<T>().ToList() as ICollection<T>;
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> predicate)
        {

            return context.Set<T>().Where(predicate).ToList();

        }


        public virtual void Save(T obj)
        {
            try
            {

                var tipoEntity = obj.GetType().ToString();
                if (tipoEntity == "APICurso.Domain.Entities.Cliente")
                {
                    string pk = "Id";
                    var pkValue = obj.GetType().GetProperty(pk).GetValue(obj, null);
                    if ((pkValue is int && Convert.ToInt32(pkValue) > 0) ||
                    (pkValue is string && !string.IsNullOrEmpty(pkValue.ToString())))
                    {
                        context.Set<T>().Update(obj);
                    }
                    else
                    {
                        context.Set<T>().Add(obj);
                    }
                    context.SaveChanges();
                }
                else
                {
                    string pk = "Id";
                    var pkValue = obj.GetType().GetProperty(pk).GetValue(obj, null);
                    if ((pkValue is int && Convert.ToInt32(pkValue) > 0) ||
                    (pkValue is string && !string.IsNullOrEmpty(pkValue.ToString())))
                    {
                        context.Set<T>().Update(obj);
                    }
                    else
                    {
                        context.Set<T>().Add(obj);
                    }
                    context.SaveChanges();
                } 
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public virtual void Save(List<T> list)
        {
            string pk = "Id";

            List<T> saveList = list.Where(obj =>
            {
                var pkValue = obj.GetType().GetProperty(pk).GetValue(obj, null);
                return !((pkValue is int && Convert.ToInt32(pkValue) > 0) ||
                    (pkValue is string && !string.IsNullOrEmpty(pkValue.ToString())));
            }).ToList();

            List<T> updateList = list.Where(obj =>
            {
                var pkValue = obj.GetType().GetProperty(pk).GetValue(obj, null);
                return ((pkValue is int && Convert.ToInt32(pkValue) > 0) ||
                    (pkValue is string && !string.IsNullOrEmpty(pkValue.ToString())));
            }).ToList();

            context.Set<T>().UpdateRange(updateList);
            context.Set<T>().AddRange(saveList);
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }

        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(true);
        }
    }

}
