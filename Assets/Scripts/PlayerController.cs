using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static Vector2 playerDirection;

	private int scoreForTakingAHit = -10;

	private float speed = 3f;
	private float health = 100f;

	private HealthBar healthBar;

	void Start() {
		healthBar = GetComponentInChildren<HealthBar>();
		healthBar.Initialize(health);
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (gameObject);
			GameScore.scene = 1;
			Application.LoadLevel ("GameOver");
		}

		float dx = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		float dy = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;

		// move the player
		Vector2 oldPosition = transform.position;
		transform.position = new Vector2(oldPosition.x + dx, oldPosition.y + dy);

		// set the direction according to dx and dy (wow this really needs to be changed, but it works so k)
		if (dx > 0 && dy > 0) {
			playerDirection = new Vector2 (1f, 1f);
		} else if (dx > 0 && dy < 0) {
			playerDirection = new Vector2 (1f, -1f);
		} else if (dx < 0 && dy > 0) {
			playerDirection = new Vector2 (-1f, 1f);
		} else if (dx < 0 && dy < 0) {
			playerDirection = new Vector2 (-1f, -1f);
		} else if (dx == 0 && dy != 0) {
			if (dy > 0) {
				playerDirection = new Vector2 (0f, 1f);
			} else {
				playerDirection = new Vector2 (0f, -1f);
			}
		} else if (dy == 0 && dx != 0) {
			if (dx > 0) {
				playerDirection = new Vector2 (1f, 0f);
			} else {
				playerDirection = new Vector2 (-1f, 0f);
			}
		}

		if (dx > 0) {
			playerDirection = new Vector2(1f, 0f);
		} else if (dx < 0) {
			playerDirection = new Vector2(-1f, 0f);
		}

		if (dy > 0) {
			playerDirection += new Vector2(0f, 1f);
		} else if (dy < 0) {
			playerDirection += new Vector2(0f, -1f);
		}

		float angle = Mathf.Atan (playerDirection.y / playerDirection.x);

		if (Mathf.Abs(angle) < 0.3) {
			if (playerDirection.x > 0) {
				playerDirection = new Vector2 (1f, 0f);
			} else {
				playerDirection = new Vector2 (-1f, 0f);
			}
		} else if (Mathf.Abs(angle) > (Mathf.PI / 2f) - 0.3) {
			if (playerDirection.y > 0) {
				playerDirection = new Vector2 (0f, 1f);
			} else {
				playerDirection = new Vector2 (0f, -1f);
			}
		} else {
			if (angle > 0) {
				if (playerDirection.x > 0) {
					playerDirection = new Vector2(1f, 1f).normalized;
				} else {
					playerDirection = new Vector2(-1f, -1f).normalized;
				}
			} else {
				if (playerDirection.x > 0) {
					playerDirection = new Vector2(1f, -1f).normalized;
				} else {
					playerDirection = new Vector2(-1f, 1f).normalized;
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Enemy") {
			EnemyController enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
			health -= enemy.damage;
			healthBar.setHealth(health);
			GameScore.adjustScoreBy(scoreForTakingAHit);
		}
	}


}
