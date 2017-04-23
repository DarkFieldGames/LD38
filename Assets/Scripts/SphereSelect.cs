using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSelect : MonoBehaviour {

	public GameObject CurrentPrefab;

	public float RadiusRatio = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool dont_generate = false;
		if (!Input.GetMouseButtonDown(0))
			return;

		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		

		if(Physics.Raycast(ray, out hit, maxDistance: 1000, layerMask: 1 << 8))
		{
			var newVector = hit.point * RadiusRatio;


			// check if there is not another city nearby.
			Debug.Log(hit.collider);
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log(hit.collider.gameObject.name);
				if (hit.collider.gameObject.name != "BetterSphere") {
					dont_generate = true;
				}
			}
			// control the radius here from the trigger collider
			if(hit.collider.isTrigger)
			{
					dont_generate = true;
			}
			// end check
				
			if (dont_generate == false) 
			{
			    var o = (GameObject) Instantiate(CurrentPrefab, newVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
			}
			//o.transform.position = hit.point;
			//o.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

		}
	}
}
