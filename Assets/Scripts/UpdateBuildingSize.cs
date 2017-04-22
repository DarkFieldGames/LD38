using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBuildingSize : MonoBehaviour {

	public float buildingRadius;

	public Int32 BuildingLevel;

	public Int32 RingSize = 1;

	private Int32 _currentBuildingLevel;

	public float debugCircle;

	// Use this for initialization
	void Start () {
		debugCircle = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(BuildingLevel != _currentBuildingLevel)
		{
			_currentBuildingLevel = BuildingLevel;
			Recalculate(_currentBuildingLevel);
		}
	}

	private void Recalculate(Int32 currentBuildingLevel)
	{
		foreach (Transform child in gameObject.transform)
		{
			Destroy(child.gameObject);
		}

		var o = CreateBlock();
		o.transform.SetParent(gameObject.transform, worldPositionStays: false);
		o.transform.localScale += new Vector3 { y = currentBuildingLevel };

		if (_currentBuildingLevel < 4)
			return;

		Int32 numObjects = 3;
		Vector3 center = new Vector3(0,0,0);
		float size = currentBuildingLevel / numObjects;

		CreateBlockRing(numObjects, center, size);

		if (currentBuildingLevel < 6)
			return;

		CreateBlockRing(6, center, currentBuildingLevel / 6);
		AddCircle (0.125f * 2*Mathf.PI);
	}

	private void CreateBlockRing(Int32 numObjects, Vector3 center, Single size)
	{
		for (int i = 0; i < numObjects; i++)
		{
			var b = CreateBlock();
			b.transform.SetParent(gameObject.transform, worldPositionStays: false);
			b.transform.localPosition = Circle(center, RingSize * numObjects, currentObject: i, count: numObjects);
			b.transform.localScale += new Vector3 { y = size * 2 };
		}
	}

	Vector3 Circle ( Vector3 center , float radius, Int32 currentObject, Int32 count ){
         float ang = currentObject * 360 / count;
         Vector3 pos;
         pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
         pos.y = center.y;
         pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
         return pos;
     }

	private static GameObject CreateBlock()
	{
		return GameObject.CreatePrimitive(PrimitiveType.Cube);
	}

	private void AddCircle(float angleRadius)
	{
		float width = (7.0f/0.3f) * Mathf.Sin (angleRadius);
		float depth = (7.0f/0.3f) * (Mathf.Cos (angleRadius)-1);

		GameObject circle = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		circle.transform.SetParent(gameObject.transform, worldPositionStays: false);
		circle.transform.localPosition = Circle(new Vector3(0,depth,0), 0.0f, 1, 1);

		circle.transform.localScale = new Vector3 (2*(width*1.05f), 0.1f, (2*width*1.05f));
	}
}
