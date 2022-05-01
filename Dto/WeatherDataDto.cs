using System.Text;

namespace IisClient.Dto
{
    internal class WeatherDataDto
    {
        public string temp { get; set; }
        public string humidity { get; set; }
        public string windSpeed { get; set; }
        public string pressure { get; set; }
        public string weather { get; set; }
        public string date { get; set; }
        public string cityName { get; set; }
        public string countryName { get; set; }
        public string errorMessage { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Data for city {cityName} for {date}: \n");
            sb.Append($"\t temp: {temp} \n");
            sb.Append($"\t humidity: {humidity} \n");
            sb.Append($"\t wind peed: {windSpeed} \n");
            sb.Append($"\t pressure: {pressure} \n");
            sb.Append($"\t weather: {weather} \n");

            return sb.ToString();
        }
    }
}
