﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Products
{
    public interface IProductTypeRepository : IRepository <ProductType, Guid>
    {
    }
}
