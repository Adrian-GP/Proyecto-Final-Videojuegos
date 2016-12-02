using UnityEngine;
using System.Collections;

public class aiscript : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent agent;

	// Function used to initialize values.
	void Start () 
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	// Function that is called once per frame.
	void Update () 
	{
		agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
	}

}