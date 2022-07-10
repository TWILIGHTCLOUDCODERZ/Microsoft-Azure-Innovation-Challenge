using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using System.IO;

namespace CSHttpClientSample
{
    static class Program
    {
        static void Main()
        {
            MakeRequest();
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }

        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(String.Empty);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "de6d959dfad1401dac4ad31689b39f46");



            var uri = "https://raptorzapi.azure-api.net/Raptor-API/topics";

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            else
                Console.WriteLine("Quota Limit exceeds: "+ response.ReasonPhrase);

        }
    }
}

