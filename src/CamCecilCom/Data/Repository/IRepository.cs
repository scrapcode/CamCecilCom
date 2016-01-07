using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamCecilCom.Data.Repository
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <typeparam name="TClass">Repository's type.</typeparam>
    /// <typeparam name="TPk">Repository type's primary key type.</typeparam>
    public interface IRepository<TClass, in TPk> where TClass : class
    {
        IEnumerable<TClass> GetAll();
        IEnumerable<TClass> GetAllWithChildren();
        TClass GetById(TPk id);
    }
}
