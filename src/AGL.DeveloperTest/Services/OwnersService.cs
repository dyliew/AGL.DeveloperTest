using System.Net.Http;
using System.Threading.Tasks;
using AGL.DeveloperTest.Models;
using Newtonsoft.Json;

namespace AGL.DeveloperTest.Services
{
    public class OwnersService : IOwnersService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public OwnersService(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<Owner[]> GetOwners()
        {
            var response = await _httpClient.GetAsync(_endpoint);
            response.EnsureSuccessStatusCode();

            var content = JsonConvert.DeserializeObject<Owner[]>(await response.Content.ReadAsStringAsync()) ?? new Owner[] { };

            return content;
        }
    }
}