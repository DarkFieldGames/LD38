using UnityEngine;
using System.Collections;

public class CamThetaScript : MonoBehaviour {
	
	//float theta;
	
	public float sens = 5;
	public GameObject go;
	

	// Use this for initialization
	void Start () {
		go = gameObject;
		//theta = -0.5f * Mathf.PI;
		
		transform.Rotate( new Vector3(0, 0.5f , 0 ) );
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float mouseX = Input.GetAxisRaw("Mouse X") * -sens;
		
		if (Input.GetMouseButton(1) ) {
			transform.Rotate( new Vector3(0, -mouseX , 0 ) );
			
			//theta += Mathf.Deg2Rad*mouseX;
			
			//theta %= 360;
			
			//transform.position =  new Vector3(2*Mathf.Cos(theta),0,2*Mathf.Sin(theta));
		}
	
	}
}
