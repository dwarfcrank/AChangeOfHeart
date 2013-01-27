using UnityEngine;
using System.Collections;

public class grannySpawn : MonoBehaviour {
	
	public Transform prefab;
	Vector3 spawnPoint;
	int spawnPlace;
	float spawnTime;
	int spawned = 0;
	//public float spawnWait = 3.0f;
	public float spawnDelay = 1.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Spawn() {
		yield return new WaitForSeconds(spawnDelay);
		do {			
			spawnPlace = Random.Range(1,4);
			spawnPoint = transform.position;
			Debug.Log (spawnPlace);
				if (spawnPlace == 1) {
				spawnPoint.y = 0.9f; // Lane 1
			}
			else if (spawnPlace == 2) {
				spawnPoint.y = -0.3f; // Lane 2
			}
			else {
				spawnPoint.y = -1.45f; // Lane 3
			}
			
			Instantiate(prefab, spawnPoint, Quaternion.Euler(90, 180, 0));
			yield return new WaitForSeconds((Random.Range(1, 5)));
			spawned++;
		} while (!deathCollision.gameOver);
	}
}
