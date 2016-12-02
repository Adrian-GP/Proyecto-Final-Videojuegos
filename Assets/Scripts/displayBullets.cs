using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayBullets : MonoBehaviour {

	public Text tBullets;
	public Text tCartridges;
	private shoot sh;

	// Use this for initialization
	void Start () {
		sh = GetComponent<shoot> ();
	}
	
	// Update is called once per frame
	void Update () {
		tBullets.text = sh.iActualBullets.ToString ();
		if (sh.iCartridges != -1)
			tCartridges.text = sh.iCartridges.ToString ();
		else
			tCartridges.text = "∞";
	}
}
