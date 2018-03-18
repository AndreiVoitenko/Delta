using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    public Light sun;
    float sunlIntensity;
    public bool clouds;

    // Use this for initialization
    void Start () {
        sunlIntensity = sun.intensity;
    }
	
	// Update is called once per frame
	void Update () {
        if (clouds)
        {
            sun.intensity = sunlIntensity*0.7f;
        }
        else
        {
            sun.intensity = 1;
        }
        

		
	}
}
