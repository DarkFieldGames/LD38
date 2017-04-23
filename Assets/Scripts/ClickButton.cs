using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class ClickButton : MonoBehaviour, IPointerDownHandler {

	// Use this for initialization
	void Start () {
		
	}

	public void OnPointerDown (PointerEventData eventData){
		Debug.Log (this.gameObject.name + " Was Clicked.");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
