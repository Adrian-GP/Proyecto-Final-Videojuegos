using UnityEngine;
using System.Collections;

public class gun : MonoBehaviour {

	public static int bulletdmg = 50;
	public static float firerate = 0.25f;
	public static float weaponrange = 50f;
	public static float hitForce = 100f;
	public Transform gunEnd; //This is the place from wich the bullet shoots o


	private Camera fpsCam;

	private WaitForSeconds shootDuration = new WaitForSeconds (0.07f);


	private LineRenderer bulletline;

	private float nextFire; //Time until we allow to fire again.

	public AudioSource audio;

	void Start () {
		bulletline = GetComponent<LineRenderer> ();
		fpsCam = GetComponentInParent<Camera> ();
	}
	

	void Update () {
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + firerate;

			StartCoroutine (shooteffect ());

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit Hit;

			//bulletline.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out Hit, weaponrange)) {
				//bulletline.SetPosition (1, Hit.point);

				enemy health = Hit.collider.GetComponent<enemy>();

				if (health != null) {
					health.Damage(bulletdmg, Hit.collider);
				}

				if (Hit.rigidbody != null) {
					Hit.rigidbody.AddForce (-Hit.normal * hitForce);
				}
			} 
			else {
				//bulletline.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponrange));
			}
		}
	}

	private IEnumerator shooteffect(){
	
		audio.Play ();

		//bulletline.enabled = true;

		yield return shootDuration;

		//	bulletline.enabled = false;
	}
}
