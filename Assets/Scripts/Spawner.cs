﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject entity;

	[Range(0.1f, 10f)]
	public float rateOfSpawn = 1f;

	private float timer = 0f;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= rateOfSpawn) {
			Instantiate(entity, transform.position, Quaternion.identity);
			timer = 0;
		}
	}
}
