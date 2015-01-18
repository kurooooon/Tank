using UnityEngine;
using System.Collections;

/// <summary>
/// Bullet controller.
/// </summary>
public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision col) {
//		Debug.Log ("onCollision bullet:" + col.gameObject.tag);

		//床にあたったら消す
		if (col.gameObject.tag == GameConfig.TAG_GROUND)
			Destroy (gameObject);
	}
}
