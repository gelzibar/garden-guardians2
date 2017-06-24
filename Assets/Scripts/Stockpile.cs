using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stockpile : MonoBehaviour {
//	GameObject[] inventory;
	int inventory;

	// Use this for initialization
	void Start () {
//		inventory = new GameObject[10];
		inventory = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Food") {
			inventory++;
			Destroy (col.gameObject);
		}	
	}
}
