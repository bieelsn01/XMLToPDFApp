using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace XMLProcessing
{
    public static class APIClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetXMLFromAPIAsync(string apiUrl, string chNFe, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"{apiUrl}?chNFe={chNFe}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
