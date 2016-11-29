// Script based on the one created by Youtube "Brackeys" channel:
// https://www.youtube.com/watch?annotation_id=annotation_3978674333&feature=iv&src_vid=Vrld13ypX_I&v=q0SBfDFn2Bs

using UnityEngine;
using System.Collections;

public class waveSpawner : MonoBehaviour {

	// Enumeration type created for handling the spawn states.
	public enum SpawnState {Spawning, Waiting, Counting};

	// Instruction to make a public object of the wave class visible in the inspector.
	[System.Serializable]
	public class wave
	{
		public string sWaveName;
		public int iNumberOfEnemies;
		public float fSpawnDelay;
		public int[] iArrEnemies;
	}

	// Array that stores information about each wave of enemies.
	public wave[] waves;

	// Array that stores the gameobjects of all enemies in the level/game.
	public GameObject[] arrGObjEnemies;

	public float fTimeBetweenWaves = 5f;

	private float fTimeToBeginWave;
	private int iNextWave;
	private float fSearchCountdown = 2f;
	private SpawnState spawnState = SpawnState.Counting;

	// Function that is called for initializing values.
	void Start () 
	{
		fTimeToBeginWave = fTimeBetweenWaves;
		iNextWave = 0;
	}
	
	// Function that is called once per frame.
	void Update () 
	{
		// If all the enemies of this wave have been spawned...
		if(spawnState == SpawnState.Waiting)
		{
			// If all enemies have been defeated...
			if(!EnemyIsAlive())
			{
				// The wave has been completed and the next wave can begin.
				WaveCompleted();			
			}

			// If not, do nothing.
			else
			{
				return;
			}
		}

		// If the time to begin the next wave is 0 or less...
		if(fTimeToBeginWave <= 0)
		{
			// If we are not spawning yet...
			if(spawnState != SpawnState.Spawning)
			{
				// Start the spawning.
				StartCoroutine(SpawnWave(waves[iNextWave]));
			}
		}

		// Else, decrease the time to begin the next wave by the time spent in this frame.
		else
		{
			fTimeToBeginWave -= Time.deltaTime;
		}
	}

	// Function that is called when a wave is completed to set in motion the next wave.
	void WaveCompleted ()
	{
		// Set the spawn state to counting and the time to begin a wave to the time between waves.
		spawnState = SpawnState.Counting;
		fTimeToBeginWave = fTimeBetweenWaves;

		// If the this wave was the last one...
		if(iNextWave + 1 >= waves.Length)
		{
			// Do something here according to our needs...
			iNextWave = 0;
			//Aqui podemos agregar el multiplicador de dificultad
		}

		// Set the next wave to be spawned.
		else
		{
			iNextWave++;
		}
	}

	// Function that returns whether there is one or more enemies alive.
	bool EnemyIsAlive()
	{
		fSearchCountdown -= Time.deltaTime;

		if(fSearchCountdown <= 0)
		{
			fSearchCountdown = 2f;
			// Checks if there are still enemies in the level.
			if(GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

	// Coroutine to spawn a wave.
	// _wave is the object that contains the information about the wave to be spawned.
	IEnumerator SpawnWave(wave _wave)
	{
		// Change the spawn state to 'Spawning'.
		spawnState = SpawnState.Spawning;

		// Do a loop 'n' times, where 'n' is the number of enemies to be spawned in this wave.
		for (int iX = 0; iX < _wave.iNumberOfEnemies; iX++)
		{
			// Get the identifier of a random enemy available for this wave.
			int iRandomIndex = Random.Range (0, _wave.iArrEnemies.Length);
			int iRandomEnemy = _wave.iArrEnemies [iRandomIndex];

			// Call the function to create the random enemy.
			SpawnEnemy(iRandomEnemy);

			// Wait fSpawnDelay seconds to spawn the next enemy.
			yield return new WaitForSeconds(_wave.fSpawnDelay);
		}

		// Set the spawn state to 'Waiting'.
		spawnState = SpawnState.Waiting;
		yield break;
	}

	// Function that spawns an enemy.
	// iEnemy is the index of the enemy (in the array of enemy GameObjects) to be spawned.
	void SpawnEnemy(int iEnemy)
	{
		Instantiate(arrGObjEnemies[iEnemy], transform.position, transform.rotation);
	}
}