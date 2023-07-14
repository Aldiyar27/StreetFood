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
    public class PartherRepository : IParthersRepository
    {
        public void AddParther(Parther parthers)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                streetFoodDbContext.Add(parthers);
                streetFoodDbContext.SaveChanges();
            }
        }
    }
}
