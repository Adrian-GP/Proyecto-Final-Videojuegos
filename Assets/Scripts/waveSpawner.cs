// Script based on the one created by Youtube "Brackeys" channel:
// https://www.youtube.com/watch?annotation_id=annotation_3978674333&feature=iv&src_vid=Vrld13ypX_I&v=q0SBfDFn2Bs

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class waveSpawner : MonoBehaviour {

	// Enumeration type created for handling the spawn states.
	public enum SpawnState {Spawning, Waiting, Counting};

	// Instruction to make a public object of the wave class visible in the inspector.
	[System.Serializable]
	public class wave
	{
		public int iNumberOfEnemies;
		public float fSpawnDelay;
		public int[] iArrEnemies;
	}

	// Array that stores information about each wave of enemies.
	public wave waves;

	// Array that stores the gameobjects of all enemies in the level/game.
	public GameObject[] arrGObjEnemies;
public GameObject[] xpositions;
	public float fTimeBetweenWaves = 5f;
	public Text TXT;
	private float fTimeToBeginWave;
	private int iNextWave;
	private float fSearchCountdown = 2f;
	private SpawnState spawnState = SpawnState.Counting;

	// Function that is called for initializing values.
	void Start () 
	{
		fTimeToBeginWave = fTimeBetweenWaves;
		iNextWave = 1;
		TXT.text = iNextWave.ToString();
	}
	
	// Function that is called once per frame.
	void Update () 
	{
		Debug.Log(SceneManager.GetActiveScene().ToString());
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
				StartCoroutine(SpawnWave(waves));
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

		iNextWave++;

		TXT.text = iNextWave.ToString();



		if((iNextWave%2 == 0 )&& (Application.loadedLevelName == "map1"))
		{
			SceneManager.LoadScene("map2");
		}
		else if((iNextWave%2 == 0 )&& (Application.loadedLevelName == "map2"))
		{
			SceneManager.LoadScene("map3");
		}
		else if((iNextWave%2 == 0 )&& (Application.loadedLevelName == "map3"))
		{
			SceneManager.LoadScene("map1");
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
		for (int iX = 0; iX < _wave.iNumberOfEnemies*iNextWave; iX++)
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
		Instantiate(arrGObjEnemies[iEnemy], xpositions[Random.Range(0,4)].transform.position, transform.rotation);
	}
}