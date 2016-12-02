//#pragma strict
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class jugarAhora : MonoBehaviour {
	public void ChangeScene(string scene){
		PlayerPrefs.SetInt("wave",1);
		SceneManager.LoadScene("map1");
	}

	public void showInstructions(string scene){
		SceneManager.LoadScene("instrucciones");
	}

	public void goBackMenu(string scene){
		SceneManager.LoadScene("inicioScene");
	}

	public void goCredits(string scene){
		SceneManager.LoadScene("creditosScene");
	}

	public void goStory(string scene){
		SceneManager.LoadScene("historiaScene");
	}

	public void appQuit(string scene){
		Application.Quit ();
	}
}