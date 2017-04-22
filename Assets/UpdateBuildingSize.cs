using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBuildingSize : MonoBehaviour {

	public float buildingRadius;

	public Int32 BuildingLevel;

	private Int32 _currentBuildingLevel;

	// Use this for initialization
	void Start () {
		
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

		CreateBlockRing(2, center, currentBuildingLevel / 6);
	}

	private void CreateBlockRing(Int32 numObjects, Vector3 center, Single size)
	{
		for (int i = 0; i < numObjects; i++)
		{
			var b = CreateBlock();
			b.transform.SetParent(gameObject.transform, worldPositionStays: false);
			b.transform.localPosition = Circle(center, 5.0f * (numObjects - 1), currentObject: i, count: numObjects);
			b.transform.localScale += new Vector3 { y = size };
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
}
