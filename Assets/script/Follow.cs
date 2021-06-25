using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform tr;
	
	// Update is called once per frame
	void Update () {
		Vector3 v = transform.position;
		v.x = tr.position.x;
		transform.position = v;
	}
}
