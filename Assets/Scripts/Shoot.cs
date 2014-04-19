using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Rigidbody2D bullet;
	public float shootingForce = 75f;

	private const float MAX_TIME = 0.1f;
	private float currentTime;
	private bool canShoot = false;

	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime > MAX_TIME) {
			canShoot = true;
			currentTime = 0f;
		}

		if (canShoot && Input.GetKey(KeyCode.Slash)) {
			Rigidbody2D newBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;

			/*float x = 0, y = 0;
			if (PlayerController.lrDir == PlayerController.PlayerDirectionLR.Left) {
				x = -1;
			} else if (PlayerController.lrDir == PlayerController.PlayerDirectionLR.Right) {
				x = 1;
			}

			if (PlayerController.udDir == PlayerController.PlayerDirectionUD.Up) {
				y = 1;
			} else if (PlayerController.udDir == PlayerController.PlayerDirectionUD.Down) {
				y = -1;
			}
*/
			newBullet.rigidbody2D.AddForce(new Vector2(shootingForce * PlayerController.playerDirection.x, shootingForce * PlayerController.playerDirection.y));

			canShoot = false;
		}
	}
}
