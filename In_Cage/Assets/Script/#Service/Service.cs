using System.Collections;
using System.Collections.Generic;
using System;
using Data;

namespace Service{
	public class Generate{
		private static Random rand = new Random ();
		public static int randint(int min,int max){
			return rand.Next (min, max + 1);
		}
		public static float randfloat(int n,float min,float max){
			if (n <= 0) {
				throw new ArgumentException ("Error in function <Service.Generate.randfloat>: variable 'n' must be a positive integer !");
			}
			float randValue = (float)(rand.NextDouble () * (max - min) + min);
			return (float)Math.Round (randValue, n);
		}
	}
	public class GetMin{
		public static int Int(params int[] values){
			if (values.Length == 0) {
				throw new ArgumentException ("Error in function <Service.GetMin.Int>: you need to provide at least one integer");
			}
			int min = values [0]; // Assume the first integer is the minimum integer
			for (int i = 1; i < values.Length; i++) {
				//use <for> to compire each value in array
				if(values[i] < min){
					min = values[i];//update
				}
			}
			return min;
		}
		public static float Float(params float[] values){
			if (values.Length == 0) {
				throw new ArgumentException ("Error in function <Service.GetMin.Float>: you need to provide at least one float number");
			}
			float min = values [0]; // Assume the first integer is the maximum float number
			for (int i = 1; i < values.Length; i++) {
				//use <for> to compire each value in array
				if(values[i] < min){
					min = values[i];//update
				}
			}
			return min;
		}
	}
	public class GetMax{
		public static int Int(params int[] values){
			if (values.Length == 0) {
				throw new ArgumentException ("Error in function <Service.GetMax.Int>: you need to provide at least one integer");
			}
			int max = values [0]; // Assume the first integer is the maximum integer
			for (int i = 1; i < values.Length; i++) {
				//use <for> to compire each value in array
				if(values[i] > max){
					max = values[i];//update
				}
			}
			return max;
		}
		public static float Float(params float[] values){
			if (values.Length == 0) {
				throw new ArgumentException ("Error in function <Service.GetMax.Float>: you need to provide at least one float number");
			}
			float max = values [0]; // Assume the first integer is the maximum float number
			for (int i = 1; i < values.Length; i++) {
				//use <for> to compire each value in array
				if(values[i] > max){
					max = values[i];//update
				}
			}
			return max;
		}
	}
	public class TakeDamage{
		public static void p(int dmg){
			if (dmg < 0) {
				throw new ArgumentException ("Error in function <Service.TakeDamage.p>: variable 'dmg' must be a positive integer !");
			}
			if (dmg > Player.shell) {
				int doDmgInHp = dmg - Player.shell;
				Player.hp -= doDmgInHp;
				Player.shell = 0;
			} else {
				Player.shell -= dmg;
			}
			Global.lastAttackedTime = UnityEngine.Time.time;
		}
	}
}