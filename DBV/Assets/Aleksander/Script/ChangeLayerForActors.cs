using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerForActors : MonoBehaviour {

    public string whichLayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        other.gameObject.layer = LayerMask.NameToLayer(whichLayer);
        recursiveLayerChange(other.transform);
    }

    void recursiveLayerChange(Transform someChild)
    {
        if (someChild.childCount == 0)
            return;

        foreach (Transform child in someChild.transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer(whichLayer);
            recursiveLayerChange(child);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}