using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameResources : MonoBehaviour {

//	private GameObject game_mech = GameObject.Find("GameMechanics");
	private GameObject game_mech;	//	private GameObject GUIText = gameObject.name;
	// Use this for initialization
	private Text resource_text;

	void Start () {
		game_mech = GameObject.FindGameObjectWithTag("GameMechanics");
		resource_text = gameObject.GetComponent<Text> ();
	}


	// Update is called once per frame
	void Update () {
		GameResources game_res = game_mech.GetComponent<GameResources>();
//	    resource_text.text = Mathf.RoundToInt (oxygen.Oxygen).ToString ();
//		Debug.Log(resource_text.text);
		if (gameObject.transform.name == "OxygenText") {
			resource_text.text = Mathf.RoundToInt (game_res.Oxygen).ToString ();
		} 
		if (gameObject.transform.name == "EnergyText") {
			resource_text.text = Mathf.RoundToInt (game_res.Energy).ToString ();
		} 
		if (gameObject.transform.name == "BiomassText") {
			resource_text.text = Mathf.RoundToInt (game_res.Biomass).ToString ();
		} 
		if (gameObject.transform.name == "SiliconText") {
			resource_text.text = Mathf.RoundToInt (game_res.Silicon).ToString ();
		} 
		if (gameObject.transform.name == "IronText") {
			resource_text.text = Mathf.RoundToInt (game_res.Iron).ToString ();
		}

	}
}
