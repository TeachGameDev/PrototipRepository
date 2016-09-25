using UnityEngine;
using System.Collections;

public class BashController : MonoBehaviour {
	public float SpeedBash=10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(1))
		{
			Vector2 vec = new Vector3(0,Input.mousePosition.y,0);
			transform.RotateAround (transform.position, vec, SpeedBash * Time.deltaTime);
		}
	}
}
