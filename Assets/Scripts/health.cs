using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

	public const int MAX_HEALTH = 100;
	public int currentHealth = MAX_HEALTH;

	public void TakeDamage(int damageAmount)
	{
		currentHealth -= damageAmount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
		}
	}

	public void Heal(int healAmount)
	{
		currentHealth += healAmount;
		if (currentHealth >= MAX_HEALTH)
		{
			currentHealth = MAX_HEALTH;
		}
	}
}
