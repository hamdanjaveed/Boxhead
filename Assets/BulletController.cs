using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	void Start() {
		Physics2D.IgnoreLayerCollision (9, 10);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Wall") {
			Destroy (gameObject);
		}
	}

}
