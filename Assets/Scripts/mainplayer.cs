using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainplayer : MonoBehaviour {
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit();
		}
	}