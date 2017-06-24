using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour {

	float maxTime, curTime;
	public GameObject fruit;
	// Use this for initialization
	void Start () {
		maxTime = 5.0f;
		curTime = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (curTime > maxTime) {
			curTime = 0.0f;
			float xOffset = Random.Range (-1.0f, 1.0f);
			float zOffset = Random.Range (-1.0f, 1.0f);
			Vector3 spawnPos = new Vector3 (transform.position.x + xOffset, transform.position.y + 0.5f, transform.position.z + zOffset);
			Instantiate (fruit, spawnPos, transform.rotation, GameObject.Find("Items").transform);
		} else {
			curTime += Time.deltaTime;
		}
		
	}
}