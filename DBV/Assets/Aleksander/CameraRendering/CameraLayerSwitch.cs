using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLayerSwitch : MonoBehaviour {

    public Button yourButton; //100% did not take from the internet and took the example "yourButton", no idea what you are talking about
    public Camera mainCamera;
    private bool trafficOn = false;
    public GameObject forScript;

	// Use this for initialization
	void Start () {
        yourButton.onClick.AddListener(switchLayers);
	}

    void switchLayers()
    {
        if (!trafficOn)
        {
            if (forScript.GetComponent<FloorSwitch>().firstFloor)
            {
                mainCamera.cullingMask = mainCamera.cullingMask | (1 << 11); //enables the traffic view
                trafficOn = true;
            }
            else
            {
                mainCamera.cullingMask = mainCamera.cullingMask | (1 << 10); //enables the traffic view
                trafficOn = true;
            }
        }
        else
        {
            mainCamera.cullingMask = mainCamera.cullingMask ^ (1 << 10 | 1 << 11); //disabled the traffic view
            trafficOn = false;
        }
        gameObject.GetComponent<Animation>().Play("flipButton");
    }
	
	// Update is called once per frame
	///void Update () {
	///	
	///}
}
