using UnityEngine;
using System.Collections;

/// <summary>
/// Bullet base controller.
/// 砲台
/// </summary>
public class BulletBaseController : MonoBehaviour {

	public GameObject bulletPF;
	private GameObject _bulletBase;
	private const float FORCE = 500.0f;

	// Use this for initialization
	void Start () {
		_bulletBase = GameObject.Find (GameConfig.CODE_BULLET_BASE);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 ballVector = Vector3.zero;
			ballVector.x = Mathf.Sin(2 * Mathf.PI * transform.eulerAngles.x / 360) * Mathf.Sin(2 * Mathf.PI * transform.eulerAngles.y / 360);
			ballVector.z = Mathf.Sin(2 * Mathf.PI * transform.eulerAngles.x / 360) * Mathf.Cos(2 * Mathf.PI * transform.eulerAngles.y / 360);
			ballVector.y = Mathf.Cos(2 * Mathf.PI * transform.eulerAngles.x / 360);

			GameObject ball = Instantiate(bulletPF, transform.position, Quaternion.identity) as GameObject;
			// 力を加える
			ball.rigidbody.AddForce(ballVector * FORCE);
			Debug.Log("AddForce =" + ballVector * FORCE + "," + (ballVector * FORCE).magnitude);
			// 発射元の砲台
			//ball.GetComponent(ballScript).cannon = transform;
		}
	}
}
