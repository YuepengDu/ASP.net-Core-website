using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Repository
{
    interface IDataRepository<TEntity,TKey> where TEntity : class
    {
        IEnumerable<TEntity> All();
        TKey Add(TEntity entity);
        TEntity Get(TKey id);
        TKey Update(TKey id, TEntity entity);
        TKey Delete(TKey id);
    }
}
