using System;

using CamCecilCom.Models;
using System.Linq;
using System.Collections.Generic;

namespace CamCecilCom.Data.Repository
{
    public class UserRepository : IRepository<User, string>
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Any()
        {
            return _context.Users.Any();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .OrderBy(u => u.UserName)
                .ToList();
        }

        public IEnumerable<User> GetAllWithChildren()
        {
            return GetAll();
        }

        public User GetById(string Id)
        {
            return _context.Users
                .Where(u => u.Id == Id)
                .FirstOrDefault();
        }

        public void Add(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _context.Users.Add(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
