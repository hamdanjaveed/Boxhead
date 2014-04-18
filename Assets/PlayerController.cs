using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform bullet;

	private float speed = 2500f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dx = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		float dy = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;

		rigidbody2D.AddForce (new Vector2 (dx, dy));

		if (Input.GetKey(KeyCode.Slash)) {
			Instantiate(bullet, transform.position, Quaternion.identity);
		}
	}

}
