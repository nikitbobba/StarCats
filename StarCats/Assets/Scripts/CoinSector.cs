﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSector : MonoBehaviour {

	private float speed = 0.025f;

	private Vector3 direction;
	private float distance;
	
	public GameObject whiteParticleGO;

	// Use this for initialization
	void Start () {
		direction = new Vector3(transform.position.x, transform.position.y + 11f, 0f);
		distance = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y + 11f, 2));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position -= direction / distance * speed;

		if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y + 11f, 2)) < 8f)
		{
			Destroy(gameObject);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.CompareTag("Player"))
		{
			playParticle();
			Destroy(gameObject);
			ScoreManager.AddScore(10);
	
		}

		
		
	}
	
	void playParticle()
	{
		GameObject explosion = (GameObject) Instantiate(whiteParticleGO);
		explosion.transform.position = transform.position;
	}
}
