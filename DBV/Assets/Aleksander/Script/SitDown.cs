using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SitDown : MonoBehaviour {

    private Animation sitting;
    public GameObject newObject;
    public GameObject CT;
    private GameObject newCT;
    private GameObject actor;
    public GameObject checkingActor;

    //The idea here is to sit down a person once the Event system tells actors that he has to go to that room and then make him stand up again once 
    //he has to go somewhere else.
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//avoid
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == checkingActor) //this probably will not work
        {
            
            actor = other.gameObject;
            ChangeTables(gameObject.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
    }

    public void ChangeTables(Transform location)
    {
        actor.SetActive(false);
        //gameObject.SetActive(false);
        newCT = Instantiate(newObject, location);
        newCT.transform.position = CT.transform.position;
        newCT.transform.rotation = CT.transform.rotation;
        CT.SetActive(false);
    }

    public void OriginTables(Transform location)
    {
        //gameObject.SetActive(false);
        CT.SetActive(true);
        newCT.SetActive(false);
    }

}
