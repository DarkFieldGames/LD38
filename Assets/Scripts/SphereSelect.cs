using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSelect : MonoBehaviour {

	public Transform CurrentPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!Input.GetMouseButtonDown(0))
			return;

		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		

		if(Physics.Raycast(ray, out hit, maxDistance: 1000, layerMask: 1 << 8))
		{

			var o = Instantiate(CurrentPrefab);
			o.transform.position = hit.point;
			o.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

		}
	}
}
