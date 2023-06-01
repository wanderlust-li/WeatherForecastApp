using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecastConsole
{
    class Program
    {
        static async Task Main()
        {
            Console.Write("Enter a city: ");
            string? city = Console.ReadLine();

            try
            {
                string apiKey = ""; // Your OpenWeatherMap API key

                using (HttpClient client = new HttpClient())
                {
                    string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody) ??
                                   throw new InvalidOperationException();

                    string temperature = data.main.temp;
                    string humidity = data.main.humidity;
                    string windSpeed = data.wind.speed;
                    string weatherDescription = data.weather[0].description;
                    DateTime dateTime = DateTime.Now;

                    Console.WriteLine($"City: {city}");
                    Console.WriteLine($"Temperature: {temperature}°C");
                    Console.WriteLine($"Humidity: {humidity}%");
                    Console.WriteLine($"Wind Speed: {windSpeed} m/s");
                    Console.WriteLine($"Weather Description: {weatherDescription}");
                    Console.WriteLine($"Date and Time: {dateTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}