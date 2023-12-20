using OlSoftwareFront.Model;
using System.Text.Json;
using System.Text;
using System.Net.Http;

using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;

namespace OlSoftwareFront.DataAccess
{
    public class AspiranteService
    {


        public async Task<List<AspirantesResponse>> GetAspirantes(string token)
        {
            var result =new  List<AspirantesResponse>();

			
			byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
			var tokenWithSlash = WebEncoders.Base64UrlEncode(tokenBytes);

		
 

			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			var response = await httpClient.GetAsync("https://localhost:7014/api/Aspirante/GetAll");
		 
			if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<AspirantesResponse>>(responseString);
                return result;
            }

            return result;
        }
    }
}
