using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefab;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			int index = Random.Range (0, enemyPrefab.Length);
			var enemy=Instantiate (enemyPrefab[index], child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
