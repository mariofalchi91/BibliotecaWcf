using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("api client");

            HttpClient client = new HttpClient();
            #region get

            HttpRequestMessage httpReq = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44373/api/") //url delle api
            };

            HttpResponseMessage httpResponse = await client.SendAsync(httpReq);

            if(httpResponse.IsSuccessStatusCode)
            {
                string jsonData = await httpResponse.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<LibroContract>>(jsonData);

                foreach (var item in results)
                {
                    Console.WriteLine($"{item.Id} - {item.Titolo} - {item.Autore}");
                }

            }
            #endregion
        }
    }
}
