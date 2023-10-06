using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Data{
	public class Global{
		public static bool usingJoystick = false;
		public static int levelCount = 0;
		public static float lastAttackedTime = 0f;
		public static float lastSkillTime = 0f;
		public static bool onBossFight = false;
		public static int bossHp;
	}

	public class Player{
		public static int weaponType = 1;
		public static int playerWeapon1 = 1;
		public static int playerWeapon2 = 0;
		//hp value
		public static int hp = 12;
		public static int Maxhp = 12;
		//energy value
		public static int energy = 150;
		public static int MaxEnergy = 150;
		//shell value
		public static int shell = 6;
		public static int MaxShell = 6;
		//coin value
		public static int coins = 0;
		//player movespeed
		public static float MoveSpeed = 2.0f;
		//--------------------------------
		public static float recoveryTime = 5.0f;
		//public static float recoveryBreakTime = 1.0f;
		//bullet speed
		public static float bulletSpeed = 10.0f;
		//--------------------------------
		public static int skillType = 1;

		//=====================================================================
		//init : read all values from json file
		public static void InitSet(){
			string jsonFile = File.ReadAllText (Path.Combine(Application.streamingAssetsPath, "player.json"));
			JObject jobj = JObject.Parse (jsonFile);
			hp = Maxhp = (int)jobj ["Maxhp"];
			energy = MaxEnergy = (int)jobj ["MaxEnergy"];
			shell = MaxShell = (int)jobj["shell_0"];
			MoveSpeed = (float)jobj ["movespeed"];
			recoveryTime = (float)jobj ["recoveryTime"];
			//recoveryBreakTime = (float)jobj ["recoveryBreakTime"];
			bulletSpeed = (float)jobj ["bulletSpeed"];
		}
	}

	public class Damage{
		public static int u_bullet_small = 1;
		public static int u_bullet_middle = 3;
		public static int u_bullet_large = 5;
		public static int u_close_1 = 5;
		public static int u_close_2 = 1;
		public static int e_bullet_small = 1;
		public static int e_bullet_large = 4;
		public static int e_close = 1;

		//======================================================================
		//init : read all values from json file
		public static void InitSet(){
			string jsonFile = File.ReadAllText (Path.Combine(Application.streamingAssetsPath,"attackDamage.json"));
			JObject jobj = JObject.Parse (jsonFile);
			u_bullet_small = (int)jobj ["u_bullet_small"];
			u_bullet_middle = (int)jobj ["u_bullet_middle"];
			u_bullet_large = (int)jobj ["u_bullet_large"];
			u_close_1 = (int)jobj ["u_close_1"];
			u_close_2 = (int)jobj ["u_close_2"];
			e_bullet_small = (int)jobj ["e_bullet_small"];
			e_bullet_large = (int)jobj ["e_bullet_large"];
			e_close = (int)jobj ["e_close"];
		}
	}

	public enum AllWeaponType{
		noWeapon = 0,
		Weapon1,//gun 1<Single shot pistol>
		Weapon2,//gun 2<shotgun>
		Weapon3,//gun 3<Accumulator weapon>
		Weapon4,//gun 4<Revolver>
		Weapon5//knife<melee>
	};
}
