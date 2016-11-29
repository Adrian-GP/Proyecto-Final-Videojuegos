using UnityEngine;
using System.Collections;

public class rayviewer : MonoBehaviour {

	public float weaponrange = 50f;

	private Camera fpsCam;


	void Start () {
		fpsCam = GetComponentInParent<Camera> ();
	}

	void Update () {
		Vector3 lineOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0));
		Debug.DrawRay (lineOrigin, fpsCam.transform.forward * weaponrange, Color.green);
	}
}
