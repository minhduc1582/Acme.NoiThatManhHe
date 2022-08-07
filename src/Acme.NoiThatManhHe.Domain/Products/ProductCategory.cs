﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.NoiThatManhHe.Products
{
    public class ProductCategory : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

    }
}
