using UnityEngine;
using System.Collections;
/// <summary>
/// Simple Elevator Script
/// </summary>
public class Elevator : BaseComponent {
	#region Variables
	/// Flips between moving up and down
	private bool isMovingUp = true;
	/// Rate the elevator travels
	public int moveSpeed = 1;
	/// The start position
	private Vector3 startPos;
	/// The end position
	private Vector3 endPos;
	/// How far the elevator moves before flipping directions
	private int distanceMax = 0;
	#endregion
	#region Engine
	/// <summary>
	/// When the script starts, this is called
	/// </summary>
	void Start () {
		startPos = transform.position; //start starting position on script start
		endPos = transform.position;
		endPos.y += transform.localScale.y * 3; //distance is 3x the scale of the game object
		StartCoroutine(DoElevatorLoop());
	}
	
	#endregion
	#region Private Methods
	//Coroutine to loop elevator
	private IEnumerator DoElevatorLoop() {		
		while (true) {
			yield return 0; //wait a frame
			if (!enabled) continue; //Don't bother running code if the script is disabled.
			Vector3 moveDirection = (isMovingUp ? Vector3.up : Vector3.down); //Apply move direction
			moveDirection *= moveSpeed; //apply move speed
			transform.position += moveDirection; //apply new destination to position
			if (transform.position.y <= startPos.y) isMovingUp = true; //if we hit startpos or less, move up
			else if (transform.position.y >= endPos.y) isMovingUp = false; //if we hit endpos or greater, move down
		}
	}
	#endregion
}
