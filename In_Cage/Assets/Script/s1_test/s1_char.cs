using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1_char : MonoBehaviour {
	public float MoveSpeed = 2f;
	public float RotateSpeed = 1f;


	void Start () {

	}

	void Update () {
		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
		{
			Debug.Log("forward");
			this.transform.Translate(Vector3.up*MoveSpeed*Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			Debug.Log("back");
			this.transform.Translate(Vector3.down* MoveSpeed*Time.deltaTime);
		}
			
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			Debug.Log("left");
			this.transform.Translate(Vector3.left*MoveSpeed*Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			Debug.Log("right");
			this.transform.Translate(Vector3.right*MoveSpeed*Time.deltaTime);
		}

	}
}
