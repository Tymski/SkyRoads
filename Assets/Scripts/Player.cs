using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float sidewaysThrust;
	public float jumpForce;
	[Header("Forward")]
	public float forwardThrust;
	public float maxForwardThrust;
	public float forwardThrustSpeed;

	public float energy;

	public new Rigidbody rigidbody;

	public Transform groundCheck;

	private float jumpCooldown = 0.1f;
	private float velocityMagnitude;
	private float hitCooldown = 0.1f;

	public float hitForceTreshold;

	public static Player Instance;

	private void Awake()
	{
		Instance = this;
	}

	private void FixedUpdate()
	{
		MovingForward();
		Stabilization();
		Jumping();
		velocityMagnitude = rigidbody.velocity.magnitude;
		hitCooldown -= Time.fixedDeltaTime;
	}

	void MovingForward()
	{
		forwardThrust += Input.GetAxis("Vertical") * forwardThrustSpeed * Time.fixedDeltaTime;
		forwardThrust = Mathf.Clamp(forwardThrust, 0, maxForwardThrust);

		rigidbody.AddRelativeForce(
			Input.GetAxisRaw("Horizontal") * sidewaysThrust * Time.fixedDeltaTime,
			0 - 5f * Time.fixedDeltaTime,
			forwardThrust * Time.fixedDeltaTime,
			ForceMode.VelocityChange
		);
	}

	void Jumping()
	{
		// if is grounded
		if (Physics.Raycast(groundCheck.position, Vector3.down, 0.1f))
		{
			if (jumpCooldown < 0 && Input.GetAxisRaw("Jump") > 0)
			{
				if (rigidbody.velocity.y < 0)
					rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
				rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
				jumpCooldown = 0.1f;
			}
		}
		jumpCooldown -= Time.fixedDeltaTime;
	}

	void Stabilization()
	{
		rigidbody.AddRelativeTorque(
			0 - transform.rotation.x * 500 * Time.fixedDeltaTime,
			0 - transform.rotation.y * 500 * Time.fixedDeltaTime,
			0 - transform.rotation.z * 500 * Time.fixedDeltaTime
		);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Ground")) return;

		// Debug.Log(other.relativeVelocity.magnitude);

		// Debug.Log(rigidbody.velocity.magnitude);

		Debug.Log(rigidbody.velocity.magnitude - velocityMagnitude);
		if (hitCooldown < 0f)
		{
			float hitForce = velocityMagnitude - rigidbody.velocity.magnitude;
			if (hitForce > hitForceTreshold)
			{
				hitCooldown = 0.1f;
				energy -= hitForce - hitForceTreshold;
				forwardThrust -= (hitForce - hitForceTreshold) * 2;
			}
		}

	}

}