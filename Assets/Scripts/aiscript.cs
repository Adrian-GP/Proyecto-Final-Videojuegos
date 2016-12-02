using UnityEngine;
using System.Collections;

public class aiscript : MonoBehaviour {

	NavMeshAgent agent;

	// Function used to initialize values.
	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	// Function that is called once per frame.
	void Update () 
	{
		agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
	}

}