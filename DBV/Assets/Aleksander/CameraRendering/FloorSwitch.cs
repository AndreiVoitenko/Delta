using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorSwitch : MonoBehaviour {

    public Button myButton;
    public Camera mainCamera;
    public Text toChangeFloorsText;
    public bool firstFloor = false;

	// Use this for initialization
	void Start () {
        myButton.onClick.AddListener(switchRooms);
	}
    //8 is first floor, 9 is second
    void switchRooms()
    {
        if (!firstFloor)
        {
            mainCamera.cullingMask = 1 << 8;
            //mainCamera.cullingMask &= ~(1 << 9);
            toChangeFloorsText.text = "First floor";
            firstFloor = true;
        }
        else
        {
            mainCamera.cullingMask = 1 << 9;
            //mainCamera.cullingMask &= ~(1 << 8);
            toChangeFloorsText.text = "Second floor";
            firstFloor = false;
        }
        gameObject.GetComponent<Animation>().Play("flipButton");
    }
	
	// Update is called once per frame
	//void Update () {
		
	//}


}
