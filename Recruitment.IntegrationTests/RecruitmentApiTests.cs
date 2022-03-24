using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;

namespace Recruitment.IntegrationTests
{
    [TestFixture]
    public class RecruitmentApiTests
    {
        private RecruitmentApplication Application;

        [SetUp]
        public void SetUp()
        {
            Application = new RecruitmentApplication();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Dispose();
        }

        [Test]
        public async Task CalculateHashCommand_NormalRequest_ShouldBeSuccess()
        {
            var content = new StringContent("{ \"login\": \"TestLogin\", \"password\": \"TestPassword\" }", Encoding.UTF8, "application/json");
            var client = Application.CreateClient();

            var result = await client.PostAsync("/api/command/CalculateHashCommand", content);

            result.EnsureSuccessStatusCode();
            (await result.Content.ReadAsStringAsync()).Should().NotBeEmpty();
        }

        [Test]
        public async Task CalculateHashCommand_IncorrectRequest_ShouldReturnNotFound()
        {
            var content = new StringContent("{ \"some\": \"text\" }", Encoding.UTF8, "application/json");
            var client = Application.CreateClient();

            var result = await client.PostAsync("/api/command/NonExistingCommand", content);

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            (await result.Content.ReadAsStringAsync()).Should().BeEmpty();
        }
    }
}
