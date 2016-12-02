using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemy : MonoBehaviour {

	// Public attributes.
	public int iHealth;
	public AudioSource audioHurt;
	public RectTransform healthBarBackground;
	public RectTransform healthBar;

	void Start(){
		healthBarBackground.sizeDelta = new Vector2 (
			iHealth,
			healthBar.sizeDelta.y);
		healthBar.sizeDelta = new Vector2 (
			iHealth,
			healthBar.sizeDelta.y);
		/*enemyaudio = (AudioSource)gameObject.AddComponent<AudioSource>();
		AudioClip enemyclip;
		enemyclip= (AudioClip)Resources.Load("90164__snaginneb__gruntsound");
		enemyaudio.clip = enemyclip;
		enemyaudio.volume = 1f;
	*/}

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

		healthBar.sizeDelta = new Vector2 (
			iHealth,
			healthBar.sizeDelta.y);
	}
}
