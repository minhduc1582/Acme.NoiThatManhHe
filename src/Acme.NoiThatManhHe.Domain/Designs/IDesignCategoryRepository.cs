using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Designs
{
    public interface IDesignCategoryRepository : IRepository<DesignCategory, Guid>
    {
        Task<List<DesignCategory>> GetByDesignTypeId(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null);
    }
}
