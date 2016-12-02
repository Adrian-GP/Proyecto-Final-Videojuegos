using UnityEngine;
using System.Collections;

public class ammo : MonoBehaviour {

	public string WeaponAmmoIsFor;
	public int AmmoAmmount;

	// Function that executes when a collider touches the object that contains this script (a weapon).
	void OnTriggerEnter(Collider col)
	{
		// If the collider was a Player...
		if(col.tag == "Player"){
			// Get the weapon controller attached to the player.
			shoot shooter = GameObject.Find(WeaponAmmoIsFor).gameObject.GetComponent<shoot>();
			shooter.iCartridges += AmmoAmmount;

			// Destroy this weapon
			Destroy(this.gameObject);
		}
	}
}
