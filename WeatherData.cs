using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MobileApps
{
    public class WeatherData
    {
        public string TestBinding = "Hello World";
        [JsonPropertyName("cod")]
        public string Cod { get; set; }

        [JsonPropertyName("message")]
        public int Message { get; set; }

        [JsonPropertyName("cnt")]
        public int Cnt { get; set; }

        [JsonPropertyName("list")]
        public List<List> RootList { get; set; }

        [JsonPropertyName("city")]
        public City RootCity { get; set; }

        public class City
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("coord")]
            public Coord Coord { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("population")]
            public int Population { get; set; }

            [JsonPropertyName("timezone")]
            public int Timezone { get; set; }

            [JsonPropertyName("sunrise")]
            public int Sunrise { get; set; }
            public DateTime SunriseTime
            {
                get
                {
                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    dateTime = dateTime.AddSeconds(Sunrise).ToLocalTime();
                    return dateTime;
                }
            }

            [JsonPropertyName("sunset")]
            public int Sunset { get; set; }
            public DateTime SunsetTime
            {
                get
                {
                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    dateTime = dateTime.AddSeconds(Sunset).ToLocalTime();
                    return dateTime;
                }
            }
        }

        public class Clouds
        {
            [JsonPropertyName("all")]
            public int All { get; set; }
        }

        public class Coord
        {
            [JsonPropertyName("lat")]
            public double Lat { get; set; }

            [JsonPropertyName("lon")]
            public double Lon { get; set; }
        }

        public class List
        {
            [JsonPropertyName("dt")]
            public int Dt { get; set; }

            [JsonPropertyName("main")]
            public Main Main { get; set; }

            [JsonPropertyName("weather")]
            public List<Weather> Weather { get; set; }

            [JsonPropertyName("clouds")]
            public Clouds Clouds { get; set; }

            [JsonPropertyName("wind")]
            public Wind Wind { get; set; }

            [JsonPropertyName("visibility")]
            public int Visibility { get; set; }

            [JsonPropertyName("pop")]
            public double Pop { get; set; }

            [JsonPropertyName("sys")]
            public Sys Sys { get; set; }

            [JsonPropertyName("dt_txt")]
            public string DtTxt { get; set; }

            [JsonPropertyName("rain")]
            public Rain Rain { get; set; }
        }

        public class Main
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("feels_like")]
            public double FeelsLike { get; set; }

            [JsonPropertyName("temp_min")]
            public double TempMin { get; set; }

            [JsonPropertyName("temp_max")]
            public double TempMax { get; set; }

            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }

            [JsonPropertyName("sea_level")]
            public int SeaLevel { get; set; }

            [JsonPropertyName("grnd_level")]
            public int GrndLevel { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }

            [JsonPropertyName("temp_kf")]
            public double TempKf { get; set; }
        }

        public class Rain
        {
            [JsonPropertyName("3h")]
            public double _3h { get; set; }
        }

        public class Sys
        {
            [JsonPropertyName("pod")]
            public string Pod { get; set; }
        }

        public class Weather
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("icon")]
            public string Icon { get; set; }
        }

        public class Wind
        {
            [JsonPropertyName("speed")]
            public double Speed { get; set; }

            [JsonPropertyName("deg")]
            public int Deg { get; set; }

            [JsonPropertyName("gust")]
            public double Gust { get; set; }
        }


    }
}
