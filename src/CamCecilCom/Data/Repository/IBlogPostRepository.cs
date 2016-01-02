using System.Collections.Generic;
using CamCecilCom.Models;

namespace CamCecilCom.Data.Repository
{
    public interface IRepository
    {
        IEnumerable<BlogPost> GetAll();
        IEnumerable<BlogPost> GetAllWithAuthors();
    }
}