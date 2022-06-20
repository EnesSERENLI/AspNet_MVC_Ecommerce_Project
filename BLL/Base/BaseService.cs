using Core.BaseRepository;
using Core.Service;
using DAL.Context;
using DAL.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Base
{
    public class BaseService<T> : ICoreService<T> where T : EntityRepository
    {
        ECommerceContext context = DbContextSingleton.Context;
        public string Add(T model)
        {
            try
            {
                model.ID = Guid.NewGuid();
                context.Set<T>().Add(model);
                context.SaveChanges();
                return "Data Added!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            bool result = context.Set<T>().Any(exp);
            return result;
        }

        public string Delete(Guid id)
        {
            try
            {
                T deleted = GetById(id);
                if (deleted != null)
                {
                    deleted.Status = Core.Enums.Status.Deleted;
                    Update(deleted);
                    return "Data deleted!";
                }
                else
                {
                    return "Data not foundé";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).ToList();
        }

        public List<T> GetList()
        {
            return context.Set(typeof(T)).Cast<T>().ToList();
        }

        public string RemoveForce(T model)
        {
            try
            {
                context.Set<T>().Remove(model);
                context.SaveChanges();
                return "Data is permanently deleted.!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(T model)
        {
            try
            {
                T updated = GetById(model.ID);
                DbEntityEntry entity = context.Entry(updated);
                entity.CurrentValues.SetValues(model);

                //context.Entry(updated).State = System.Data.Entity.EntityState.Modified; 
                context.SaveChanges();
                return "Data updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
