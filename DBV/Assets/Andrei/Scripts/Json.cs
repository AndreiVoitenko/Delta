using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Json : MonoBehaviour
{
    public GameObject snow;
    public GameObject rain;

    private string controll;
    public string jsonString;

    JsonString json;

    public class JsonString
    {

        public string source; // room number
        public string text;
        public string time;
        public string type;
        public string NewParameter;

    }

    // Use this for initialization
    void Start()
    {

        // Change room subject
        //jsonString = "{\"source\":\"2024\",\"text\":\"timetable schanged\",\"time\":\"2013-07-19T09:07:22.598+02:00\",\"type\":\"newSubject\",\"NewSubject\":\"Prog. keeled\"}";

        // Change weather
        //jsonString = "{\"source\":\"outside\",\"text\":\"weather schanged\",\"time\":\"2013-07-19T09:07:22.598+02:00\",\"type\":\"newWeather\",\"NewParameter\":\"clouds\"}";

        // Change number of students in room
        jsonString = "{\"source\":\"2006\",\"text\":\"people number schanged\",\"time\":\"2013-07-19T09:07:22.598+02:00\",\"type\":\"newNumberOfPeople\",\"NewParameter\":\"1\"}";
    }

    // Update is called once per frame
    void Update()
    {

        if (controll != jsonString)
        {
            json = JsonUtility.FromJson<JsonString>(jsonString);

            if (json.type == "newSubject")
            {
                ChangeSubject();
            }

            if (json.type == "newWeather")
            {
                ChangeWeather();
            }

            if (json.type == "newNumberOfPeople")
            {
                ChangeNumberOfPeople();
            }

            controll = jsonString;
        }
    }

    void ChangeSubject()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("tunniplaan"))
        {
            Transform parent = obj.transform.parent;

            if (!parent.name.Contains("Clone"))
            {
                if (parent.transform.parent.name == json.source)
                {
                    obj.GetComponent<TextMesh>().text = json.NewParameter;
                    Debug.Log("New subject in" + json.NewParameter + " in room " + json.source);
                }
            }
        }
    }

    void ChangeWeather()
    {
        if (json.NewParameter == "snow")
        {
            SetClouds();
            snow.SetActive(true);
            var abc = GameObject.FindGameObjectWithTag("snow");

            if (abc == null)
            {
                Instantiate(snow, new Vector3(-42, 20, 37), Quaternion.identity);
            }
            var rainFind = GameObject.FindGameObjectWithTag("rain");

            if (rainFind != null)
            {
                //rainFind.SetActive(false);
                Destroy(rainFind);
            }
            Debug.Log("New weather: snow");
        }


        if (json.NewParameter == "rain")
        {
            SetClouds();
            rain.SetActive(true);
            var abc = GameObject.Find("rain");

            if (abc == null)
            {
                Instantiate(rain, new Vector3(-42, 75, 37), Quaternion.identity);
            }

            var snowFind = GameObject.FindGameObjectWithTag("snow");

            if (snowFind != null)
            {
                //snowFind.SetActive(false);
                Destroy(snowFind);
            }

            Debug.Log("New weather: rain");
        }

        if (json.NewParameter == "sun")
        {
            var snowFind = GameObject.FindGameObjectWithTag("snow");
            if (snowFind != null)
            {
                //snowFind.SetActive(false);
                Destroy(snowFind);
            }

            var rainFind = GameObject.FindGameObjectWithTag("rain");
            if (rainFind != null)
            {
                //rainFind.SetActive(false);
                Destroy(rainFind);
            }

            GameObject clouds1 = GameObject.Find("Directional Light");
            Clouds cloud = clouds1.GetComponent<Clouds>();
            cloud.clouds = false;
        }

        if (json.NewParameter == "clouds")
        {
            SetClouds();

            var snowFind = GameObject.FindGameObjectWithTag("snow");
            if (snowFind != null)
            {
                //snowFind.SetActive(false);
                Destroy(snowFind);
            }

            var rainFind = GameObject.FindGameObjectWithTag("rain");
            if (rainFind != null)
            {
                //rainFind.SetActive(false);
                Destroy(rainFind);
            }
        }
    }

    void SetClouds()
    {
        GameObject clouds1 = GameObject.Find("Directional Light");
        Clouds cloud = clouds1.GetComponent<Clouds>();
        cloud.clouds = true;
    }


    void ChangeNumberOfPeople()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Collider"))
        {

            if (json.source == obj.transform.parent.name)
            {
                Debug.Log(obj.transform.parent.name);
                Debug.Log(json.NewParameter);

                RoomCollider abc = obj.GetComponent<RoomCollider>();
                int number = abc.NumberOfPeopleInRoom;
                int jsonNumber = Int32.Parse(json.NewParameter);

                if (jsonNumber > number)
                {
                    int diff = jsonNumber - number;

                    // kutsu siia veel "diff" inimesi
                    // see veel ei toota

                    //var one = new TestPerformace();
                    //one.SpawnMore(diff);
                    
                    
                    Debug.Log("kutsun veel " + diff + " inimesi");
                    number += diff;
                    Debug.Log("nuud ruumis on " + number + " inimesi");
                }
                if (jsonNumber < number)
                {
                    int diff = number - jsonNumber;

                    // "diff" inimesi -> Exit

                    Debug.Log("eemaldan " + diff + " inimesi");
                    number -= diff;
                    Debug.Log("nuud ruumis on " + number + " inimesi");
                }
            }
        }
    }
}
