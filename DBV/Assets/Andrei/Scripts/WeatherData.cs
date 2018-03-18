class WeatherData
{

    private string city;
    private float temp;
    private string weatherDescription;
    private float weatherDescriptionCode;
    private float clouds;
    private string precipitation;

    public void CheckWeather()
    {
        WeatherAPI DataAPI = new WeatherAPI();
        temp = DataAPI.GetTemp();
        weatherDescription = DataAPI.GetWeatherDescrip();
        weatherDescriptionCode = DataAPI.GetWeatherDescripCode();
        clouds = DataAPI.GetClouds();
        precipitation = DataAPI.GetPrecipitation();
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }
    public float Temp
    {
        get { return temp; }
        set { temp = value; }
    }

    public string Description
    {
        get { return weatherDescription; }
        set { weatherDescription = value; }
    }

    public float DescriptionCode
    {
        get { return weatherDescriptionCode; }
        set { weatherDescriptionCode = value; }
    }

    public float Clouds
    {
        get { return clouds; }
        set { clouds = value; }
    }

    public string Precipitation
    {
        get { return precipitation; }
        set { precipitation = value; }
    }
}
