using Core.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICoreService<T> where T : EntityRepository
    {
        //Add
        string Add(T model);
        //Update
        string Update(T model);
        //Delete
        string Delete(Guid id); //it will be shown as deleted.
        //RemoveForce
        string RemoveForce(T model); //it will indeed be deleted.only admin has this feature
        //Get
        T GetById(Guid id);
        //GetList
        List<T> GetList();
        //Any
        bool Any(Expression<Func<T,bool>> exp);
        //GetDefault
        List<T> GetDefault(Expression<Func<T,bool>> exp);
    }
}
