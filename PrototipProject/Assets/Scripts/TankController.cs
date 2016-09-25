using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {

	//public WheelCollider[] WColForward;
	//public WheelCollider[] WColBack;

	public WheelCollider[] WColRight;
	public WheelCollider[] WColLeft;

	public float Speed = 25;
	public float SpeedRotate = 30;
	public float MaxBreak = 50;
	public float SpeedRightLeftMove = 10;
	//public float maxSteer = 30; //1
	//public float maxAccel = 25; //2
	//public float maxBrake = 50; //3


	// Use this for initialization
	void Start () {

	}


	void FixedUpdate () {

		float accel = 0;
		float steer = 0;

		accel = Input.GetAxis("Vertical");  //4
		steer = Input.GetAxis("Horizontal");	 //4	

		CarMove(accel,steer); //5

	}

	private void CarMove(float accel,float steer){ //5

		if (accel != 0) {

			if (steer != 0) {
				MoveAndRightLeft (accel, steer);
			} else {
				MoveTank (accel);
			}
		} else {
			if (steer != 0) {
				RightLeftMove (steer);
			} else {
				StopTank ();
			}
		}

	}

	private void StopTank()
	{
		foreach (WheelCollider colider in WColLeft) {
			colider.brakeTorque = MaxBreak;

		}
		foreach (WheelCollider colider in WColRight) {
			colider.brakeTorque = MaxBreak;

		}
	}

	private void RightLeftMove(float steer)
	{
		foreach (WheelCollider colider in WColLeft) {
			colider.brakeTorque = 0;
			colider.motorTorque = steer * SpeedRotate;
		}
		foreach (WheelCollider colider in WColRight) {
			colider.brakeTorque = 0;
			colider.motorTorque = -steer * SpeedRotate;
		}
	}


	private void MoveAndRightLeft(float accel, float steer)
	{
		
		foreach (WheelCollider colider in WColLeft) {
			colider.brakeTorque = 0;
			if (steer <0) {
				colider.motorTorque = steer*SpeedRightLeftMove;
			}else
				colider.motorTorque = accel * Speed;
		}
		foreach (WheelCollider colider in WColRight) {
			colider.brakeTorque = 0;
			if (steer >0) {
				colider.motorTorque = steer * SpeedRightLeftMove;
			}else
				colider.motorTorque = accel * Speed;
		}
				
	}
	private void MoveTank(float accel)
	{
		foreach (WheelCollider colider in WColLeft) {
			colider.brakeTorque = 0;
			colider.motorTorque = accel * Speed;
		}
		foreach (WheelCollider colider in WColRight) {
			colider.brakeTorque = 0;
			colider.motorTorque = accel * Speed;
		}
	}

}
