using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	// public attributes.
	public static int iMaxHealth;
	public static int iCurrentHealth;
	public Image imageHealth;

	// Use this for initialization
	void Start () {
		iMaxHealth = iCurrentHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (iCurrentHealth <= 0)
		{
			// Game Over.
		}
		imageHealth.fillAmount = (float)iCurrentHealth / iMaxHealth;
	}
}
