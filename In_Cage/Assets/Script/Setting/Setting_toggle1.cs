using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class Setting_toggle1 : MonoBehaviour {
	public Toggle settingToggle1;

	// Use this for initialization
	void Start () {
		settingToggle1.onValueChanged.AddListener (onToggleValueChanged);
		settingToggle1.isOn = Global.usingJoystick;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Call when toggle's state is changed
	private void onToggleValueChanged(bool isOn){
		Global.usingJoystick = isOn;
		if (Global.usingJoystick) {
			Debug.Log ("Setting : enable virtual joystick");
		} else {
			Debug.Log ("Setting : disable virtual joystick");
		}
	}
}
