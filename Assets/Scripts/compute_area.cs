using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compute_area : MonoBehaviour {
	/// <summary>
	/// Approximate the area of intersection of two sphrical caps
	/// fRadus0 : First caps' radius (arc length in radians)
	/// fRadius1 : Second caps' radius (in radians)
	/// fDist : Distance between caps (radians between centres of the caps)
	/// 
	/// References:
	///  -  Code is adapted from slide 15 in here http://developer.amd.com/wordpress/media/2012/10/Oat-AmbientApetureLighting.pdf
	///     This is an effective approximation for the area.. the actual method is much more numerically intensive.
	///  -  Spherical Cap https://en.wikipedia.org/wiki/Spherical_cap
	///  -  Saturate: https://unitygem.wordpress.com/shader-part-1/ and http://http.developer.nvidia.com/Cg/saturate.html
	///  -  SmoothStep: https://docs.unity3d.com/ScriptReference/Mathf.SmoothStep.html
	/// 
	/// </summary> 

	public float fRadius0 = 0.0f;
	public float fRadius1 = 0.0f;
	public float fDist = 0.0f;
	public float fDiff = 0.0f;
	public float fArea = 0.0f;
	public float fSat = 0.0f;

	// Use this for initialization
	void Start () {
		
	}

	void Saturate(){
		fSat = Mathf.Max(0.0f, Mathf.Min(1.0f, ((fDist - fDiff) / (fRadius0 + fRadius1 - fDiff))));
	}
	
	// Update is called once per frame
	void Update () {
		if (fDist <= Mathf.Max (fRadius0, fRadius1) - Mathf.Min (fRadius0, fRadius1)) {
			// one cap is completely inside the other
			fArea = 6.283185308f - (6.283185308f * Mathf.Cos (Mathf.Min (fRadius0, fRadius1)));

		} else if (fDist >= fRadius0 + fRadius1) {
			// no intersection exists
			fArea = 0.0f;

		} else {
			// here we have an overlap
			fDiff = Mathf.Abs(fRadius0 - fRadius1);
			Saturate();
			fArea = Mathf.SmoothStep (0.0f, 1.0f, fSat);
			fArea *= 6.283185308f - (6.283185308f * Mathf.Cos (Mathf.Min (fRadius0, fRadius1)));
		}

	}
}
