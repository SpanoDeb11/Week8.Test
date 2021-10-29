using AcademyG.Week8.Esercitazione.Core.Entities;
using AcademyG.Week8.Esercitazione.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week8.Essercitazione.EF.Repositories
{
    public class UserRepositoryEF : IUserRepository
    {

        private readonly RestaurantContext _ctx;

        public UserRepositoryEF(RestaurantContext ctx)
        {
            this._ctx = ctx;
        }

        public bool Add(User entity)
        {
            if (entity == null)
                return false;

            // l'email deve essere unica
            if (this._ctx.Users.FirstOrDefault(u => u.Email.Equals(entity.Email)) != null)
                return false;

            this._ctx.Users.Add(entity);
            this._ctx.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Fetch(Func<User, bool> filter)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return this._ctx.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
