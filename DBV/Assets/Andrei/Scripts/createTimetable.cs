using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTimetable : MonoBehaviour {

    private GameObject[] floor;
    public bool tunniplaan = true;



    // Use this for initialization
    void Start() {
        floor = GameObject.FindGameObjectsWithTag("CreateTunniplaan");

        
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (tunniplaan)
        {
            foreach(GameObject one in floor)
            {
                one.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject one in floor)
            {
                one.SetActive(false);
            }
        }

    }
}
