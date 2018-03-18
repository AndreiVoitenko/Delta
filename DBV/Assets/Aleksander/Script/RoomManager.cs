using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public List<GameObject> roomContainers;
    protected List<Transform> rooms = new List<Transform>();

    private Dictionary<GameObject, List<GameObject>> roomToActors = new Dictionary<GameObject, List<GameObject>>();

    private Dictionary<Transform, List<Dictionary<Transform, int>>> roomToSeats = new Dictionary<Transform, List<Dictionary<Transform, int>>>();

    //{1034: [{Seat, 0}, {Seat,1}]} Where seat 0 is free and seat 1 is occupied
    
    public static RoomManager instance; //Singleton

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Use this for initialization
    void Start()
    {
        foreach (GameObject roomContainer in roomContainers) // TODO: Make this better, like have each room register themselves etc...
        {
            for (int i = 0; i < roomContainer.transform.childCount; i++)
            {
                rooms.Add(roomContainer.transform.GetChild(i));
               
            }

        }
        
        foreach (Transform room in rooms)
        {
            if (!roomToSeats.ContainsKey(room))
            {
                
                List<Dictionary<Transform, int>> toPut = new List<Dictionary<Transform, int>>();
                foreach (Transform child in room)
                {
                    if (child.gameObject.tag.Equals("Sit"))
                    {
                        Dictionary<Transform, int> helper = new Dictionary<Transform, int>();
                        helper.Add(child, 0);
                        toPut.Add(helper);
                    }
                }
                
            
                roomToSeats.Add(room, toPut);
            }
        }
        
        DataSaver.RoomsLoaded(rooms.Count);
    }

    //Once an actor has reached his position, he needs to get a chair to sit on
    //This method iterates over all the seats of a set room and returns the first available seat
    public Transform NewDestination(Transform room)
    {
        if (roomToSeats[room] != null)
        {
            
            foreach (Dictionary<Transform, int> seats in roomToSeats[room])
            {
                foreach (KeyValuePair<Transform, int> seat in seats)
                {
                    if (seat.Value == 0)
                    {
                        seats[seat.Key] = 1;
                        return seat.Key;
                    }
                }
            }
        }
        
        return room; //if it reaches here, then most likely the room does not have a seat 
    }


    //
    public GameObject GetRandomRoom()
    {
        if(rooms.Count == 0)
        {
            foreach (GameObject roomContainer in roomContainers) // TODO: Make this better, like have each room register themselves etc...
            {
                for (int i = 0; i < roomContainer.transform.childCount; i++)
                {
                    rooms.Add(roomContainer.transform.GetChild(i));

                }

            }
        }
        return rooms[Random.Range(0, rooms.Count)].transform.gameObject;
        //return rooms[0].transform.gameObject;
    }


    public void SaveAmountInRoom(GameObject room, GameObject student) //this might be useless
    {
        if (roomToActors.ContainsKey(room))
        {
            roomToActors[room].Add(student);
        }
        else
        {
            roomToActors.Add(room, new List<GameObject>());
            roomToActors[room].Add(student);
        }
        
    }

   
    public string OpenTheDoor(GameObject room)
    {
        if(roomToActors[room].Count == 2)
        {
            roomToActors[room].RemoveAt(0);
            return "yes";
        }
        roomToActors[room].RemoveAt(0);
        return "no";
    }

    public static RoomManager GetInstance()
    {
        return instance;
    }
}
