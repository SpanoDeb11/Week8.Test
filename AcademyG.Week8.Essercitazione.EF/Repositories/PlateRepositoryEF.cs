using AcademyG.Week8.Esercitazione.Core.Entities;
using AcademyG.Week8.Esercitazione.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week8.Essercitazione.EF.Repositories
{
    public class PlateRepositoryEF : IPlateRepository
    {

        private readonly RestaurantContext _ctx;

        public PlateRepositoryEF(RestaurantContext ctx)
        {
            this._ctx = ctx;
        }

        public bool Add(Plate entity)
        {
            if (entity == null)
                return false;

            this._ctx.Plates.Add(entity);
            this._ctx.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;

            var deleted = this._ctx.Plates.Find(id);

            if (deleted == null)
                return false;

            this._ctx.Plates.Remove(deleted);
            this._ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Plate> Fetch(Func<Plate, bool> filter)
        {
            if (filter == null)
                return this._ctx.Plates.Include(p => p.Menu);

            return this._ctx.Plates.Include(p => p.Menu).Where(filter);
        }

        public Plate GetById(int id)
        {
            if (id <= 0)
                return null;

            return this._ctx.Plates.Include(p => p.Menu).FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Plate entity)
        {
            if (entity == null)
                return false;

            if (this._ctx.Plates.Find(entity.Id) == null)
                return false;

            this._ctx.Entry(entity).State = EntityState.Modified;
            this._ctx.SaveChanges();
            return true;
        }
    }
}
