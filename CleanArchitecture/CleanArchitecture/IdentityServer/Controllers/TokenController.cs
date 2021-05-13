using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        [Route("authorize")]
        [HttpGet]
        public async Task<IActionResult> GenerateToken()
        {
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient httpClient = new HttpClient();
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "http://localhost:6000/connect/token",
                ClientId = "ClientId",
                ClientSecret = "ClientSecret",
                Scope = "TestAPIGateway.access"
            });
            return Ok(tokenResponse.Json);
        }
    }
}
