using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timetable : MonoBehaviour {
    private GameObject[] timetables;
    private Text al;
    

    // Use this for initialization
    void Start () {
        timetables = GameObject.FindGameObjectsWithTag("timetable");
        
        

    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] abc = GameObject.FindGameObjectsWithTag("TimetableText");

        foreach (GameObject time in abc)
        {
            al = time.GetComponent<Text>();
            al.text = "timetable for room " + time.transform.parent.parent.parent.name;
        }

    }
}
