using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchScreen : MonoBehaviour {
	
	public List<GameObject> cameras = new List<GameObject>();
	private GameObject lastCamera;
    public Camera rotateToCamera;
	private bool buttonPressed;

	// Use this for initialization
	void Start () {
		lastCamera = cameras[0];
        buttonPressed = true; //this does not make sense I know, but trust me
		StartCoroutine("CameraSwitch");
	}
	
	// Update is called once per frame
	void Update () {
		//avoid
		if(Input.GetKeyDown("space")){
			
			buttonPressed = false;
			StopCoroutine("CameraSwitch");
		}
		if(!buttonPressed){
			if(Input.GetKeyDown("1")){
				lastCamera.SetActive(false);
				cameras[0].SetActive(true);
				lastCamera = cameras[0];
                rotateToCamera = cameras[0].GetComponent<Camera>();
            }
			if(Input.GetKeyDown("2")){
				lastCamera.SetActive(false);
				cameras[1].SetActive(true);
				lastCamera = cameras[1];
                rotateToCamera = cameras[1].GetComponent<Camera>();
            }
			if(Input.GetKeyDown("3")){
				lastCamera.SetActive(false);
				cameras[2].SetActive(true);
				lastCamera = cameras[2];
                rotateToCamera = cameras[2].GetComponent<Camera>();
            }
			if(Input.GetKeyDown("4")){
				lastCamera.SetActive(false);
				cameras[3].SetActive(true);
				lastCamera = cameras[3];
                rotateToCamera = cameras[3].GetComponent<Camera>();
            }
			if(Input.GetKeyDown("5")){
				lastCamera.SetActive(false);
				cameras[4].SetActive(true);
				lastCamera = cameras[4];
                rotateToCamera = cameras[4].GetComponent<Camera>();
            }
			if(Input.GetKeyDown("6")){
				lastCamera.SetActive(false);
				cameras[5].SetActive(true);
				lastCamera = cameras[5];
                rotateToCamera = cameras[5].GetComponent<Camera>();
            }
		}
			
	}
	
	
	IEnumerator CameraSwitch()
    {
		while(buttonPressed){
			foreach(GameObject camera in cameras)
			{
				lastCamera.SetActive(false);
				camera.SetActive(true);
				lastCamera = camera;
                rotateToCamera = camera.GetComponent<Camera>();

                yield return new WaitForSeconds(5f);
			}
		}
		yield break;

    }
}
