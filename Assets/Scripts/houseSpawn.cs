using UnityEngine;
using System.Collections;

public class houseSpawn : MonoBehaviour {
	
	public Transform prefab1;
	public Transform prefab2;
	public Transform prefab3;
	public Transform prefab4;
	Transform prefab;
	Vector3 spawnPoint;
	float spawnTime;
	public static int spawned = 0;
	int i = 1;
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
			if (i == 1) {
				prefab = prefab1;
			}
			else if (i == 2) {
				prefab = prefab2;
			}
			else if (i == 3) {
				prefab = prefab3;
			}
			else if (i == 4) {
				prefab = prefab4;
			}
			spawnPoint = transform.position;
			Instantiate(prefab, spawnPoint, Quaternion.Euler(90, 180, 0));
			yield return new WaitForSeconds(1);
			if (i < 4) {
				i++;
			} else {
				i= 1;
			};
			
		} while (!deathCollision.gameOver);
		
	}
}
