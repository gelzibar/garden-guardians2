using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour {

	public bool isStockpiled;

	// Use this for initialization
	void Start () {
		isStockpiled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Stockpile") {
			isStockpiled = true;
		}	
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Stockpile") {
			isStockpiled = false;
		}	
	}

}
