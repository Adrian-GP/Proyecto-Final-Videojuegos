using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	// Public attributes.
	public int iBulletDmg;
	public int iActualBullets;
	public int iMaxBullets;
	public int iCartridges;
	public float fFireRate;
	public float fWeaponRange;
	public float fHitForce;
	public bool bReload;
	public Transform tShootPoint;
	public AudioSource audioShoot;
	public Camera cam;

	// Private attributes.
	private float fNextFire;

	// Attribute used only for displaying a raycast while testing:
	// private LineRenderer lBulletLine;

	// Use this for initialization
	void Start () {
		bReload = false;
		fNextFire = 0f;
		iActualBullets = iMaxBullets;
	}
	
	// Function that is called once per frame
	void Update () {
		
		// If there is a left click in the mouse AND
		// the time is greater than the minimum possible time to be able to shoot AND
		// there are enough bullets AND
		// the player isn't reloading...
		if(iMaxBullets==30)
		{
			if (Input.GetButton("Fire1") && Time.time > fNextFire && iActualBullets > 0 && !bReload)
			{
				// Set the next minimum possible time to shoot and play the shooting sound effect.
				fNextFire = Time.time + fFireRate;
				StartCoroutine (playSoundEffect ());

				// Call the function that simulates the shot.
				fire ();

				// Reduce the number of bullets available.
				iActualBullets--;
			}

		}
		else
		{
			if (Input.GetButtonDown("Fire1") && Time.time > fNextFire && iActualBullets > 0 && !bReload)
			{
				// Set the next minimum possible time to shoot and play the shooting sound effect.
				fNextFire = Time.time + fFireRate;
				StartCoroutine (playSoundEffect ());

				// Call the function that simulates the shot.
				fire ();

				// Reduce the number of bullets available.
				iActualBullets--;
			}
		}
		
	}

	// Function to simulate the action of shooting.
	private void fire()
	{
		// Vector that represents the position of the center of the camera in world coordinates.
		Vector3 v3RayOrigin = cam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0f));

		// Object that will store information about the object that will collide with the raycast.
		RaycastHit rayHit;

		// If the raycast generated collided with something...
		if (Physics.Raycast (v3RayOrigin, cam.transform.forward, out rayHit, fWeaponRange))
		{
			// If the object that collided with the ray is an enemy...
			if (rayHit.collider.gameObject.tag == "Enemy")
			{
				// Deal damage to the enemy
				rayHit.collider.GetComponent<enemy>().damage(iBulletDmg);
			}

			// If there is a rigidbody attached to the object detected by the raycast, add a force.
			if (rayHit.rigidbody != null)
			{
				rayHit.rigidbody.AddForce (-rayHit.normal * fHitForce);
			}
		}
	}

	// Coroutine for playing the shooting sound effect.
	private IEnumerator playSoundEffect()
	{
		audioShoot.Play ();
		yield return new WaitForSeconds (0.07f);
	}
}
