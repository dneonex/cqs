using CommandQuery;
using Recruitment.Common.Helpers;
using Recruitment.Contracts.Commands;
using Recruitment.Contracts.Models;

namespace Recruitment.Handlers
{
    public class CalculateHashCommandHandler : ICommandHandler<CalculateHashCommand, HashedResult>
    {
        public async Task<HashedResult> HandleAsync(CalculateHashCommand command, CancellationToken cancellationToken)
        {
            var result = new HashedResult();

            try
            {
                result.Result = HashCalculator.CalculateSha256Hash(command.Login + command.Password) ?? String.Empty;
            }
            catch
            {
                // Add logging
            }

            return await Task.FromResult(result);
        }
    }
}