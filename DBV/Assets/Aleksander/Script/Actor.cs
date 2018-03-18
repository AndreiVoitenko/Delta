using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Actor : MonoBehaviour {

    public NavMeshAgent navMeshAgent;
    public GameObject destination;
    public bool stopped = false;
    public string status = "";
    public CameraSwitchScreen cameraswitchscreen;
    public string reached = "";
    public GameObject Door;
    private Animation DoorAnim;

    public string currentLocation = "";
    public bool hasPathCached = false;
    private bool how = true;
    private bool DoorInstance = true;

    protected Coroutine pathVailidityCoroutine;



    void Start()
    {
        cameraswitchscreen = GameObject.FindGameObjectWithTag("Event").GetComponent<CameraSwitchScreen>();
        //StartCoroutine("CheckForDestination");
        this.destination = destination;
        Door = SetDoor(destination);
        if (Door != null)
            StartCoroutine("NearDoorChecker");
        StartCoroutine("TurnToCamera");
    }


    void OnEnable()
    {
        DataSaver.ActorSpawned();
        StartCoroutine("CheckForDestination");
       
        
    }

    

    void OnDisable()
    {
        DataSaver.ActorDeSpawned();
        StopAllCoroutines();
    }

    void Update()
    {
        // if (CheckForCamera)
        // {
        //     CheckForCamera = false;
        //     cameraswitchscreen = GameObject.FindGameObjectWithTag("Event").GetComponent<CameraSwitchScreen>();
        //// }
        //stopped = navMeshAgent.isStopped;
        //status = navMeshAgent.pathStatus.ToString();
        //SetCurrentRotation();




        if (!navMeshAgent.pathPending)  //too many things in the update, but for now it is fine...ish
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    if (how) { 
                        reached = "reached";
                        GetComponent<Animation>().Play("thisisHel");
                        
                        destination = RoomManager.GetInstance().NewDestination(destination.transform).gameObject;
                        navMeshAgent.destination = destination.transform.position;

                        how = false;
                    }
                }
            }
        }

        /*if (Door != null)
        {
            //Debug.Log(Vector3.Distance(transform.position, Door.transform.position)); //for testing the right amount of F...whatever F means :DDDD
            //NB! remove this comment later because a Bachelor degree is very serious
            if (Vector3.Distance(transform.position, Door.transform.position) < 8F)
            {
                Debug.Log(" i am getting here more than once too");
                if (DoorInstance)
                {
                    Door.GetComponent<DoorOpen>().DecideOnOpening(destination);
                    DoorInstance = false;
                }
            }
            yield return new WaitForSeconds(1.0F);
        }*/

        /*float distanceToTarget = Vector3.Distance(transform.position, destination.transform.position);
        if (distanceToTarget < 1.0f)
        {
            if (how)
            {
                Debug.Log("Destination reached");
                how = false;
            }
        }*/

    }

    IEnumerator NearDoorChecker()
    {
        while(Vector3.Distance(transform.position, Door.transform.position) > 8F)
        {
            yield return new WaitForSeconds(1.0F);
        }
        if (DoorInstance)
        {
            Door.GetComponent<DoorOpen>().DecideOnOpening(destination);
            DoorInstance = false;
        }
        yield break;
    }

    

    IEnumerator CheckForDestination()
    {


        while (gameObject.activeSelf)
        {
            
            if ((navMeshAgent.destination - transform.position).magnitude < 1.0)
            {
                /*navMeshAgent.isStopped = true;
                if (destination != null) SetCurrentLocation(destination.name);
                navMeshAgent.enabled = false;
                StartCoroutine("FindNewDestination");
                */
                //if you enable the thing above, everything does not work
                //Debug.Log("i have reached my shit"); //does not reach as well
            }
            yield return new WaitForSeconds(1.0f + Random.Range(0.0f, 0.7f));
        }
        yield break;
    }

    public IEnumerator FindNewDestination()
    {
        yield return new WaitForSeconds(10f + Random.Range(0.0f, 7.0f));
        //navMeshAgent.enabled = true;
        navMeshAgent.isStopped = false;
        SetDestination(RoomManager.GetInstance().GetRandomRoom());
    }

    IEnumerator TurnToCamera()
    {
        SetCurrentRotation();
        yield return new WaitForSeconds(1.0F);
    }

    public void SetDestination(GameObject destination)
    {
        if (null != pathVailidityCoroutine) StopCoroutine(pathVailidityCoroutine);

        this.destination = destination;
        //Debug.Log("New Destination set to: " + destination.name);
        navMeshAgent.ResetPath();
        NavMeshPath cachedPath = PathManager.GetPath(currentLocation, destination.name);
        if (null != cachedPath)
        {
            navMeshAgent.path = cachedPath;
            DataSaver.CacheHit();
        }
        else
        {
            navMeshAgent.SetDestination(destination.transform.position);
            pathVailidityCoroutine = StartCoroutine("DeterminePathValidity");
            DataSaver.CacheMiss();
        }
        navMeshAgent.isStopped = false;
    }

    public IEnumerator DeterminePathValidity()
    {
        while (navMeshAgent.pathPending)
        {
            if (PathManager.HasPath(currentLocation, destination.name))
            {
                DataSaver.CacheHit();
                navMeshAgent.SetPath(PathManager.GetPath(currentLocation, destination.name));
                yield break;
            }
            yield return new WaitForSeconds(0.5f);
        }
        if (navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete) // TODO: What about partial paths?
        {
            SetDestination(RoomManager.GetInstance().GetRandomRoom());                  // No path found, try another room
            
        }
        else
        {
            PathManager.CachePath(currentLocation, destination.name, navMeshAgent.path); // New complete path found, cache it
        }
        

        yield break;
    }

    public void SetCurrentLocation(string location)
    {
        currentLocation = location;
    }

    public void SetCurrentRotation()
    {
        var target = cameraswitchscreen.rotateToCamera.transform;
        Vector3 targetPostition = new Vector3(target.position.x,
                                        this.transform.position.y,
                                        target.position.z);
        transform.LookAt(targetPostition);
    }

   /* void OnDrawGizmosSelected()
    {
        stopped = navMeshAgent.isStopped;
        status = navMeshAgent.pathStatus.ToString();
        
        hasPathCached = PathManager.HasPath(currentLocation, destination.name);


        var nav = GetComponent<NavMeshAgent>();
        if (nav == null || nav.path == null)
            return;

        var line = this.GetComponent<LineRenderer>();
        if (line == null)
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
            line.SetWidth(0.5f, 0.5f);
            line.SetColors(Color.yellow, Color.yellow);
        }

        var path = nav.path;

        line.SetVertexCount(path.corners.Length);

        for (int i = 0; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }

    }
    */

    public GameObject SetDoor(GameObject door)
    {
        foreach (Transform child in door.transform)
        {
            if (child.gameObject.tag == "Door")
            {
                return child.gameObject;
                //someActor.GetComponent<Actor>().SetDestination(RoomManager.GetInstance().GetRandomRoom());
            }
        }
        return null;
    }
}
