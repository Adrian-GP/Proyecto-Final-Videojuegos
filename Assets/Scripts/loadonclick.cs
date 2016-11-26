using UnityEngine;
using System.Collections;

public class loadonclick : MonoBehaviour {
	
	//Name of teh scene we want to load
	public void LoadScene (int n) {
		Application.LoadLevel(n);
	}

}
