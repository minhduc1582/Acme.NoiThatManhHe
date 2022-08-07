using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Designs
{
    public interface IDesignTypeRepository : IRepository<DesignType, Guid>
    {
    }
}
