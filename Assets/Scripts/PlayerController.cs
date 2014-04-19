using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public enum PlayerDirectionLR {
		Left,
		Right,
		None
	};
	public static PlayerDirectionLR lrDir;

	public enum PlayerDirectionUD {
		Up,
		Down,
		None
	};
	public static PlayerDirectionUD udDir;

	private float speed = 2500f;
	private float health = 100f;

	// Use this for initialization
	void Start () {
		lrDir = PlayerDirectionLR.None;
		udDir = PlayerDirectionUD.None;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy(gameObject);
			Application.LoadLevel("GameOver");
		}

		float dx = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		float dy = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;

		if (dx > 0) {
			lrDir = PlayerDirectionLR.Right;
		} else if (dx < 0) {
			lrDir = PlayerDirectionLR.Left;
		} else {
			if (udDir != PlayerDirectionUD.None) {
				lrDir = PlayerDirectionLR.None;
			}
		}

		if (dy > 0) {
			udDir = PlayerDirectionUD.Up;
		} else if (dy < 0) {
			udDir = PlayerDirectionUD.Down;
		} else {
			if (lrDir != PlayerDirectionLR.None) {
				udDir = PlayerDirectionUD.None;
			}
		}

		rigidbody2D.AddForce (new Vector2 (dx, dy));
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Enemy") {
			EnemyController enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
			health -= enemy.damage;
		}
	}

}
