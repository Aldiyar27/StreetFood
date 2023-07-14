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
    public class ParthersService : IParthersService
    {
        private IParthersProvider parthersProvider;

        public ParthersService(IParthersProvider parthersProvider)
        {
            this.parthersProvider = parthersProvider;
        }

        public void AddParther(PartherBO partherBO)
        {
            parthersProvider.AddParther(partherBO);
        }
    }
}
