﻿using Spartacus.BusinessLogic.DBModel;
using Spartacus.Domain.Entities.Membership;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.BusinessLogic.Core
{
    public class CatMgmtApi
    {
        internal bool AddCatAction(CatTable data)
        {
            using (var debil = new CategoryContext())
            {
                var cat = debil.Categories.FirstOrDefault(c => c.Title == data.Title);
                if (cat != null) return false;

                debil.Categories.Add(data);
                debil.SaveChanges();
            }
            return true;
        }

        internal List<CatTable> GetCatsAction()
        {
            List<CatTable> cats;
            using (var debil = new CategoryContext())
            {
                cats = debil.Categories.ToList();
            }
            return cats;
        }

        internal CatTable GetCatByIdAction(int id)
        {
            CatTable cat;
            using (var debil = new CategoryContext())
            {
                cat = debil.Categories.FirstOrDefault(c => c.Id == id);
            }
            return cat;
        }
        
        internal bool UpdateCatAction(CatTable data)
        {
            using (var debil = new CategoryContext())
            {
                var cat = debil.Categories.FirstOrDefault(x => x.Id == data.Id);

                if (cat == null) return false;

                cat.Title = data.Title;
                cat.Description = data.Description;
                cat.PriceOneYear = data.PriceOneYear;
                cat.PriceSixMonths = data.PriceSixMonths;
                cat.PriceThreeMonths = data.PriceThreeMonths;
                cat.PriceOneMonth = data.PriceOneMonth;

                debil.SaveChanges();
            }
            return true;
        }
        
        internal bool DeleteCatByIdAction(int id)
        {
            using (var debil = new CategoryContext())
            {
                var cat = debil.Categories.Find(id);
                if (cat == null) return false;
                debil.Categories.Remove(cat);
                debil.SaveChanges();
            }
            return true;
        }
    }
}
