using CommandQuery;
using Newtonsoft.Json;
using Recruitment.Contracts.Models;

namespace Recruitment.Contracts.Commands
{
    public class CalculateHashCommand : ICommand<HashedResult>
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
