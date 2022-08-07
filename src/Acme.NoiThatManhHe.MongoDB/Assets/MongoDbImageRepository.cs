using Acme.NoiThatManhHe.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Acme.NoiThatManhHe.Assets
{
    public class MongoDbImageRepository
        : MongoDbRepository<NoiThatManhHeMongoDbContext, Image, Guid>,
        IImageRepository
    {
        public MongoDbImageRepository(IMongoDbContextProvider<NoiThatManhHeMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Image>> GetListAsync(
            int skipCount,
            int maxResultCount, 
            string sorting, 
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Image, IMongoQueryable<Image>>(
                    !filter.IsNullOrWhiteSpace(),
                    image => image.GenericId.Equals(filter)
                )
                .As<IMongoQueryable<Image>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
