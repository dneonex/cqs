using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace Recruitment.IntegrationTests
{
    internal class RecruitmentApplication : WebApplicationFactory<Program>
    {
        private readonly string _environment;

        public RecruitmentApplication(string environment = "Development")
        {
            _environment = environment;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment(_environment);

            return base.CreateHost(builder);
        }
    }
}
