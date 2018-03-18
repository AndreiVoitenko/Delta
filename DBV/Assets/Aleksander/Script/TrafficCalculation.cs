using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCalculation : MonoBehaviour {
    public int length;
    private List<Collider> dudes; //this is so triggering, this is discrimination against women. What is a student is a girl? Then what? I bet  you did not think about that you horrible programmer you. About to sue your ass for 50000000 dollars because yes.
    Color myColor = new Color();
    // Use this for initialization
    void Start () {

        ColorUtility.TryParseHtmlString("#CFCFCFFF", out myColor);
        dudes = new List<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        //now to figure out when is traffic density bad and when it is fine

        if (dudes.Count/length < 25)
        {
           gameObject.GetComponent<Renderer>().material.color = Color.Lerp(myColor, Color.green, Mathf.PingPong(Time.time, 1));

        }
        else if (dudes.Count/length < 55)
        {

            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(myColor, Color.yellow, Mathf.PingPong(Time.time, 1));

        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(myColor, Color.red, Mathf.PingPong(Time.time, 1));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!dudes.Contains(other))
        {
            dudes.Add(other);
        }


    }
    void OnTriggerExit(Collider other)
    {
        if (dudes.Contains(other))
            dudes.Remove(other);
        
        
    }

}
