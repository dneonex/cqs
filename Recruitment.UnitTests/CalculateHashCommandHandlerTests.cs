using Moq;
using NUnit.Framework;
using Recruitment.Contracts.Commands;
using Recruitment.Contracts.Models;
using Recruitment.Handlers;
using System.Threading.Tasks;

namespace Recruitment.UnitTests
{
    [TestFixture]
    public class CalculateHashCommandHandlerTests
    {
        [Test]
        public async Task HandleAsync_Command_ReturnsTaskResult()
        {
            var calculateHashCommandMock = new Mock<CalculateHashCommand>();
            var handler = new CalculateHashCommandHandler();

            var result = await handler.HandleAsync(calculateHashCommandMock.Object, new System.Threading.CancellationToken());

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Result);
            Assert.AreEqual(typeof(HashedResult), result.GetType());
        }
    }
}