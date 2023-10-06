using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Close_2Behavior : MonoBehaviour {
	private float creatTime;
	private float smoothSpeed = 5f;

	// Use this for initialization
	void Start () {
		creatTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - creatTime > 1.0f) {
			Destroy (gameObject);
		}
		GameObject target = GameObject.FindGameObjectWithTag ("Player");
		Vector3 desiredPosition = target.transform.position;

		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
