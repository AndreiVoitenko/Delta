using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class DayNightController : MonoBehaviour {
 
    public Light sun;
    private float DayLength = 86400f;
    private float start = 0;
    public float timeSpeed = 1f;
    float sunlIntensity;
    
    void Start() {
        sunlIntensity = sun.intensity;
        DateTime localTime = DateTime.Now;
        var culture = new CultureInfo("en-GB");
        String hours = localTime.Hour.ToString(culture);
        String minutes = localTime.Minute.ToString(culture);
        String seconds = localTime.Second.ToString(culture);
        int start1 = Convert.ToInt32(hours) * 3600 + 3600*2 + Convert.ToInt32(minutes) * 60 + Convert.ToInt32(seconds);
        String start2 = "0." + start1.ToString();
        
        float abc = float.Parse(start2);
        
        start = abc;
       
    }
    
    void Update() {
        UpdateSun();
        start += (Time.deltaTime / DayLength) * timeSpeed;
 
        if (start >= 1) {
            start = 0;
        }
    }
    
    void UpdateSun() {
        //float intensityMultiplier = 1;

        sun.transform.localRotation = Quaternion.Euler((start * 360f) - 90, 170, 0);
        //sun.intensity = sunlIntensity * intensityMultiplier;
    }
}