using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class protectzone : MonoBehaviour {

	int ihealth;
	public Text thp;

	void Start(){
		ihealth = 100;
		thp.text = "Tu vida restante: " + ihealth.ToString ();
	}

	void Update(){
		if (ihealth <= 0)
			Application.LoadLevel (4);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "enemy1(Clone)"){
			ihealth -= 5;
		}
		else if (col.gameObject.name == "enemy2(Clone)"){
			ihealth -= 20;
		}
		else  if (col.gameObject.name == "enemy3(Clone)"){
			ihealth -= 25;
		}

		setHp ();
	}

	void setHp(){
		thp.text = "Tu vida restante: " + ihealth.ToString ();
	}
}
