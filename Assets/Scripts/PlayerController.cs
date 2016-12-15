using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed=10.0f;
	public float firingRate = 0.2f;
	public int health = 5;
	public GameObject laser;

	float xmin;
	float xmax;
	// Use this for initialization
	void Start () {
		// vector 3 in this case takes values from 0-1 for x and y
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMostPos=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMostPos=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMostPos.x;
		xmax = rightMostPos.x;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		float newX = Mathf.Clamp(transform.position.x,xmin,xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("ShootLaser", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("ShootLaser");
		}
	}

	void ShootLaser(){
		Instantiate (laser, transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.GetComponent<Projectile_Enemy> ()) {
			health -= col.gameObject.GetComponent<Projectile_Enemy> ().damage;
			if (health <= 0) {
				Destroy (gameObject);
			}
			Destroy (col.gameObject);
		}

	}
}
