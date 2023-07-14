using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFood.Entities;

namespace StreetFood.BusinessLogic.Implementations
{
    public class PurchasesService : IPurchasesService
    {
        private IPurchasesProvider purchasesProvider;

        public PurchasesService(IPurchasesProvider purchasesProvider)
        {
            this.purchasesProvider = purchasesProvider;
        }


        public void AddPurchase(PurchaseBO purchaseBO)
        {
            purchasesProvider.AddPurchase(purchaseBO);
        }
    }
}
