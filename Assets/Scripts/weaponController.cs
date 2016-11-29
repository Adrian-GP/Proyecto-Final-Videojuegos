using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class weaponController : MonoBehaviour {

	// Public attributes.
	public GameObject[] arrGObjWeapons;
	public bool[] bArrWeapons;
	public Dictionary<string, int> dicWeapons;
	public int iLastWeaponUsed;
	public shoot[] arrShoot;

	// Function that initializes values.
	void Start(){

		// Sets the weapon 0 as the default weapon.
		arrGObjWeapons[0].SetActive(true);
		bArrWeapons[0] = true;
		iLastWeaponUsed = 0;

		// Sets all other weapons as inactive and with the status of not having them.
		for (int iX = 1; iX < arrGObjWeapons.Length; iX++)
		{
			arrGObjWeapons [iX].SetActive (false);
			bArrWeapons [iX] = false;
		}

		// Initializes the dictionary with the names of the objects in the weapon array
		// and their index. Also initializes the arrShoot array with the "shoot" component
		// of each weapon.
		dicWeapons = new Dictionary<string, int>();
		for (int iX = 0; iX < arrGObjWeapons.Length; iX++)
		{
			dicWeapons.Add (arrGObjWeapons [iX].name, iX);
			arrShoot [iX] = arrGObjWeapons [iX].GetComponent<shoot> ();
		}

	}

	// Function that is called once per frame.
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit();
		}

		// If the actual weapon isn't reloading, it is possible to change to other weapon.
		if (!arrShoot[iLastWeaponUsed].bReload)
		{
			// Conditions to check to what weapon the player will change.
			if (Input.GetKey ("1"))
			{
				arrGObjWeapons [iLastWeaponUsed].SetActive (false);
				arrGObjWeapons [0].SetActive (true);
				iLastWeaponUsed = 0;
			}

			if (Input.GetKey ("2") && bArrWeapons [1] == true)
			{
				arrGObjWeapons [iLastWeaponUsed].SetActive (false);
				arrGObjWeapons [1].SetActive (true);
				iLastWeaponUsed = 1;
			}
		}
		
	}
}
