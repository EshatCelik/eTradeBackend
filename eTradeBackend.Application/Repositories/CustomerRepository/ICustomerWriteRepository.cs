﻿using eTradeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Repositories.CustomerRepository
{
    public interface ICustomerWriteRepository:IWriteRepository<Customer>
    {
    }
}
