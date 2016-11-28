using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour {

	public GameObject gun; 

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player"){
		 	 mainplayer mainplayer = col.gameObject.GetComponent<mainplayer>();
		 	 mainplayer.changeWeapon();
			 Destroy(gun);
			 mainplayer.weaponArray[1].SetActive(true);
			 mainplayer.weaponArray[0].SetActive(false);
			 mainplayer.boolArr[1]=true;
	 }
	}
}
