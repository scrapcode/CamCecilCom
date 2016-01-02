using System.Collections.Generic;
using CamCecilCom.Models;

namespace CamCecilCom.Data.Repository
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAll();
    }
}