using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : MonoBehaviour {

	// Components
	private Rigidbody myRigidbody;

	private GameObject curTarget;
	private GameObject curItem, lastItem;


	// Use this for initialization
	void Start () {
		myRigidbody = gameObject.GetComponent<Rigidbody> ();
		curTarget = FindNewTarget ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Select a Berry to Pursue
		// Move toward berry
		// If hungry, eat
		// If not hungry, carry to stockpile.
		if (curTarget != null) {
			if (Vector3.Distance (myRigidbody.position, curTarget.transform.position) > 0.01f) {
				Vector3 curPos = myRigidbody.position;
				curPos = Vector3.MoveTowards (curPos, curTarget.transform.position, 0.1f);
				Vector3 reposition = new Vector3 (curPos.x, curPos.y, curPos.z);
				myRigidbody.MovePosition (reposition);
			}
		}
		if (curItem != null) {
			curItem.GetComponent<Rigidbody> ().isKinematic = true;
			Vector3 curPosi = new Vector3 (myRigidbody.position.x, myRigidbody.position.y + 1.0f, myRigidbody.position.z);
			curItem.GetComponent<Rigidbody> ().MovePosition (curPosi);
		}
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log(col.gameObject.ToString());
		if (col.gameObject.tag == "Food") {
			if (col.gameObject.GetComponent<Berry> ().isStockpiled == false) {
				curItem = curTarget;
				curTarget = GameObject.FindGameObjectWithTag ("Stockpile");
			}
		}
	}

	GameObject FindNewTarget() {
		GameObject newTarget = null;
		GameObject[] taggedItems = GameObject.FindGameObjectsWithTag ("Food");
		foreach (GameObject obj in taggedItems) {
			if (lastItem != obj && obj.GetComponent<Berry>().isStockpiled == false) {
				if (newTarget == null) {
					newTarget = obj;
				} else if (Vector3.Distance (obj.transform.position, myRigidbody.position) <
				   Vector3.Distance (newTarget.transform.position, myRigidbody.position)) {
					newTarget = obj;
				}
			}
		}

		return newTarget;
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Stockpile") {
			if (curItem != null) {
				curItem.GetComponent<Rigidbody> ().isKinematic = false;
				curItem.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				curItem.GetComponent<Rigidbody> ().MovePosition (col.transform.position);
				lastItem = curItem;
				curItem = null;
				curTarget = FindNewTarget ();
			}
		}	
	}

}
