using UnityEngine;
using System.Collections;

public class grannySpawn : MonoBehaviour {
	
	public Transform prefab;
	Vector3 spawnPoint;
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
			spawnPoint = transform.position;
			Instantiate(prefab, spawnPoint, Quaternion.Euler(90, 180, 0));
			yield return new WaitForSeconds((Random.Range(1, 5)));
			spawned++;
		} while (spawned < 10);
	}
}