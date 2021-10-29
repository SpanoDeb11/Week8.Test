using AcademyG.Week8.Esercitazione.Core.Entities;
using AcademyG.Week8.Esercitazione.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week8.Essercitazione.EF.Repositories
{
    public class MenuRepositoryEF : IMenuRepository
    {

        private readonly RestaurantContext _ctx;

        public MenuRepositoryEF(RestaurantContext ctx)
        {
            this._ctx = ctx;
        }

        public bool Add(Menu entity)
        {
            if (entity == null)
                return false;

            // il nome del menu è unique
            if (this._ctx.Menus.FirstOrDefault(m => m.Name.Equals(entity.Name)) != null)
                return false;

            this._ctx.Menus.Add(entity);
            this._ctx.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;

            var deleted = this._ctx.Menus.Find(id);

            if (deleted == null)
                return false;

            this._ctx.Menus.Remove(deleted);
            this._ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Menu> Fetch(Func<Menu, bool> filter)
        {
            if (filter == null)
                return this._ctx.Menus.Include(m => m.Plates);

            return this._ctx.Menus.Include(m => m.Plates).Where(filter);
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;

            // uso firstordefault al posto di find per poter usare la include
            return this._ctx.Menus.Include(m => m.Plates).FirstOrDefault(m => m.Id == id);
        }

        public Menu GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            return this._ctx.Menus.Include(m => m.Plates).FirstOrDefault(m => m.Name.Equals(name));
        }

        public bool Update(Menu entity)
        {
            if (entity == null)
                return false;

            if (this._ctx.Menus.Find(entity.Id) == null)
                return false;

            this._ctx.Entry(entity).State = EntityState.Modified;
            this._ctx.SaveChanges();
            return true;
        }
    }
}
