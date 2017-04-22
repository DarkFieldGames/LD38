using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	float theta;
	float phi;

	// Use this for initialization
	void Start () {
		
		theta = -0.5f * Mathf.PI;
		phi = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxisRaw("Mouse X") * 5;
		float mouseY = Input.GetAxisRaw("Mouse Y") * 5;
		
		
		
		if (Input.GetMouseButton(1) ) {
			transform.Rotate( new Vector3(0, -mouseX , 0 ) );
			transform.Rotate( new Vector3(-mouseY , 0,0 ) );
			
			theta += Mathf.Deg2Rad*mouseX;
			phi += Mathf.Deg2Rad*mouseY;
			
			if (phi > 360) phi = 360;
			if (phi < 0  ) phi = 0;
			theta %= 360;
			
			transform.position =  new Vector3(2*Mathf.Cos(theta),0,2*Mathf.Sin(theta));
		}
	
	}
}
