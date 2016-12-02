using UnityEngine;
using System.Collections;

public class ammo : MonoBehaviour {

	public int AmmoAmmount;
	public shoot shooter;

	void Start()
	{
		GetComponent<MeshRenderer> ().enabled = true;
		GetComponent<BoxCollider> ().enabled = true;
	}

	// Function that executes when a collider touches the object that contains this script (a weapon).
	void OnTriggerEnter(Collider col)
	{
		// If the collider was a Player...
		if(col.tag == "Player"){
			shooter.iCartridges += AmmoAmmount;

			// Destroy this weapon
			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<BoxCollider> ().enabled = false;
			Invoke ("clonarAmmo", 180);
		}
	}

	void clonarAmmo()
	{
		GameObject newClone = Instantiate (gameObject, transform.position, transform.rotation) as GameObject;
		Destroy(gameObject);
		Debug.Log ("Aaah");

	}
}
