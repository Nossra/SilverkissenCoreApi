using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using silverkissen.Models;

namespace silverkissen.DataAccess
{
    public class CatEFCoreImplementation : ICatDao
    {

        private readonly SilverkissenContext _db;

        public void CreateCat(Cat cat)
        {
            _db.Cats.Add(cat);
            _db.SaveChanges();
        }

        public void DeleteCat(Cat cat)
        {
            _db.Cats.Remove(cat);
            _db.SaveChanges();
        }

        public List<Cat> FindAllCats()
        {
            List<Cat> cats = _db.Cats.ToList();
            return cats;
        }

        public Cat FindCatById(int id)
        {
            return _db.Cats.SingleOrDefault(x => x.Id == id);
        }

        public void UpdateCat(Cat cat)
        {
            _db.Entry(cat).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
