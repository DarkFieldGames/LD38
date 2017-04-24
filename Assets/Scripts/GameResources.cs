using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour {

	// Define the resource variables
	private float nextUpdateTime = 0.0f;
	public float updatePeriod = 0.5f;
	public float Oxygen = 0.0f;
	public float Biomass = 0.0f;
	public float Iron = 0.0f;
	public float Silicon = 0.0f;
	public float Energy = 0.0f;
	public float Timer = 60.0f;
	public float Level = 1.0f;

	public float ResourceFactor = 1.0f;

    // Define the maximum resources required to win
	public float MaxOxygen = 5.0f;
	public float MaxBiomass = 0.0f;
	public float MaxIron = 0.0f;
	public float MaxSilicon = 0.0f;
	public float MaxEnergy = 0.0f;

	private float min_range;
	private float max_range;

	private GameObject[] oxygenBuildings;
	private GameObject[] ironBuildings;
	private GameObject[] energyBuildings;
	private GameObject[] biomassBuildings;
	private GameObject[] siliconBuildings;

	void Start () {
		
	}

	void MinRange(float level){
		min_range = 1f + (level * 0.5f * Random.Range(0.0f, level));
	}

	void MaxRange(float level){
		max_range = 2.0f + (level * 1f * Random.Range(level, level * 2.0f));
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextUpdateTime) {
			nextUpdateTime += updatePeriod;
			Timer -= updatePeriod;

			if (Timer < 0.0) {
				// game over
			}

			oxygenBuildings = GameObject.FindGameObjectsWithTag ("OxygenBuilding");
			ironBuildings = GameObject.FindGameObjectsWithTag ("IronBuilding");
			biomassBuildings = GameObject.FindGameObjectsWithTag ("BiomassBuilding");
			siliconBuildings = GameObject.FindGameObjectsWithTag ("SiliconBuilding");
			energyBuildings = GameObject.FindGameObjectsWithTag ("EnergyBuilding");

			// search for Oxygen Building List.
			foreach (GameObject oxyBuild in oxygenBuildings) {
				Oxygen += ((oxyBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor) / 20.0f);
			}
			foreach (GameObject iroBuild in ironBuildings) {
				Iron += (iroBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor  / 20.0f);
			}
			foreach (GameObject bioBuild in biomassBuildings) {
				Biomass += (bioBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor  / 20.0f );
			}
			foreach (GameObject silBuild in siliconBuildings) {
				Silicon += (silBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor  / 20.0f );
			}
			foreach (GameObject engBuild in energyBuildings) {
				Energy += (engBuild.GetComponent<ComputeResourceArea>().area * ResourceFactor  / 20.0f );
			}

			if (Oxygen >= MaxOxygen && Energy >= MaxEnergy && Iron >= MaxIron && Biomass >= MaxBiomass && Silicon >= MaxSilicon) {
				Level += 1.0f;
				Timer = 60.0f + ((Level - 1.0f) * 2);

				MinRange (Level);
				MaxRange (Level);
				MaxOxygen = MaxOxygen + Random.Range (min_range, max_range);

				MinRange (Level);
				MaxRange (Level);
				MaxIron = MaxIron + Random.Range (min_range, max_range);

				if (Level > 4.0) {
					MinRange (Level);
					MaxRange (Level);
					MaxBiomass = MaxBiomass + Random.Range (min_range, max_range);

				}

				if (Level > 7.0){
					MinRange (Level);
					MaxRange (Level);
					MaxSilicon = MaxSilicon + Random.Range (min_range, max_range);					
				}

				if (Level > 12.0){
					MinRange (Level);
					MaxRange (Level);
					MaxEnergy = MaxEnergy + Random.Range (min_range, max_range);					
				}

			}

			//Biomass += 0.1f;
			//Iron += 0.1f;
			//Silicon += 0.1f;
			//Energy += 0.1f;
			//Debug.Log (Oxygen);
		}
	}
}
