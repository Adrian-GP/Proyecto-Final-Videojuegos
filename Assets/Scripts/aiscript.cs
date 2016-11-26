﻿using UnityEngine;
using System.Collections;

public class aiscript : MonoBehaviour {

	NavMeshAgent agent;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
	}


	void Update () 
	{
		agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
	}

}