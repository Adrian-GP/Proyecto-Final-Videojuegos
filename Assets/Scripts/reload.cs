using UnityEngine;
using System.Collections;

public class reload : MonoBehaviour {

	// Time taken for the reloading animation to finish. Varies depending on the weapon.
	public float fTimeToReload;

	// Animator controller of the weapon object that is component is attached to.
	public Animator anim;

	// Object that references a script that controls all data related to shooting.
	private shoot sh;

	// Use this for initialization
	void Start () {
		sh = this.GetComponent<shoot> ();
	}
	
	// Function that is called once per frame
	void Update () {
		if (Input.GetKeyDown("r") && sh.iCartridges != 0)
		{
			// Execute the reload animation
			if (!anim.GetBool ("Reload"))
				anim.SetBool ("Reload", true);

			// Set bullets to maximum.
			sh.iActualBullets = sh.iMaxBullets;

			// If the number of cartridges isn't infinity (-1), decrease it by 1.
			if (sh.iCartridges != -1)
				sh.iCartridges--;

			// Wait till reloading finishes to set the player status to "is not reloading".
			StartCoroutine(waitForReload());
		}
	}

	// Waits for some time till the reload has finished.
	private IEnumerator waitForReload()
	{
		sh.bReload = true;
		yield return new WaitForSeconds (fTimeToReload);
		sh.bReload = false;
	}
}
