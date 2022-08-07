using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.NoiThatManhHe.Pages;

[Collection(NoiThatManhHeTestConsts.CollectionDefinitionName)]
public class Index_Tests : NoiThatManhHeWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
