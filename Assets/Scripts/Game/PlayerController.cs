using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller.
/// </summary>
public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10.0f;

	private GameObject _player;
//	private CharacterController _cController;
//	private float _gravity = 20.0f;
	private Vector3 _moveDirection;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find (GameConfig.CODE_PLAYER);
//		_cController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");

		// 上・下
		float z = Input.GetAxisRaw ("Vertical");

		// 移動する向きを求める
		Vector3 direction = new Vector3 (x, 0, z).normalized;
		direction.y = -0.9f;

		// 移動する向きとスピードを代入する
		rigidbody.velocity = direction * moveSpeed;
	}
}
