using UnityEngine;
using System.Collections;

public class CamPhiScript : MonoBehaviour {

	public float sens = 5;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
		float mouseY = Input.GetAxisRaw("Mouse Y") * sens;
			
		if (Input.GetMouseButton(1) ) {
	
			transform.Rotate( new Vector3(-mouseY , 0,0 ) );
	
		}
	}
	
}
