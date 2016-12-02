using UnityEngine;
using System.Collections;

public class heal : MonoBehaviour {

	public int AmmountToHeal;

	// Function that executes when a collider touches the object that contains this script (a weapon).
	void OnTriggerEnter(Collider col)
	{
		// If the collider was a Player...
		if(col.tag == "Player"){
			// Get the weapon controller attached to the player.
			gameController gameCtrl = col.gameObject.GetComponent<gameController>();

			gameCtrl.Heal (AmmountToHeal);

			// Destroy this weapon
			Destroy (this.gameObject);
		}
	}
}
