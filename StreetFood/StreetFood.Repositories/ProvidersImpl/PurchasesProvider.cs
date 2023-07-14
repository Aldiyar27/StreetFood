using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.ProvidersImpl
{
    public class PurchasesProvider : IPurchasesProvider
    {
        private IPurchasesRepository purchasesRepository;
        public PurchasesProvider(IPurchasesRepository purchasesRepository)
        {
            this.purchasesRepository = purchasesRepository;
        }

        public void AddPurchase(PurchaseBO purchaseBO)
        {
            Purchase purchase = new Purchase();
            purchase.Id_Ingredient = purchaseBO.Id_Ingredient;
            purchase.count = purchaseBO.count;
            purchase.Date = purchaseBO.Date;
            purchase.Parther = purchaseBO.Parther;
            purchase.Price = purchaseBO.Price;
            purchase.Comment = purchaseBO.Comment;

            purchasesRepository.AddPurchase(purchase);
        }
    }
}
