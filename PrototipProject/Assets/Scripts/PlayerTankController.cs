using UnityEngine;
using System.Collections;

public class PlayerTankController : MonoBehaviour {
	public float Speed = 4f;
	public float Gravity = 20.0f;
	private Vector3 moveDirrection = Vector3.zero;
	private Vector3 rotateDirrection = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			//moveDirrection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirrection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			rotateDirrection = new Vector3 (0, Input.GetAxis ("Horizontal") , 0);
			moveDirrection = transform.TransformDirection (moveDirrection);

			moveDirrection *= Speed;
		}
		moveDirrection.y -= Gravity * Time.deltaTime;
		controller.Move (moveDirrection * Time.deltaTime);
		transform.Rotate (rotateDirrection);
		//controller.transform.Rotate (moveDirrection);
	}
}
