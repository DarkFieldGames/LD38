using UnityEngine;
using System.Collections;

public class CamZoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.localPosition.z < -1.000f && Input.GetAxis("Mouse ScrollWheel") > 0) // zoom in
    	{
        	transform.localPosition += new Vector3(0,0,1.60f);
    	}
    	if (transform.localPosition.z > -40.0f && Input.GetAxis("Mouse ScrollWheel") < 0) // zoom out
    	{
			transform.localPosition += new Vector3(0,0,-1.60f);
    	}
	
	}
}
