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
    public class ParthersProvider : IParthersProvider
    {
        private IParthersRepository parthersRepository;
        public ParthersProvider(IParthersRepository parthersRepository)
        {
            this.parthersRepository = parthersRepository;
        }

        public void AddParther(PartherBO partherBO)
        {
            Parther parther = new Parther();
            parther.Name = partherBO.Name;
            parther.Adress = partherBO.Adress;
            parther.BIN = partherBO.BIN;
            parthersRepository.AddParther(parther);
        }
    }
}
