using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestPerformance : MonoBehaviour
{
    public GameObject actor;
    public GameObject[] roomNimed;

    public int actorsCount = 0;
    protected int actorsLimit = 100;

    public Transform spawn;

    public List<Transform> spawns = new List<Transform>();

    public GameObject actorsParent;

    void Start()
    {

        spawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        StartCoroutine("Spawn");

        //Screen.SetResolution(3840, 2160, false);
    }

    IEnumerator Spawn()
    {
        while (actorsCount < actorsLimit)
        {
            int step = actorsCount + 10;
            for (; actorsCount < Mathf.Min(step, actorsLimit); actorsCount++)
            {
                Transform currentSpawn = spawns[Random.Range(0, spawns.Count)];
                GameObject someActor = Instantiate(actor, currentSpawn.position, Quaternion.identity);
                //someActor.GetComponent<NavMeshAgent>().destination = roomNimed[Random.Range(0, roomNimed.Length)].transform.position;
                //someActor.GetComponent<NavMeshAgent>().destination = .transform.position;
                someActor.transform.parent = actorsParent.transform;
                someActor.GetComponent<Actor>().SetCurrentLocation(currentSpawn.name);


                //Get a random room and save that the student is going to the room to the RoomManager
                GameObject room = RoomManager.GetInstance().GetRandomRoom();
                someActor.GetComponent<Actor>().SetDestination(room);
                RoomManager.GetInstance().SaveAmountInRoom(room, gameObject);
                
            }

            yield return new WaitForSeconds(0.5f);
        }


        yield break;

    }
}
