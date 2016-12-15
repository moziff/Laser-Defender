using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefab;

	// Use this for initialization
	void Start () {
		createEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createEnemy(){
		foreach (Transform child in transform) {
			int index = Random.Range (0, enemyPrefab.Length);
			var enemy=Instantiate (enemyPrefab[index], child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	Transform NextFreePosition(){
		foreach (Transform child in transform) {
			if (child.childCount == 0) {
				return child;
			}
		}
		return null;
	}

	public void createUpgradedEnemy(){
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			int index = Random.Range (0, enemyPrefab.Length);
			var enemy = Instantiate (enemyPrefab [index], freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
			enemy.GetComponent<EnemyShip> ().health += 1;
		} 
		if (NextFreePosition ()) {
			Invoke ("createUpgradedEnemy", 3.0f);
		}
	}
}
