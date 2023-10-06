using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Data;
using Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class PlayerBehavior : MonoBehaviour {
	//----read player's move speed------------
	private float MoveSpeed = Player.MoveSpeed;
	//----add player's avatar here------------
	public Sprite noWeaponAvatar;
	public Sprite withWeaponAvatar1;
	public Sprite withWeaponAvatar2;
	public Sprite withWeaponAvatar3;
	public Sprite withWeaponAvatar4;
	public Sprite withWeaponAvatar5;
	//----------------------------------------
	private SpriteRenderer sr;
	//----add attack prefab here--------------
	public GameObject w0;
	public GameObject w1;
	public GameObject w2;
	public GameObject w3;
	public GameObject w4;
	//----add weapon prefab here--------------
	public GameObject g1P;
	public GameObject g2P;
	public GameObject g3P;
	public GameObject g4P;
	public GameObject kfP;
	//----JObjects for all weapons' and skills' setting
	private JObject gun1;
	private JObject gun2;
	private JObject gun3;
	private JObject gun4;
	private JObject knife;

	private JObject skill1;
	private JObject skill2;
	private JObject skill3;
	//----------------------------------------
	private float nextFireTime;
	private float nextSkillTime;
	private float skillEndTime;
	private int attackType;
	private int count;
	private float OMoveSpeed;
	private GameObject toPickUp;
	private int toPickUpID = 0;
	//----------------------------------------

	// Use this for initialization
	void Start () {
		/*
		joystick = GameObject.FindGameObjectWithTag ("Joystick");
		//-----if disabled, destroy virtual joystick here-----------------
		if (!Global.usingJoystick) {
			Destroy (joystick);
		} else {
			joystickTransform = joystick.transform;
			initialPosition = joystickTransform.position;
		}*/
		//----get sprite renderer here--------------------------------
		sr = GetComponent<SpriteRenderer>();
		loadJson ();
		nextFireTime = Time.time;
		nextSkillTime = Time.time;
		skillEndTime = Time.time;
		OMoveSpeed = Player.MoveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		//------check hp-------------------------------------------------------
		if (Player.hp <= 0) {
			SceneManager.LoadScene ("GameOver");
		}
		//------process input event--------------------------------------------
		if (Global.usingJoystick == false) {
			//keybind for no keyboard input mode
			//-----------------------------------------------------------------
			if (Input.GetKey (KeyCode.UpArrow)) {
				//Debug.Log("forward");
				this.transform.Translate (Vector3.up * MoveSpeed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				//Debug.Log("back");
				this.transform.Translate (Vector3.down * MoveSpeed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				//Debug.Log("left");
				this.transform.Translate (Vector3.left * MoveSpeed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				//Debug.Log("right");
				this.transform.Translate (Vector3.right * MoveSpeed * Time.deltaTime);
			}
			//------------------------------------------------------------------
			ToPickUp ();
			//------------------------------------------------------------------
			if (toPickUpID == 0) {
				if (Player.weaponType == 2 || Player.weaponType == 5) {
					if (Input.GetKey (KeyCode.A) && Time.time >= nextFireTime) {
						/*
						if (Player.weaponType == 1) {
							nextFireTime = Time.time + (float)gun1 ["intervalTime"];
							switch ((string)gun1 ["bulletType"]) {
							case "small":
								attackType = 1;
								break;
							case "middle":
								attackType = 2;
								break;
							case "large":
								attackType = 3;
								break;
							}
							if (Player.energy >= (int)gun1 ["energyCost"]) {
								Player.energy -= (int)gun1 ["energyCost"];
								attack ();
							}
						}
						*/
						if (Player.weaponType == 2) {
							nextFireTime = Time.time + (float)gun2 ["intervalTime"];
							switch ((string)gun2 ["bulletType"]) {
							case "small":
								attackType = 1;
								break;
							case "middle":
								attackType = 2;
								break;
							case "large":
								attackType = 3;
								break;
							}
							if (Player.energy >= (int)gun2 ["energyCost"]) {
								Player.energy -= (int)gun2 ["energyCost"];
								attack ();
							}
						}
						/*
						if (Player.weaponType == 4) {
							nextFireTime = Time.time + (float)gun4 ["intervalTime"];
							switch ((string)gun4 ["bulletType"]) {
							case "small":
								attackType = 1;
								break;
							case "middle":
								attackType = 2;
								break;
							case "large":
								attackType = 3;
								break;
							}
							if (Player.energy >= (int)gun4 ["energyCost"]) {
								Player.energy -= (int)gun4 ["energyCost"];
								attack ();
							}
						}
						*/
						if (Player.weaponType == 5) {
							nextFireTime = Time.time + (float)knife ["intervalTime"];
							Instantiate (w4, gameObject.transform.position, gameObject.transform.rotation);
						}
					}
				} else if (Player.weaponType == 1 || Player.weaponType == 4) {
					if (Input.GetKeyDown (KeyCode.A) && Time.time >= nextFireTime) {
						if (Player.weaponType == 1) {
							nextFireTime = Time.time + (float)gun1 ["intervalTime"];
							switch ((string)gun1 ["bulletType"]) {
							case "small":
								attackType = 1;
								break;
							case "middle":
								attackType = 2;
								break;
							case "large":
								attackType = 3;
								break;
							}
							if (Player.energy >= (int)gun1 ["energyCost"]) {
								Player.energy -= (int)gun1 ["energyCost"];
								attack ();
							}
						}
						if (Player.weaponType == 4) {
							nextFireTime = Time.time + (float)gun4 ["intervalTime"];
							switch ((string)gun4 ["bulletType"]) {
							case "small":
								attackType = 1;
								break;
							case "middle":
								attackType = 2;
								break;
							case "large":
								attackType = 3;
								break;
							}
							if (Player.energy >= (int)gun4 ["energyCost"]) {
								Player.energy -= (int)gun4 ["energyCost"];
								attack ();
							}
						}
					}
				} else {
					if (Input.GetKey (KeyCode.A)) {
						count += 1;
					}
					if (Input.GetKeyUp (KeyCode.A) && Time.time >= nextFireTime) {
						nextFireTime = Time.time + (float)gun3 ["intervalTime"];
						if (count < (int)gun3 ["count1"]) {
							attackType = 1;
						} else if (count < (int)gun3 ["count2"]) {
							attackType = 2;
						} else {
							attackType = 3;
						}
						count = 0;
						if (Player.energy >= (int)gun3 ["energyCost"]) {
							Player.energy -= (int)gun3 ["energyCost"];
							attack ();
						}
					}
				}
			} else {
				if (Input.GetKeyDown (KeyCode.A)) {
					execPickUp ();
				}
			}
			//-------------------------------------------------------------------
			//shift weapon
			if (Input.GetKeyDown (KeyCode.S)) {
				int tmp = Player.playerWeapon1;
				Player.playerWeapon1 = Player.weaponType = Player.playerWeapon2;
				Player.playerWeapon2 = tmp;
			}
			//-------------------------------------------------------------------
			//skill
			if (Input.GetKeyDown (KeyCode.D) && Time.time >= nextSkillTime) {
				if (Player.skillType == 1) {
					//Debug.Log ("skill1 start");
					//Debug.Log (Time.time);
					float readPoint = Time.time;
					nextSkillTime = readPoint + (float)skill1 ["intervalTime"];
					skillEndTime = readPoint + (float)skill1 ["skillTime"];
					//Debug.Log (skillEndTime);
					MoveSpeed = (float)skill1 ["fastSpeed"];
					//Debug.Log (Player.MoveSpeed);
				}
				if (Player.skillType == 2) {
					nextSkillTime = Time.time + (float)skill2 ["intervalTime"];
					Player.hp -= 1;
					Player.energy = GetMin.Int (Player.MaxEnergy, Player.energy + 30);
				}
				if (Player.skillType == 3) {
					nextSkillTime = Time.time + (float)skill3 ["intervalTime"];
					Player.shell = Player.MaxShell;
				}
			}
		}
		//----set avatar---------------------------------------------------------
		setPlayerAvatar();
		//----recover shell------------------------------------------------------
		recovery();
		//-----------------------------------------------------------------------
		if (Player.skillType == 1) {
			if (Time.time >= skillEndTime) {
				//Debug.Log ("skill1 end");
				//Debug.Log (Time.time);
				MoveSpeed = OMoveSpeed;
			}
		}
	}

	//----realize set avatar function--------------------------------------------
	void setPlayerAvatar(){
		switch (Player.weaponType) {
		case (int)AllWeaponType.noWeapon:
			sr.sprite = noWeaponAvatar;
			break;
		case (int)AllWeaponType.Weapon1:
			sr.sprite = withWeaponAvatar1;
			break;
		case (int)AllWeaponType.Weapon2:
			sr.sprite = withWeaponAvatar2;
			break;
		case (int)AllWeaponType.Weapon3:
			sr.sprite = withWeaponAvatar3;
			break;
		case (int)AllWeaponType.Weapon4:
			sr.sprite = withWeaponAvatar4;
			break;
		case (int)AllWeaponType.Weapon5:
			sr.sprite = withWeaponAvatar5;
			break;
		default:
			Debug.Log ("Error in <PlayerBehavior.setPlayerAvatar> : unknow value for [Player.weaponType]");
			sr.sprite = noWeaponAvatar;
			break;
		}
	}
	//----whether recovery shell--------------------------------------------
	void recovery(){
		float delta = Time.time - Global.lastAttackedTime;
		if (delta >= Player.recoveryTime) {
			Player.shell = GetMin.Int(Player.shell + 1, Player.MaxShell);
			Global.lastAttackedTime = Time.time;
		}
	}
	//----load weapons' and skills' setting json file-----------------------
	void loadJson(){
		string gun1Str = File.ReadAllText (Path.Combine(Application.streamingAssetsPath, "gun1.json"));
		string gun2Str = File.ReadAllText (Path.Combine(Application.streamingAssetsPath, "gun2.json"));
		string gun3Str = File.ReadAllText (Path.Combine(Application.streamingAssetsPath, "gun3.json"));
		string gun4Str = File.ReadAllText (Path.Combine(Application.streamingAssetsPath, "gun4.json"));
		string knifeStr = File.ReadAllText (Path.Combine(Application.streamingAssetsPath, "knife.json"));
		string skill1Str = File.ReadAllText (Path.Combine (Application.streamingAssetsPath, "skill1.json"));
		string skill2Str = File.ReadAllText (Path.Combine (Application.streamingAssetsPath, "skill2.json"));
		string skill3Str = File.ReadAllText (Path.Combine (Application.streamingAssetsPath, "skill3.json"));
		gun1 = JObject.Parse (gun1Str);
		gun2 = JObject.Parse (gun2Str);
		gun3 = JObject.Parse (gun3Str);
		gun4 = JObject.Parse (gun4Str);
		knife = JObject.Parse (knifeStr);
		skill1 = JObject.Parse (skill1Str);
		skill2 = JObject.Parse (skill2Str);
		skill3 = JObject.Parse (skill3Str);
	}
	//----attack------------------------------------------------------------
	void attack(){
		switch (attackType) {
		case 1:
			Instantiate (w0, gameObject.transform.position, gameObject.transform.rotation);
			break;
		case 2:
			Instantiate (w1, gameObject.transform.position, gameObject.transform.rotation);
			break;
		case 3:
			Instantiate (w2, gameObject.transform.position, gameObject.transform.rotation);
			break;
		}
	}
	//----take damage-------------------------------------------------------
	void OnTriggerEnter2D(Collider2D other){
		//Check : if bullet hit the wall, destroy the bullet
		if (other.CompareTag("E_Bullet_small")){
			Destroy(other.gameObject);
			TakeDamage.p (Damage.e_bullet_small);
		}
		if (other.CompareTag("E_Bullet_large")){
			Destroy(other.gameObject);
			TakeDamage.p (Damage.e_bullet_large);
		}
	}
	//----prepare to pick up weapon-----------------------------------------
	void ToPickUp(){
		toPickUpID = 0;

		GameObject[] g1L = GameObject.FindGameObjectsWithTag ("Gun1");
		GameObject[] g2L = GameObject.FindGameObjectsWithTag ("Gun2");
		GameObject[] g3L = GameObject.FindGameObjectsWithTag ("Gun3");
		GameObject[] g4L = GameObject.FindGameObjectsWithTag ("Gun4");
		GameObject[] kfL = GameObject.FindGameObjectsWithTag ("Knife");
		float closestDistance = Mathf.Infinity;

		foreach (GameObject kfi in kfL) {
			float distance = Vector2.Distance (transform.position, kfi.transform.position);
			if (distance < 0.7f && distance < closestDistance) {
				closestDistance = distance;
				toPickUp = kfi;
				toPickUpID = 5;
			}
		}
		foreach (GameObject g1i in g1L) {
			float distance = Vector2.Distance (transform.position, g1i.transform.position);
			if (distance < 0.7f && distance < closestDistance) {
				closestDistance = distance;
				toPickUp = g1i;
				toPickUpID = 1;
			}
		}
		foreach (GameObject g2i in g2L) {
			float distance = Vector2.Distance (transform.position, g2i.transform.position);
			if (distance < 0.7f && distance < closestDistance) {
				closestDistance = distance;
				toPickUp = g2i;
				toPickUpID = 2;
			}
		}
		foreach (GameObject g3i in g3L) {
			float distance = Vector2.Distance (transform.position, g3i.transform.position);
			if (distance < 0.7f && distance < closestDistance) {
				closestDistance = distance;
				toPickUp = g3i;
				toPickUpID = 3;
			}
		}
		foreach (GameObject g4i in g1L) {
			float distance = Vector2.Distance (transform.position, g4i.transform.position);
			if (distance < 0.7f && distance < closestDistance) {
				closestDistance = distance;
				toPickUp = g4i;
				toPickUpID = 4;
			}
		}
		//Debug.Log (toPickUpID);
		if (toPickUpID == 4) {
			Debug.Log ("Gun4 selected");
		}
	}

	void execPickUp(){
		if (toPickUpID != 0) {
			if (Player.playerWeapon2 == 0) {
				Player.playerWeapon2 = toPickUpID;
				Destroy (toPickUp);
			} else {
				switch (Player.weaponType) {
				case 0:
					Player.weaponType = Player.playerWeapon1 = toPickUpID;
					Destroy (toPickUp);
					break;
				case 1:
					Player.weaponType = Player.playerWeapon1 = toPickUpID;
					Instantiate (g1P, toPickUp.transform.position, toPickUp.transform.rotation);
					Destroy (toPickUp);
					break;
				case 2:
					Player.weaponType = Player.playerWeapon1 = toPickUpID;
					Instantiate (g2P, toPickUp.transform.position, toPickUp.transform.rotation);
					Destroy (toPickUp);
					break;
				case 3:
					Player.weaponType = Player.playerWeapon1 = toPickUpID;
					Instantiate (g3P, toPickUp.transform.position, toPickUp.transform.rotation);
					Destroy (toPickUp);
					break;
				case 4:
					Player.weaponType = Player.playerWeapon1 = toPickUpID;
					Instantiate (g4P, toPickUp.transform.position, toPickUp.transform.rotation);
					Destroy (toPickUp);
					break;
				case 5:
					Player.weaponType = Player.playerWeapon1 = toPickUpID;
					Instantiate (kfP, toPickUp.transform.position, toPickUp.transform.rotation);
					Destroy (toPickUp);
					break;
				}
			}
		}

		toPickUpID = 0;
	}
}
