using UnityEngine;
using System.Collections;

public class Projectile_Enemy : MonoBehaviour {

	public float laser_speed = 10.0f;
	public int damage=1;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Rigidbody2D>().velocity = Vector3.down * laser_speed;
	}

	void OnCollisionEnter2D(){
		Destroy (gameObject);
	}
}
