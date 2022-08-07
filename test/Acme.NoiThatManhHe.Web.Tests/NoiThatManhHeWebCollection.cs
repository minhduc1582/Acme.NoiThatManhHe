using Acme.NoiThatManhHe.MongoDB;
using Xunit;

namespace Acme.NoiThatManhHe;

[CollectionDefinition(NoiThatManhHeTestConsts.CollectionDefinitionName)]
public class NoiThatManhHeWebCollection : NoiThatManhHeMongoDbCollectionFixtureBase
{

}
