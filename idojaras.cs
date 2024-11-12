using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter_a_project_name
{
    public interface Iidojaras
    {
        double GetTemperature();
        double GetHumidity();
        double GetWindSpeed();
        string GetWeatherCondition();
    }
    public abstract class WeatherService : Iidojaras
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string WeatherCondition { get; set; }
        public string City { get; set; }
        public WeatherService(string city, double tempereture, double humidity, double windspeed, string weathercondition) : base()
        {
            City = city;
            Temperature = tempereture;
            Humidity = humidity;
            WindSpeed = windspeed;
            WeatherCondition = weathercondition;
        }
        public double GetTemperature()
        {
            return Temperature;
        }
        public double GetHumidity()
        {
            return Humidity;
        }
        public double GetWindSpeed()
        {
            return WindSpeed;
        }
        public string GetWeatherCondition()
        {
            return WeatherCondition;
        }
        public abstract void ShowWeather(Iidojaras idojaras);
    }
    public class CityWeather : WeatherService
    {
        public string city { get; set; }
        public CityWeather(string city, double tempereture, double humidity, double windspeed, string weathercondition) : base(city, tempereture, humidity, windspeed, weathercondition)
        {
            this.city = city;
        }
        public override void ShowWeather(Iidojaras idojaras)
        {
            Console.WriteLine("~~Tihamér Weathers ~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"{city} időjárása: ");
            Console.WriteLine($"Hőmérséklet: {idojaras.GetTemperature()}°C");
            Console.WriteLine($"Páratartalom: {idojaras.GetHumidity()}%");
            Console.WriteLine($"Szélsebesség: {idojaras.GetWindSpeed()} km/h");
            Console.WriteLine($"Időjárás állapota: {idojaras.GetWeatherCondition()}");
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
    public class ForecastWeather : WeatherService
    {
        public string city { get; set; }
        public ForecastWeather(string city, double tempereture, double humidity, double windspeed, string weathercondition) : base(city, tempereture, humidity, windspeed, weathercondition)
        {
            this.city = city;
        }
        public override void ShowWeather(Iidojaras idojaras)
        {
            Console.WriteLine("~~Tihamér Weathers ~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"{city} időjárás előrejelzése: ");
            Console.WriteLine($"Hőmérséklet: {idojaras.GetTemperature()}°C");
            Console.WriteLine($"Páratartalom: {idojaras.GetHumidity()}%");
            Console.WriteLine($"Szélsebesség: {idojaras.GetWindSpeed()} km/h");
            Console.WriteLine($"Időjárás állapota: {idojaras.GetWeatherCondition()}");
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }

    public class City
    {
        public string city;
        public WeatherService cityw;
        public WeatherService forecaastw;
        public City(string city, WeatherService cityw, WeatherService forecastw)
        {
            this.city = city;
            this.cityw = cityw;
            this.forecaastw = forecastw;
        }
    }

    internal class Program
    {
        static List<City> cities = new List<City>();
        static WeatherService cityw;
        static WeatherService forecastw;
        static public void ListCities()
        {
            Console.WriteLine("Az összes város: ");
            foreach (var city in cities)
            {
                Console.WriteLine($"\t{city.city}");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("~~Tihamér Weathers ~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            cityw = new CityWeather("Fehérgyarmat", 24, 2, 4, "Hűvös");
            forecastw = new ForecastWeather("Fehérgyarmat", 24, 2, 4, "Hűvös");
            cities.Add(new City("Fehérgyarmat", cityw, forecastw));

            cityw = new CityWeather("Győrtelek", 26, 4, 3.4, "Napos");
            forecastw = new ForecastWeather("Győrtelek", 26, 4, 3.4, "Napos");
            cities.Add(new City("Győrtelek", cityw, forecastw));

            cityw = new CityWeather("Mátészalka", 20, 2, 4, "Hűvös");
            forecastw = new ForecastWeather("Mátészalka", 20, 2, 4, "Hűvös");
            cities.Add(new City("Mátészalka", cityw, forecastw));

            cityw = new CityWeather("Tunyogmatolcs", 23, 3, 4.2, "Hűvös");
            forecastw = new ForecastWeather("Tunyogmatolcs", 23, 3, 4.2, "Hűvös");
            cities.Add(new City("Tunyogmatolcs", cityw, forecastw));


            foreach (var s in cities)
            {
                bool run = true;
                while (run)
                {
                    ListCities();
                    Console.WriteLine($"[1] - \t{s.city} időjárása");
                    Console.WriteLine($"[2] - \t{s.city} előrejelzése");
                    if (cities[cities.Count-1].city != s.city)
                        Console.WriteLine("[3] - \tKövetkező város");
                    else
                        Console.WriteLine("[3] - \tKilépés a programból");
                    string ans = Console.ReadLine();
                    switch (ans)
                    {
                        case ("1"):
                            Console.Clear();
                            s.cityw.ShowWeather(s.cityw);
                            break;
                        case ("2"):
                            Console.Clear();
                            s.forecaastw.ShowWeather(s.forecaastw);
                            break;
                        default:
                            run = false;
                            Console.Clear();
                            Console.WriteLine("~~Benedek Weathers ~~~~~~~~~~~~~~~~~~\n");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                            break;
                    }
                }
            }
        }
    }
}
