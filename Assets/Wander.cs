using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
	public float speed = 5;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 30;

	private float xmin = -5.72f, xmax = 2.86f, zmin = -2.09f, zmax = 3.92f;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;

	void Awake ()
	{
		controller = GetComponent<CharacterController>();

		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);

		StartCoroutine(NewHeading());
	}

	void Update ()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		Vector3 oriPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		controller.SimpleMove(forward * speed);
		if (transform.position.x < xmin || transform.position.x > xmax || transform.position.z < zmin || transform.position.z > zmax)
			transform.position = oriPos;
	}

	/// <summary>
	/// Repeatedly calculates a new direction to move towards.
	/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	/// </summary>
	IEnumerator NewHeading ()
	{
		while (true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

	/// <summary>
	/// Calculates a new direction to move towards.
	/// </summary>
	void NewHeadingRoutine ()
	{
		var floor = transform.eulerAngles.y - maxHeadingChange;
		var ceil  = transform.eulerAngles.y + maxHeadingChange;
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
	}
}