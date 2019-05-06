using System.Net.Http;
using System.Threading.Tasks;

namespace projekt
{
    class GeocodingConnection
    {
        static string apiKey = "42625def07f54b719f67354858a9a623";
        static string apiBaseUrl = "https://api.opencagedata.com/geocode/v1/xml?q=";

        public static async Task<string> LoadDataAsync(string cityName)
        {
            string apiCall = apiBaseUrl + cityName + "&key=" + apiKey;
            Task<string> result;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(apiCall))
            using (HttpContent content = response.Content)
            {
                result = content.ReadAsStringAsync();
            }
            return await result;
        }
    }
}
