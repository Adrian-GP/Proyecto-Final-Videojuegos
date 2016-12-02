using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// Public attributes.
	public int iHealth;
	public int iStrength;
	public float fInvTime;
	public AudioSource audioHurt;

	private bool bCanInflictDamage;

	void Start(){
		/*enemyaudio = (AudioSource)gameObject.AddComponent<AudioSource>();
		AudioClip enemyclip;
		enemyclip= (AudioClip)Resources.Load("90164__snaginneb__gruntsound");
		enemyaudio.clip = enemyclip;
		enemyaudio.volume = 1f;*/
		bCanInflictDamage = true;
	}

	// Function that is called whenever the object that contains this script (an enemy)
	// collides with another object.
	void OnCollisionStay(Collision col)
	{
		// If the enemy collides with the player and is able to inflict damage...
		// then inflict damage.
		if (col.gameObject.tag == "Player" && bCanInflictDamage)
			StartCoroutine (inflictDamage ());
	}

	// Function to deal damage to the enemy.
	// iQuantity is the amount of damage that the enemy will receive.
	public void damage(int iQuantity)
	{
		iHealth -= iQuantity;
		if(audioHurt != null)
			audioHurt.Play ();

		// If the health of the enemy is 0 or less, destroy it.
		if (iHealth <= 0)
			Destroy (this.gameObject);
	}

	// Function to inflict damage to the player.
	public IEnumerator inflictDamage()
	{
		bCanInflictDamage = false;
		gameController.iCurrentHealth -= iStrength;
		yield return new WaitForSeconds (fInvTime);
		bCanInflictDamage = true;
	}
}
