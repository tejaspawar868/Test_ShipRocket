using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShiprocketTest.Classes
{
    public class ShiprocketService
    {
        private readonly string baseUrl = "https://apiv2.shiprocket.in/v1/external/";
        private string token;

        public async Task<string> GetAuthToken()
        {
            var client = new HttpClient();
            var requestBody = new
            {
                email = "your-email@example.com",
                password = "your-password"
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}auth/login", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);
            token = responseObject.token;
            return token;
        }
    }
}