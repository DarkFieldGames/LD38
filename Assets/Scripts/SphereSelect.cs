using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SphereSelect : MonoBehaviour {

	public GameObject CurrentPrefab;

	private float nextPlaceTime = 0.0f;
	public float placePeriod = 2.0f;

	public float RadiusRatio = 1.0f;
	private Color mycolor;
	private String tag_string;

	// Use this for initialization
	void Start () {
		Color myColor = Color.black;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextPlaceTime) {
			
			Color myColor = Color.black;
			bool dont_generate = false;
			if (!Input.GetMouseButtonDown(0)) return;

			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

		

			if(Physics.Raycast(ray, out hit, maxDistance: 1000, layerMask: 1 << 8))
			{
				GameObject game_mech = GameObject.FindGameObjectWithTag("GameMechanics");
				SelectedResource building_type = game_mech.GetComponent<SelectedResource>();
				Debug.Log ("building type");
				Debug.Log (building_type.resource);

				// select the colour and the tag
				if (building_type.resource == "Oxygen") {
					myColor = Color.blue;
					tag_string = "OxygenBuilding";
				}
				if (building_type.resource == "Iron") {
					myColor = Color.red;
					tag_string = "IronBuilding";
				}
				if (building_type.resource == "Silicon") {
						myColor = Color.yellow;
					tag_string = "SiliconBuilding";
				}
				if (building_type.resource == "Biomass") {
					myColor = Color.green;
					tag_string = "BiomassBuilding";
				}
				if (building_type.resource == "Energy") {
					myColor = Color.magenta;
					tag_string = "EnergyBuilding";
				}

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
					    if (hit.collider.gameObject.name != "BetterSphere") {
							if (building_type.resource == "Energy"){
								Destroy (hit.collider.gameObject);
								nextPlaceTime = Time.time + placePeriod;
							}
						}
				}
				// end check
				
				if (dont_generate == false) 
				{
				    var o = (GameObject) Instantiate(CurrentPrefab, newVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
					o.GetComponent<UpdateBuildingSize> ().BuildingColor = myColor;
					o.tag = tag_string;
					nextPlaceTime = Time.time + placePeriod;
				}
			//o.transform.position = hit.point;
			//o.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
			}
		}
	}
}
