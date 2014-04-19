﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float damage = 20f;

	private GameObject player;
	private float speedDamp = 0.25f;

	private float health = 100;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		Physics2D.IgnoreLayerCollision (11, 12);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPosition = player.transform.position;
		Vector3 direction = playerPosition - transform.position;
		rigidbody2D.velocity = new Vector2 (direction.x * speedDamp, direction.y * speedDamp);

		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Bullet") {
			BulletController bullet = collision.gameObject.GetComponent<BulletController>();
			health -= bullet.damage;
		}
	}
}