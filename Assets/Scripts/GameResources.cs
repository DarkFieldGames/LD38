using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour {

	// Define the resource variables
	private float nextUpdateTime = 0.0f;
	public float updatePeriod = 0.1f;
	public float Oxygen = 0.0f;
	public float Biomass = 0.0f;
	public float Iron = 0.0f;
	public float Silicon = 0.0f;
	public float Energy = 0.0f;

	public float ResourceFactor = 3.0f;

    // Define the maximum resources required to win
	public float MaxOxygen = 10.0f;
	public float MaxBiomass = 10.0f;
	public float MaxIron = 10.0f;
	public float MaxSilicon = 10.0f;
	public float MaxEnergy = 10.0f;

	private GameObject[] oxygenBuildings;
	private GameObject[] ironBuildings;
	private GameObject[] energyBuildings;
	private GameObject[] biomassBuildings;
	private GameObject[] siliconBuildings;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextUpdateTime) {
			nextUpdateTime += updatePeriod;

			oxygenBuildings = GameObject.FindGameObjectsWithTag ("OxygenBuilding");
			ironBuildings = GameObject.FindGameObjectsWithTag ("IronBuilding");
			biomassBuildings = GameObject.FindGameObjectsWithTag ("BiomassBuilding");
			siliconBuildings = GameObject.FindGameObjectsWithTag ("SiliconBuilding");
			energyBuildings = GameObject.FindGameObjectsWithTag ("EnergyBuilding");

			// search for Oxygen Building List.
			foreach (GameObject oxyBuild in oxygenBuildings) {
				Oxygen += (oxyBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor);
			}
			foreach (GameObject iroBuild in ironBuildings) {
				Iron += (iroBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor);
			}
			foreach (GameObject bioBuild in biomassBuildings) {
				Biomass += (bioBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor);
			}
			foreach (GameObject silBuild in siliconBuildings) {
				Silicon += (silBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor);
			}
			foreach (GameObject engBuild in energyBuildings) {
				Energy += (engBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor);
			}
			//Biomass += 0.1f;
			//Iron += 0.1f;
			//Silicon += 0.1f;
			//Energy += 0.1f;
			//Debug.Log (Oxygen);
		}
	}
}
