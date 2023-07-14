using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StreetFood.DAL;
using StreetFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFood.BusinessObjects;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.Implementations
{
    public class PurchaseRepository : IPurchasesRepository
    {
        public void AddPurchase(Purchase purchase)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                streetFoodDbContext.Add(purchase);
                streetFoodDbContext.SaveChanges();
            }
        }
    }
}
