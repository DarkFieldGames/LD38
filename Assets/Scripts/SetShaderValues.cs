using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projector))]
public class SetShaderValues : MonoBehaviour {

	public Color ShaderColor = Color.white;

	private Color _internalColor = Color.white;

	private Projector projector;

	// Use this for initialization
	void Awake() {
		projector = GetComponent<Projector>();
	}

	void Start()
	{
		projector.farClipPlane = gameObject.transform.position.magnitude - 1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_internalColor == ShaderColor)
			return;

		SetShader(ShaderColor);
	}

	public void SetShader(Color newColor)
	{
		var m = new Material(projector.material);
		m.SetColor("_Color", newColor);
		projector.material = m;
		_internalColor = ShaderColor = newColor;
	}
}
