using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public int health=1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
