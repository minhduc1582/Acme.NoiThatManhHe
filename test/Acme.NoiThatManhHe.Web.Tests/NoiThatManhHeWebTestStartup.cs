using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Acme.NoiThatManhHe;

public class NoiThatManhHeWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<NoiThatManhHeWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
