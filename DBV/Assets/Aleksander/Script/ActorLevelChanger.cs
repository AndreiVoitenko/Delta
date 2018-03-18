using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorLevelChanger : MonoBehaviour {

	void OnEnable()
    {
        StartCoroutine("CheckForLevelChange");
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    protected void ChangeLayer(string whichLayer)
    {
        int newLayer = LayerMask.NameToLayer(whichLayer);
        if (gameObject.layer != newLayer)
        {
            gameObject.layer = newLayer;
            /*foreach (Transform child in transform)
            {
                child.gameObject.layer = newLayer;
            }*/
			amazingRecursion(transform, newLayer);
        }
    }
	
	private void amazingRecursion(Transform parent, int layer){ //slow, but the only solution is to remove all the children, which I might do
		if(parent.childCount == 0)
			return;
		foreach(Transform child in parent.transform){
			child.gameObject.layer = layer;
			amazingRecursion(child, layer);
		}
	}

    IEnumerator CheckForLevelChange()
    {
        while (isActiveAndEnabled)
        {
            if (transform.position.y > 4)
            {
                ChangeLayer("SecondFloor");
            }
            else
            {
                ChangeLayer("FirstFloor");
            }

            yield return new WaitForSeconds(1.0f + Random.Range(0.0f, 0.7f));
        }


        yield break;

    }
}
