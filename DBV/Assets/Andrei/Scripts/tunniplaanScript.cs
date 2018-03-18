using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tunniplaanScript : MonoBehaviour {
    string parentName;
    public TextMesh text;
    

	// Use this for initialization
	void Start () {


        //GameObject[] textObject = GameObject.FindGameObjectsWithTag("asd");
        //Find("tunniplaanText").GetComponent<TextMesh>();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("tunniplaan"))
        {
            
            text.text = "ruum: " +text.transform.parent.parent.name+ "\n tunniplaan";
        }
        //textObject.text = "test";
    }
	
	// Update is called once per frame
	void Update () {
		
	}


   
}
