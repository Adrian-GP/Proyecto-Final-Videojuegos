using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour {

	// Private attribute
	private string sWeaponName;

	// Function that initializes values.
	void Start()
	{
		sWeaponName = this.gameObject.name;
	}

	// Function that executes when a collider touches the object that contains this script (a weapon).
	void OnTriggerEnter(Collider col)
	{
		// If the collider was a Player...
		if(col.tag == "Player"){
			// Get the weapon controller attached to the player.
			weaponController weaponCtrl = col.gameObject.GetComponent<weaponController>();

			// Get the index of this weapon in the dictionary of weapons of the weapon controller.
			int iNewIndex = weaponCtrl.dicWeapons [sWeaponName];

			// Get the index of the last (current) weapon used by the player.
			int iPrevIndex = weaponCtrl.iLastWeaponUsed;

			// Set the weapon with iNewIndex to Active and the weapon with iPrevIndex to Inactive.
			weaponCtrl.arrGObjWeapons [iPrevIndex].SetActive (false);
			weaponCtrl.arrGObjWeapons [iNewIndex].SetActive (true);

			// Add this weapon (the one of the object that contains this script) to the player and
			// change his actual weapon to it.
			weaponCtrl.bArrWeapons[iNewIndex] = true;
			weaponCtrl.iLastWeaponUsed = iNewIndex;

			// Destroy this weapon
			Destroy (this.gameObject);
	 }
	}
}
