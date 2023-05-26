// See https://aka.ms/new-console-template for more information

using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace az204_auth
{
    class Program
    {
        private const string _clientId = "b16be183-f548-4694-bd44-df140263fb87";
        private const string _tenantId = "a8e4a496-39f6-48e4-9bbc-e10627f60d64";
        public static async Task Main(string[] args) {

        var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

        string[] scopes = { "user.read" };

        AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

        Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}
