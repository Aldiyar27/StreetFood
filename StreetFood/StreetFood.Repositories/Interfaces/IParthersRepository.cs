﻿using StreetFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Repositories.Interfaces
{
    public interface IParthersRepository
    {
        void AddParther(Parther partherEntity);
    }
}
