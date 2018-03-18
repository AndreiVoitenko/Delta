using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour {

	// Use this for initialization
	void Start () {
         var color = gameObject.GetComponent<MeshRenderer>().material.color;
         color.a = 0.1f;
        gameObject.GetComponent<Renderer>().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
