using UnityEngine;
using System.Collections;

public class EnemyActions : MonoBehaviour {

	public float width = 10.0f;
	public float height = 10.0f;

	public float enemy_speed = 5.0f;

	float xmin;
	float xmax;
	// Use this for initialization
	void Start () {
		// TODO LOOOOOOOOOOOK AT THIS STUFF
		// vector 3 argument of viewport in this case takes values from 0 to 1    for x and y
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMostPos=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMostPos=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMostPos.x;
		xmax = rightMostPos.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= xmin || transform.position.x >= xmax) {
			enemy_speed = -enemy_speed;
			transform.position += Vector3.left * enemy_speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * enemy_speed * Time.deltaTime;
		}

		if (AllEnemiesDead()) {
			respawnStronger ();
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}

	bool AllEnemiesDead(){
		foreach (Transform child in transform) {
			if (child.transform.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void respawnStronger(){
		gameObject.GetComponent<EnemySpawner> ().createUpgradedEnemy ();
	}


}
