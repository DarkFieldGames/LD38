using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjector : MonoBehaviour
{

	public Color MasterColor = Color.red;
	public float ConeHeight = 5;

	private Color _internalColor = Color.white;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_internalColor == MasterColor)
			return;

		SetMasterColor(MasterColor);
	}

	public void SetMasterColor(Color newColor)
	{

		var projectors = GetComponentsInChildren<SetShaderValues>();
		
		projectors[0].SetShader(newColor);
		Color lineColor = newColor - new Color(0.5f, 0.5f, 0.5f, 0);
		projectors[1].SetShader(lineColor);

		_internalColor = newColor = MasterColor;
	}
}
