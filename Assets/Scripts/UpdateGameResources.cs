using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateResource : MonoBehaviour {

//	private GameObject game_mech = GameObject.Find("GameMechanics");
	private GameObject game_mech;	//	private GameObject GUIText = gameObject.name;
	// Use this for initialization
	private Text resource_text;

	void Start () {
		// game_mech = GameObject.FindObjectOfType (typeof(GameMechanics));
		game_mech = GameObject.Find("GameMechanics");
		resource_text = gameObject.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.parent.name == "OxygenText") {
			resource_text.text = Mathf.RoundToInt(game_mech.GetComponent<resources>().Oxygen).ToString();
		} 
/*		if (GUItext.GetComponentInParent<name> () == "EnergyText") 
		{
			text = Mathf.RoundToInt(game_mech.GetComponent<resources> ().Energy);
		} 
		if ( GUItext.GetComponentInParent<name> () == "BiomassText")
		{
			text = Mathf.RoundToInt(game_mech.GetComponent<resources> ().Biomass);
		}
		if ( GUItext.GetComponentInParent<name> () == "SiliconText")
		{
			text = Mathf.RoundToInt(game_mech.GetComponent<resources> ().Silicon);
		}
		if ( GUItext.GetComponentInParent<name> () == "IronText")
		{
			text = Mathf.RoundToInt(game_mech.GetComponent<resources> ().Iron);
		} */
	}
}
