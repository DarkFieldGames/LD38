using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpdateBuildingSize : MonoBehaviour {
	private const String BuildingTag = "Building";
	public float MasterRadius = 1;
	public Int32 BuildingLevel = 1;

	public Color BuildingColor;

	public GameObject BuildingCube;

	private Int32 _currentBuildingLevel = 0;

	public float[] UpperRingRadius = new float[] { 2f, 3f };

	public Single CircleAngleRadius = 1.0f;


	// Use this for initialization
	void Start () {
		InvokeRepeating("Increase", 1f, 0.5f);
	}

	void Increase()
	{
		BuildingLevel++;
	}
	
	// Update is called once per frame
	void Update() {
		if(BuildingLevel > _currentBuildingLevel)
		{
			Int32 difference = BuildingLevel - _currentBuildingLevel;
			for(int i = 0; i < difference;  i++)
			{
				Recalculate(i + _currentBuildingLevel);
			}
			_currentBuildingLevel = BuildingLevel;
		}
	}

	private void Recalculate(Int32 growingBuildingLevel)
	{
		GrowExisting(growingBuildingLevel);

		switch(growingBuildingLevel)
		{
			case 1:
				CreateBlock();
				AddCircle(CircleAngleRadius);
				break;
			case 3:
				CreateBlockRing(numObjects: 3, buildingRadius: MasterRadius * UpperRingRadius[0]);
				break;
			case 7:
				CreateBlockRing(numObjects: 7, buildingRadius: MasterRadius * UpperRingRadius[1]);
				break;
		}
	}

	private void GrowExisting(Int32 growingBuildingLevel)
	{
		foreach(Transform t in transform.Cast<Transform>().Where(t => t.CompareTag(BuildingTag)))
		{
			Single mean = 1f - (growingBuildingLevel * 0.1f);
			Single stdev = 0.5f;
			t.localScale += new Vector3 { y = Math.Max(0f, GetBellCurve(mean: mean, stdev: stdev)) };
		}
	}

	private void CreateBlockRing(Int32 numObjects, float buildingRadius)
	{
		for (int i = 0; i < numObjects; i++)
		{
			var b = CreateBlock();
			b.transform.localPosition = Circle( buildingRadius, currentSegment: i, count: numObjects);
		}
	}

	Vector3 Circle (float radius, Int32 currentSegment, Int32 count){
		float ang = GetBellCurve(mean: currentSegment * 360 / count, stdev: 10);
		return new Vector3
		{
			x = radius * Mathf.Sin(ang * Mathf.Deg2Rad),
			y = 0,
			z = radius * Mathf.Cos(ang * Mathf.Deg2Rad)
		};
     }

	private GameObject CreateBlock()
	{
		var cube = (GameObject) Instantiate(BuildingCube, parent: gameObject.transform, instantiateInWorldSpace: false);

		cube.GetComponent<MeshRenderer>().material.color = BuildingColor;
		return cube;
	}

	private System.Random rand = new System.Random();

	private float GetBellCurve(float mean = 5f, float stdev = 2.0f)
	{
		double u1 = 1.0-rand.NextDouble(); //uniform(0,1] random doubles
		double u2 = 1.0-rand.NextDouble();
		double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
		return Convert.ToSingle(mean + stdev * randStdNormal);
	}

	private void AddCircle(float angleRadius)
	{
		float width = (7.0f/0.3f) * Mathf.Sin (angleRadius);
		float depth = (7.0f/0.3f) * (Mathf.Cos (angleRadius)-1);

		GameObject circle = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		circle.transform.SetParent(gameObject.transform, worldPositionStays: false);
		circle.transform.localPosition = new Vector3(0,depth,0) + Circle( 0.0f, 1, 1);

		circle.transform.localScale = new Vector3 (2*(width*1.05f), 0.1f, (2*width*1.05f));
	}
}
