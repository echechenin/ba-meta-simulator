using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Model {

	public static Hero selectedHero;
	public static Item selectedItem;
	public static string selectedSlot;
	public static List<ItemDefinition> itemsDefs = new List<ItemDefinition>();

	public static int[] healthList = {1000,1038,1038,1038,1077,1077,1077,1115,1115,1115,1154,1154,1154,1192,1192,1192,1231,1231,1231,1269,
							   1269,1269,1308,1308,1308,1346,1346,1346,1385,1385,1385,1423,1423,1423,1462,1462,1462,1500,1500,1500};
	public static int[] strengthList = {600, 600, 623, 623, 623, 646, 646, 646, 669, 669, 669, 692, 692, 692, 715, 715, 715, 738, 738, 738,
								 762, 762, 762, 785, 785, 785, 808, 808, 808, 831, 831, 831, 854, 854, 854, 877, 877, 877, 900, 900};
	public static int[] defenseList = {600, 600, 600, 623, 623, 623, 646, 646, 646, 669, 669, 669, 692, 692, 692, 715, 715, 715, 738, 738, 
								738, 762, 762, 762, 785, 785, 785, 808, 808, 808, 831, 831, 831, 854, 854, 854, 877, 877, 877, 900};	
	public static int[] penetrationList = {600, 600, 623, 623, 623, 646, 646, 646, 669, 669, 669, 692, 692, 692, 715, 715, 715, 738, 738, 738,
									762, 762, 762, 785, 785, 785, 808, 808, 808, 831, 831, 831, 854, 854, 854, 877, 877, 877, 900, 900};

	public static Dictionary<string, int> heroInLeague = new Dictionary<string,int>();


	public static int[] heroLevelUpCostFragm = {1, 2, 4, 6, 8, 10, 12, 14, 16, 20, 25, 30, 35, 40, 45, 50, 55, 60, 70, 80, 90, 100, 110, 120, 130, 140, 
											150, 160, 175, 200, 225, 250, 275, 300, 325, 350, 375, 400, 450};
	public static int[] heroLevelUpCostSoft = {100,200,400,600,800,1000,1200,1400,1600,2000,2500,3000,3500,4000,4500,5000,5500,6000,7000,8000,9000,
												10000,11000,12000,13000,14000,15000,16000,17500,20000,22500,25000,27500,30000,32500,35000,37500,40000,45000};
	public static int[] heroBuyCostFragm = { 5, 25, 100, 250, 500 };

	public static Dictionary<int, float[]> smallChestRewards = new Dictionary<int, float[]>();
	public static Dictionary<int,float[]> bigChestRewards = new Dictionary<int,float[]>();

	public static Dictionary<int, float> rewardCoef = new Dictionary<int,float>();


	public static void Init()
	{
//		itemsDefs.Add(new ItemDefinition("Оружие 1, тир 1", ItemType.WEAPON, 1, 1, 40,new int[] {},new int[] {},new int[] {},new int[] {},new int[] {},new int[]{9,18,27,36,45,54,63,72,81,90,99,108,117,126,135,144,153,162,171,180,189,198,207,216,225,234,243,252,261,270,279,288,297,306,315,324,333,342,351,360},new int[]{},new int[]{},new string[]{}));
//		itemsDefs.Add(new ItemDefinition("weapon1_1", ItemType.WEAPON));
//		itemsDefs.Add(new ItemDefinition("weapon1_2", ItemType.WEAPON));
//		itemsDefs.Add(new ItemDefinition("weapon1_3", ItemType.WEAPON));
//		itemsDefs.Add(new ItemDefinition("armor1_1", ItemType.ARMOR));
//		itemsDefs.Add(new ItemDefinition("armor1_2", ItemType.ARMOR));
//		itemsDefs.Add(new ItemDefinition("armor1_3", ItemType.ARMOR));
//		itemsDefs.Add(new ItemDefinition("Шлем 1, тир 1", ItemType.HELMET));
//		itemsDefs.Add(new ItemDefinition("Шлем 1, тир 2", ItemType.HELMET));
//		itemsDefs.Add(new ItemDefinition("Шлем 1, тир 3", ItemType.HELMET));

		itemsDefs = ItemDefinitionParser.ParseItemDefinition ();
		ItemDefinitionParser.DebugOutputItemDefinitions (itemsDefs);

		heroInLeague.Add ("Аттэна", 1);
		heroInLeague.Add ("Росинант", 1);
		heroInLeague.Add ("Дерханд", 1);
		heroInLeague.Add ("Эрайла", 1);
		heroInLeague.Add ("Линдра", 1);
		heroInLeague.Add ("Караб", 2);
		heroInLeague.Add ("Люми", 2);
		heroInLeague.Add ("Малпайн", 3);
		heroInLeague.Add ("Мэкси", 4);
		heroInLeague.Add ("Хупер", 5);

		smallChestRewards.Add (1, new float[]{ 1f, 3.5f, 0.62f, 0f, 0f });
		smallChestRewards.Add (2, new float[]{ 1f, 4.2f, 0.75f, 0.1f, 0f });
		smallChestRewards.Add (3, new float[]{ 1.3f, 5.25f, 1f, 0.13f, 0f });
		smallChestRewards.Add (4, new float[]{ 1.75f, 7.0f, 1.25f, 0.18f, 0.0014f });
		smallChestRewards.Add (5, new float[]{ 2.4f, 9.6f, 1.7f, 0.25f, 0.0019f });
		smallChestRewards.Add (6, new float[]{ 3.3f, 13.2f, 2.4f, 0.34f, 0.0026f });
		smallChestRewards.Add (7, new float[]{ 4.4f, 17.5f, 3.1f, 0.45f, 0, 0035f });

		bigChestRewards.Add (1, new float[]{ 5.25f, 21f, 3.8f, 0f, 0f });
		bigChestRewards.Add (2, new float[]{ 6.3f, 25.25f, 4.5f, 0.65f, 0f });
		bigChestRewards.Add (3, new float[]{ 7.9f, 31.5f, 5.7f, 0.8f, 0f });
		bigChestRewards.Add (4, new float[]{ 10.5f, 42f, 7.5f, 1f, 0.0085f });
		bigChestRewards.Add (5, new float[]{ 14.5f, 58f, 10.4f, 1.5f, 0.0117f });
		bigChestRewards.Add (6, new float[]{ 19.7f, 79f, 14.1f, 2f, 0.0160f });
		bigChestRewards.Add (7, new float[]{ 26.3f, 105f, 18.9f, 2.7f, 0.0214f });
	
		rewardCoef.Add (1, 1f);
		rewardCoef.Add (2, 1.2f);
		rewardCoef.Add (3, 1.5f);
		rewardCoef.Add (4, 2f);
		rewardCoef.Add (5, 2.75f);
		rewardCoef.Add (6, 3.75f);
		rewardCoef.Add (7, 5f);
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