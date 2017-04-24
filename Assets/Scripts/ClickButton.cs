using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class ClickButton : MonoBehaviour, IPointerDownHandler {

	private GameObject game_mech;
	private SelectedResource building_type;
	// Use this for initialization
	void Start () {
		game_mech = GameObject.FindGameObjectWithTag("GameMechanics");
		SelectedResource building_type = game_mech.GetComponent<SelectedResource>();
	}

	public void OnPointerDown (PointerEventData eventData){
		// TODO: prevent the placement of a building when this is clicked
		SelectedResource building_type = game_mech.GetComponent<SelectedResource>();
		Debug.Log (this.gameObject.name + " Was Clicked.");
		if (this.gameObject.name == "oxygenButton") {
			building_type.resource = "Oxygen";
		}
		if (this.gameObject.name == "ironButton") {
			building_type.resource = "Iron";
		}
		if (this.gameObject.name == "energyButton") {
			building_type.resource = "Energy";
		}
		if (this.gameObject.name == "biomassButton") {
			building_type.resource = "Biomass";
		}
		if (this.gameObject.name == "siliconButton") {
			building_type.resource = "Silicon";
		}
		if (this.gameObject.name == "bureaucracyButton") {
			building_type.resource = "Delete";
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
