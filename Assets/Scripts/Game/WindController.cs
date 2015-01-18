using UnityEngine;
using System.Collections;

/// <summary>
/// Wind controller.
/// </summary>
public class WindController : MonoBehaviour {

	private Vector3 _wind;
	// Use this for initialization
	void Start () {
		_wind = new Vector3 (-5, 0, 0);
		constantForce.force = _wind;
	}
	
	// Update is called once per frame
	void Update () {
//		constantForce.force = _wind;
	}
}
