using System;
using UnityEngine;

public class main : MonoBehaviour {
    private float temp;
    private string weatherDesc;
    private float weatherCode;
    private float clouds;
    private string precipitation;

    // Use this for initialization
    void Start () {

        WeatherData weather = new WeatherData();
        weather.CheckWeather();
        temp = weather.Temp;
        weatherDesc = weather.Description;
        weatherCode = weather.DescriptionCode;
        clouds = weather.Clouds;
        precipitation = weather.Precipitation;

        Debug.Log("Temp:" + temp);
        Debug.Log("Weather:" + weatherDesc);
        Debug.Log("Weather code:" + weatherCode);
        Debug.Log("Clouds:" + clouds);
        Debug.Log("Precipitation:" + precipitation);

        var startTimeSpan = TimeSpan.Zero;
        var periodTimeSpan = TimeSpan.FromMinutes(1);

        var timer = new System.Threading.Timer((e) =>
        {
            everyMinute();
        }, null, startTimeSpan, periodTimeSpan);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void everyMinute()
    {
        Debug.Log("holohololo");
        float Newtemp;
        string NewweatherDesc;
        float NewweatherCode;
        float Newclouds;
        string Newprecipitation;

        

        WeatherData Newweather = new WeatherData();
        Newweather.CheckWeather();

        Newtemp = Newweather.Temp;
        NewweatherDesc = Newweather.Description;
        NewweatherCode = Newweather.DescriptionCode;
        Newclouds = Newweather.Clouds;
        Newprecipitation = Newweather.Precipitation;

        if (temp != Newtemp)
        {
            temp = Newtemp;
        }

        if (weatherDesc != NewweatherDesc)
        {
            weatherDesc = NewweatherDesc;
        }

        if (weatherCode != NewweatherCode)
        {
            weatherCode = NewweatherCode;

            if (200 <= weatherCode && weatherCode <= 531)
            {
                // rain (rain, clouds)
                Debug.Log("rain");
            }

            if (600 <= weatherCode && weatherCode <= 622)
            {
                // snow (snow, clouds)
                Debug.Log("snow");
            }

            if (800 == weatherCode)
            {
                // sun
                Debug.Log("sun");
            }

            if (801 <= weatherCode && weatherCode <= 804)
            {
                // clouds
                Debug.Log("clouds");
            }

        }

        if (clouds != Newclouds)
        {
            clouds = Newclouds;
            //change sun brightness
        }

        if (precipitation != Newprecipitation)
        {
            precipitation = Newprecipitation;
        }
    }
}
