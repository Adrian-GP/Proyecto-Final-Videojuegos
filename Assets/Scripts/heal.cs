using UnityEngine;
using System.Collections;

public class heal : MonoBehaviour {

	public int AmmountToHeal;
	public gameController gameCtrl;

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
			// Get the weapon controll

			gameCtrl.Heal (AmmountToHeal);

			// Destroy this weapon
			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<BoxCollider> ().enabled = false;
			Invoke ("clonarHP", 180);
		}
	}

	void clonarHP()
	{
		GameObject newClone = Instantiate (gameObject, transform.position, transform.rotation) as GameObject;
		Destroy(gameObject);
		Debug.Log ("Aaah");

	}
}
