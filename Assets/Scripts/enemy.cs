using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public int currenthp = 100;
	public GameObject en;

	AudioSource enemyaudio;

	void Start(){

		/*enemyaudio = (AudioSource)gameObject.AddComponent<AudioSource>();
		AudioClip enemyclip;
		enemyclip= (AudioClip)Resources.Load("90164__snaginneb__gruntsound");
		enemyaudio.clip = enemyclip;
		enemyaudio.volume = 1f;
	*/}


	public void Damage(int dmgamount, Collider col){

		if(col.name == "enemy(Clone)")
		{
			currenthp -= dmgamount;
			if (currenthp <= 0) 
			{
				endlife(en);
			}
			enemyaudio.Play ();
		}
	}

	private void endlife(GameObject enemytokill)
	{
		Destroy(enemytokill); 
	}

}
