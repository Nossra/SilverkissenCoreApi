using silverkissen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.DataAccess
{
    interface ICatDao
    {
        void CreateCat(Cat cat);
        void UpdateCat(Cat cat);
        void DeleteCat(Cat cat);
        Cat FindCatById(int id);
        List<Cat> FindAllCats(); 
    }
}
