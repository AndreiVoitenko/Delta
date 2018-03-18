using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorOpen : MonoBehaviour {

    private List<Collider> moreDudes = new List<Collider>();
    private Animation anim;
    public bool opened = false;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animation>();

    }
	
	// Update is called once per frame
	void Update () {
		//avoid update because there are 100 of doors and that will slow the game down to stupid levels
	}

    /*void OnTriggerEnter(Collider other)
    {
        
        if(moreDudes.Count == 0) //if nobody is at the door, open then door
        {
            

        }
        if (!moreDudes.Contains(other)) //add unique actor to the array in the box collider
        {
            moreDudes.Add(other);
        }
    }

    void OnTriggerExit(Collider other) //this goes second, so in theory, first the door should open
    {
        if (moreDudes.Contains(other)) 
        {
            moreDudes.Remove(other);
        }

        if(moreDudes.Count == 0) //if nobody is at the door (last actor left), close the door and reverse the animation
        {
            anim[nameOfAnim].speed = -1;
            anim[nameOfAnim].time = anim[nameOfAnim].length;
            anim.Play(nameOfAnim);
        }
    }*/

    public void PlayAnimationOpen()
    {
        anim["doorOpenClone"].speed = 1;
        anim["doorOpenClone"].time = 0;
        anim.Play("doorOpenClone");
    }

    public void PlayAnimationClose()
    {
        anim["doorOpenClone"].speed = -1;
        anim["doorOpenClone"].time = anim["doorOpenClone"].length;
        anim.Play("doorOpenClone");
    }

    public void DecideOnOpening(GameObject room)
    {
        if (!opened)
        {
            PlayAnimationOpen();
            opened = true;
        }
        else
        {
            switch (RoomManager.GetInstance().OpenTheDoor(room))
            {
                case ("yes"):
                    PlayAnimationClose();
                    opened = false;
                    break;
                case ("no"):
                    break;
            }
        }
        
    }

}
