using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeResourceArea : MonoBehaviour {

	// Use this for initialization
	public float area = 0.0f;
	private float cap_radius;
	private float spherical_angle;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBuildingSize bulding_info = gameObject.transform.GetComponent<UpdateBuildingSize> ();

		// at the moment, the cap radius is the cylinder radius
	    //  i don't think we need the local scale transform
     	//	Debug.Log(gameObject.transform.localScale.x);
     	//	Debug.Log(bulding_info.MasterRadius);
	    //	Debug.Log (bulding_info.CircleAngleRadius);
		cap_radius =  (float)bulding_info.MasterRadius * (float)bulding_info.CircleAngleRadius;
		// simple trig
		spherical_angle = Mathf.Asin((cap_radius / 1.0f));
        // see maths.png.. area of spherical cap surface are thing
		area = 4 * Mathf.PI * Mathf.Pow(cap_radius, 2.0f) * (1.0f - Mathf.Cos(spherical_angle));
	}
}
