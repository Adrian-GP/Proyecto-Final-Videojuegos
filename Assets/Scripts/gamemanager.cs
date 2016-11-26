using UnityEngine;
using System.Collections;

public class gamemanager : MonoBehaviour {

	public static GameObject player;
	public static float speed;
	public int health;
	public static int stamina;
	public static int bulletdmg;
	//public int enemyhealth;
	public GameObject robotprefab;

	// Use this for initialization
	void Start () {
		speed = 10f;
		health = 100;
		stamina = 100;
		bulletdmg = 30;
		//enemyhealth = 100f;
	}
}
