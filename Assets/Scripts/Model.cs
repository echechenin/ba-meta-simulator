using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Model {

	public static Hero selectedHero;
	public static Item selectedItem;
	public static string selectedSlot;

	public static int[] healthList = {1000,1038,1038,1038,1077,1077,1077,1115,1115,1115,1154,1154,1154,1192,1192,1192,1231,1231,1231,1269,
							   1269,1269,1308,1308,1308,1346,1346,1346,1385,1385,1385,1423,1423,1423,1462,1462,1462,1500,1500,1500};
	public static int[] strengthList = {600, 600, 623, 623, 623, 646, 646, 646, 669, 669, 669, 692, 692, 692, 715, 715, 715, 738, 738, 738,
								 762, 762, 762, 785, 785, 785, 808, 808, 808, 831, 831, 831, 854, 854, 854, 877, 877, 877, 900, 900};
	public static int[] defenseList = {600, 600, 600, 623, 623, 623, 646, 646, 646, 669, 669, 669, 692, 692, 692, 715, 715, 715, 738, 738, 
								738, 762, 762, 762, 785, 785, 785, 808, 808, 808, 831, 831, 831, 854, 854, 854, 877, 877, 877, 900};	
	public static int[] penetrationList = {600, 600, 623, 623, 623, 646, 646, 646, 669, 669, 669, 692, 692, 692, 715, 715, 715, 738, 738, 738,
									762, 762, 762, 785, 785, 785, 808, 808, 808, 831, 831, 831, 854, 854, 854, 877, 877, 877, 900, 900};
	public static List<ItemDefinition> itemsDefs = new List<ItemDefinition>();

	public static int[] heroLevelUpCostFragm = {1, 2, 4, 6, 8, 10, 12, 14, 16, 20, 25, 30, 35, 40, 45, 50, 55, 60, 70, 80, 90, 100, 110, 120, 130, 140, 
											150, 160, 175, 200, 225, 250, 275, 300, 325, 350, 375, 400, 450};
	public static int[] heroLevelUpCostSoft = {100,200,400,600,800,1000,1200,1400,1600,2000,2500,3000,3500,4000,4500,5000,5500,6000,7000,8000,9000,
												10000,11000,12000,13000,14000,15000,16000,17500,20000,22500,25000,27500,30000,32500,35000,37500,40000,45000};

	static Model() {
		itemsDefs.Add(new ItemDefinition("Оружие 1, тир 1", ItemType.WEAPON, 40,new int[] {},new int[]{9,18,27,36,45,54,63,72,81,90,99,108,117,126,135,144,153,162,171,180,189,198,207,216,225,234,243,252,261,270,279,288,297,306,315,324,333,342,351,360},new int[]{},new int[]{}));
	}



	public static ItemDefinition getItemDef(string name) {
		foreach (ItemDefinition item in itemsDefs) {
			if (name == item.name) {
				return item;
			}
		}
		return null;
	}
}