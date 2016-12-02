using UnityEngine;
using System.Collections;

public class gamemanager : MonoBehaviour {

	public static GameObject player;
	public static float speed;
	public int health;
	public static int stamina;

	void Start () {
		speed = 10f;
		health = 100;
		stamina = 100;
	}
}
