using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps
{
    public class RestService
    {
        HttpClient _client;

        public RestService() => _client = new HttpClient();

        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = new();

            try
            {
                var response = await _client.GetAsync(query);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonSerializer.Deserialize<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return weatherData;
        }
    }
}
