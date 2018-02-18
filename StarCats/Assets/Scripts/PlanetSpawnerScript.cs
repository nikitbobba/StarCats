﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnerScript : MonoBehaviour
{


	public GameObject planetA;
	public GameObject planetB;
	public GameObject planetC;
	public GameObject enemies;
	public GameObject FlipEnemy;
	public GameObject SlowDownEnemy;
	public float randX;
	Vector2 whereToSpawn;
	public float spawnRate = 0.5f;
	float nextSpawn = 0.0f;
	private GameObject[] toSpawn;
	private int toSpawnIndex;
	
	
    
	// Use this for initialization
	void Start () {
		WhatToSpawn();
		toSpawnIndex = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.fixedTime > nextSpawn)
		{
			//element spawns
			nextSpawn = Time.fixedTime + spawnRate;
			randX = Random.Range(-8.4f, 8.4f);
			whereToSpawn = new Vector2(randX,transform.position.y);

//			int choice = Random.Range(0, 8);
//			GameObject[] planetOptions = new GameObject[] {planetA,planetA, enemies, planetB, planetC, enemies, enemies, planetB};
			Instantiate(toSpawn[toSpawnIndex++], whereToSpawn, Quaternion.identity);
			
			
		}
		
	}
	// first level has 90 seconds, there will be 180 objects. 1 enemy every 5 seconds (18 enemies), 2 flip enemies, 2 slow down enemies.
	void WhatToSpawn()
	{
		toSpawn = new GameObject[180];
		int choice = 0;
		for (int i = 1; i < 4; i++)
		{
			switch (i)
			{
				case 1:
					choice = Random.Range(0, 90);
					toSpawn[choice] = FlipEnemy;
					break;
				
				case 2:
					choice = Random.Range(0, 90);
					toSpawn[choice] = SlowDownEnemy;
					break;
					
				case 3:
					choice = Random.Range(90, 180);
					toSpawn[choice] = FlipEnemy;
					break;
				
				case 4:
					choice = Random.Range(90, 180);
					toSpawn[choice] = SlowDownEnemy;
					break;
					
			}
		}

		int j = 0;
		while (j < 14)
		{
			choice = Random.Range(0, 180);
			if (toSpawn[choice] == null)
			{
				toSpawn[choice] = enemies;
				j++;
			}
		}

		for (int i = 0; i < 180; i++)
		{
			if (toSpawn[i] == null)
			{
				int innerChoice = Random.Range(0, 3);
				GameObject[] planetOptions = new GameObject[] {planetA, planetB, planetC};
				toSpawn[i] = planetOptions[innerChoice];
			}
		}
		
	}
}
