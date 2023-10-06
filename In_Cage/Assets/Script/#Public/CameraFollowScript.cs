using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {
	private Transform target;
	public float smoothSpeed = 5f;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		if (target != null) {
			Vector3 desiredPosition = target.position + offset;

			Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
			transform.position = smoothedPosition;
		}
	}
}
