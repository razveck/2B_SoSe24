using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	private InputAction _move;
	private InputAction _look;

	private float _cameraXRotation;

	public PlayerInput PlayerInput;
	public CharacterController Controller;
	public Transform Camera;


	public float Speed = 10f;


	// Start is called before the first frame update
	void Start() {
		_move = PlayerInput.actions.FindAction("Move");
		_look = PlayerInput.actions.FindAction("Look");
		_cameraXRotation = Camera.rotation.eulerAngles.x;
	}

	// Update is called once per frame
	void Update() {
			
		Vector2 moveInput = _move.ReadValue<Vector2>();

		Vector3 moveAmount = transform.forward * moveInput.y + transform.right * moveInput.x;

		Controller.Move(moveAmount * Speed * Time.deltaTime);


		//holen ein Vector2 aus dem _look
		Vector2 lookInput = _look.ReadValue<Vector2>();
		Vector3 cameraRotation = Camera.rotation.eulerAngles;
		_cameraXRotation += lookInput.y;
		_cameraXRotation = Mathf.Clamp(_cameraXRotation, 0, 90);

		cameraRotation.x = _cameraXRotation;

		Camera.eulerAngles = cameraRotation;

		transform.Rotate(0, lookInput.x, 0);

		//radiant (rad)
		//float angle = _cameraXRotation * Mathf.Deg2Rad;
		//float z = Mathf.Cos(angle);
		//float y = Mathf.Sin(angle);

		//Vector3 cameraPosition = Camera.position;
		//cameraPosition.z = z;
		//cameraPosition.y = y;
		//Camera.position = cameraPosition;
	}
}
