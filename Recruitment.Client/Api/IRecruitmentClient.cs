namespace Recruitment.Client.Api
{
    public interface IRecruitmentClient
    {
        Task CalculateHashCommandAsync(CalculateHashCommand body, CancellationToken cancellationToken);
    }
}
