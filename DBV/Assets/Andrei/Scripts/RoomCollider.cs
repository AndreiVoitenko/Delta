using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollider : MonoBehaviour {

    public int NumberOfPeopleInRoom;

    // Use this for initialization
    void Start () {
        NumberOfPeopleInRoom = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        NumberOfPeopleInRoom += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        NumberOfPeopleInRoom -= 1;
    }
}
