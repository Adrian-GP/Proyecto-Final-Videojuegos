using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
			SceneManager.LoadScene("gameOver");
			Cursor.visible = true;
			Screen.lockCursor = false;
		}
		imageHealth.fillAmount = (float)iCurrentHealth / iMaxHealth;
	}

	public void Heal (int amount) {
		iCurrentHealth += amount;
		if (iCurrentHealth > iMaxHealth) {
			iCurrentHealth = iMaxHealth;
		}
	}
}
