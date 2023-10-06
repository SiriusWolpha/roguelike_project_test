using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Service;
using Data;

public class DoorBehavior : MonoBehaviour {
	public Sprite idle;
	public Sprite hover;
	private SpriteRenderer self;
	//public string nextScene;

	private bool isOn = false;

	// Use this for initialization
	void Start () {
		bool isOn = false;
		self = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {
			self.sprite = hover;
			gotoNext ();
		} else {
			self.sprite = idle;
		}
		hasEnemy ();
	}

	void hasEnemy(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		if (enemies.Length == 0) {
			isOn = true;
		}
	}

	void gotoNext(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player) {
			float distance = Vector2.Distance (transform.position, player.transform.position);
			if (distance < 1f) {
				Global.levelCount += 1;
				if (Global.levelCount == 4 || Global.levelCount == 7) {
					SceneManager.LoadScene (4);
				} else if (Global.levelCount == 8) {
					SceneManager.LoadScene (5);
				}else if(Global.levelCount == 9){
					SceneManager.LoadScene ("After");
				} else {
					int toLoad = Generate.randint (7, 15);
					SceneManager.LoadScene (toLoad);
				}
			}
		}
	}
}
