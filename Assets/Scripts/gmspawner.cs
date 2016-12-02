using UnityEngine;
using System.Collections;

public class gmspawner : MonoBehaviour {

	public enum SpawnState {Spawning, Waiting, Counting};

	[System.Serializable]
	public class wave
	{
		public string waveName;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public wave[] waves;
	private int nextWave = 0;

	public float timeBetweenWaves = 5f;
	public float waveCountdown = 0;

	private float SearchCountdown = 2f;
	private SpawnState state = SpawnState.Counting;

	void Start () 
	{
		waveCountdown = timeBetweenWaves;	
	}
	
	
	void Update () 
	{
		if(state == SpawnState.Waiting)
		{
			//We check if enemies are alive
			if(!EnemyIsAlive())
			{
				//We begin a new round
				WaveCompleted();			
			}
			else
			{
				return;
			}
		}

		if(waveCountdown <= 0)
		{
			if(state != SpawnState.Spawning)
			{
				//Start the spwning
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted ()
	{
		state = SpawnState.Counting;
		waveCountdown = timeBetweenWaves;

		if(nextWave + 1 > waves.Length - 1)
		{
			nextWave = 0;
			//Aqui podemos agregar el multiplicador de dificultad
		}
		else
		{
			nextWave++;
		}
	}

	bool EnemyIsAlive()
	{
		SearchCountdown -=Time.deltaTime;

		if(SearchCountdown <= 0)
		{
			SearchCountdown = 2f;
			if(GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(wave _wave)
	{
		state = SpawnState.Spawning;
		//We begin to spawn
		for (int i = 0; i< _wave.count; i++)
		{
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds(5f);
		}

		state = SpawnState.Waiting;
		yield break;
	}

	void SpawnEnemy(Transform _enemy)
	{
		Instantiate(_enemy, transform.position, transform.rotation);
	}
}