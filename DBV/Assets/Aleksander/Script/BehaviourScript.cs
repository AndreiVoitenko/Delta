using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour {

    public string roomType;
    private Animation anim;
    private List<string> possibleAnimations;

	// Use this for initialization
	void Start () {
        possibleAnimations = new List<string>();
        switch (roomType)
        {
            case ("physics"):
                possibleAnimations.Add("moveBubble");
                break;
                
        }
        StartCoroutine("RandomBubbleRandomIntervals");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerable RandomBubbleRandomIntervals()
    {
        yield return new WaitForSeconds(5f + Random.Range(0.0f, 5.0f));
        anim.Play("moveBubble");
    }
}
