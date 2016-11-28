using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainplayer : MonoBehaviour {
	public GameObject[] weaponArray;
	public bool[] boolArr;

	public void changeWeapon()
	{
		Debug.Log("asdasd");
	}

	void Start(){
		weaponArray[0].SetActive(true);
		weaponArray[1].SetActive(false);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)){
			Application.Quit();
		}
		if (Input.GetKey("1"))
		{
			//Reload Animation
			weaponArray[0].SetActive(true);
			weaponArray[1].SetActive(false);
		}

		if (Input.GetKey("2")&&boolArr[1]==true)
		{
			//Reload Animation
			weaponArray[0].SetActive(false);
			weaponArray[1].SetActive(true);
		}

		
	}
}
