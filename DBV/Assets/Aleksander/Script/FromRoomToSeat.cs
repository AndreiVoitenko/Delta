using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FromRoomToSeat : MonoBehaviour {

    private List<Transform> seats; //0 means the seat is free, 1 means it is occupied
    private List<Collider> uniqueActor = new List<Collider>();
    private int takenSeats;
    public List<SitDown> choosingActors;

	// Use this for initialization
	void Start () {
        takenSeats = 0; //tried using hashtable, kept getting errors
        seats = new List<Transform>();
        foreach (Transform child in transform)
            seats.Add(child);


    }
	
	// Update is called once per frame
	void Update () {
		//avoid
	}

    void OnTriggerEnter(Collider other)
    {
        if (!uniqueActor.Contains(other))
        {
            uniqueActor.Add(other);
            if (!(takenSeats >= seats.Count))
            {
                other.gameObject.GetComponent<NavMeshAgent>().destination = seats[takenSeats].position;
                choosingActors[takenSeats].checkingActor = other.gameObject;
                takenSeats++;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        /*if (uniqueActor.Contains(other))
        {
            uniqueActor.Remove(other);
            takenSeats--;
        }*/
    }

}
