using OlSoftwareFront.Model;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace OlSoftwareFront.DataAccess
{
    public class AutenticationService
    {




        public async Task<UserTokenResponse> Autentication(Autentication autentication)
        {
            var result = new UserTokenResponse();
            var json = JsonSerializer.Serialize(autentication);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();  
            var response = await httpClient.PostAsync("https://localhost:7014/api/Authentication/Authentication", content);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<UserTokenResponse>(responseString);
                return result;
            }             
            return null;
        }
    }
}
