using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class UpdateUI : MonoBehaviour {
	public Text writeHpValue;
	public Text writeEnergyValue;
	public Text writeShellValue;
	public Text writeCoinValue;
	public Text writeBossHpValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		writeHpValue.text = "Hp [" + Player.hp.ToString() + "/" + Player.Maxhp.ToString() + "]";
		writeEnergyValue.text = "Energy ["+Player.energy.ToString()+"/"+Player.MaxEnergy.ToString()+"]";
		writeShellValue.text = "Shell ["+Player.shell.ToString()+"/"+Player.MaxShell.ToString()+"]";
		writeCoinValue.text = "Coin : " + Player.coins.ToString ();
		if (Global.onBossFight) {
			writeBossHpValue.text = "Boss HP [" + Global.bossHp.ToString () + "/500]";
		} else {
			writeBossHpValue.text = "";
		}
	}
}
