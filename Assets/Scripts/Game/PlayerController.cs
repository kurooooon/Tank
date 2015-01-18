using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller.
/// </summary>
public class PlayerController : MonoBehaviour {

	private GameObject _player;
	private CharacterController _cController;

	private float _speed = 10.0f;
	private float _gravity = 20.0f;
	private Vector3 _moveDirection;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find (GameConfig.CODE_PLAYER);
		_cController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
		//移動方向を取得
		_moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		_moveDirection = transform.TransformDirection(_moveDirection);
		_moveDirection *= _speed;

		// 移動
		_cController.Move(_moveDirection * Time.deltaTime);

//		if (Input.GetKeyDown (KeyCode.UpArrow)) {
//			print ("space key was pressed");
//		}
//		if (Input.GetKeyDown (KeyCode.DownArrow)) {
//
//			print ("space key was pressed");
//		}
//		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
//			print ("space key was pressed");
//		}
//		if (Input.GetKeyDown (KeyCode.RightArrow)) {
//			print ("space key was pressed");
//		}
	
	}
}
