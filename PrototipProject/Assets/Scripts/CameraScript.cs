using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject ObjectToTransfom;
	public float SpeedRotate = 10;
	public float MinDistance = 2;
	public float MaxDistance = 6;

	private float x;
	private float y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		x = Input.GetAxis ("Mouse X")*SpeedRotate*10;
	//	y = Input.GetAxis ("Mouse Y")*SpeedRotate*Time.deltaTime;

		if (Input.GetMouseButtonDown (0)) {
			transform.RotateAround (ObjectToTransfom.transform.position, transform.up, x*Time.deltaTime);
			Debug.Log (x);
			transform.RotateAround (ObjectToTransfom.transform.position, transform.right, y*Time.deltaTime);

			transform.rotation = Quaternion.LookRotation (ObjectToTransfom.transform.position - transform.position);
			transform.eulerAngles = new Vector3 (transform.position.x, transform.position.y, 0);
		}
	}
}
