﻿using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFood.Entities; 

namespace StreetFood.Providers
{
    public interface IParthersProvider
    {
        void AddParther(PartherBO partherBO);
    }
}
