using System.Collections.Generic;

namespace CamCecilCom.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}