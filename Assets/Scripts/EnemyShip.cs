using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public int health=1;
	public GameObject laser;
	public float firingRate = 2.0f;
	public float shotsPerSecond = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float prob = shotsPerSecond * Time.deltaTime;
		if(Random.value < prob){
			ShootLaser ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.GetComponent<Projectile> ()) {
			health -= col.gameObject.GetComponent<Projectile> ().damage;
			if (health <= 0) {
				Destroy (gameObject);
			}
			Destroy (col.gameObject);
		}

	}

	void ShootLaser(){
		Instantiate (laser, transform.position, Quaternion.identity);
	}
		
}
