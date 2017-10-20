using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Model {

	public static Hero selectedHero;
	public static Item selectedItem;
	public static string selectedSlot;
	public static string selectedHeroToBuy;
	public static List<ItemDefinition> itemsDefs = new List<ItemDefinition>();

	public static int[] healthList = {1000,1000,1000,1050,1050,1050,1050,1100,1100,1100,1100,1150,1150,1150,1150,1200,1200,1200,1200,1250,
		1250,1250,1250,1300,1300,1300,1300,1350,1350,1350,1350,1400,1400,1400,1400,1450,1450,1450,1450,1500};
	public static int[] strengthList = {600, 600, 630, 630, 630, 630, 660, 660, 660, 660, 690, 690, 690, 690, 720, 720, 720, 720, 750, 750,
		750, 750, 780, 780, 780, 780, 810, 810, 810, 810, 840, 840, 840, 840, 870, 870, 870, 870, 900, 900};
	public static int[] defenseList = {600, 600, 600, 600, 630, 630, 630, 630, 660, 660, 660, 660, 690, 690, 690, 690, 720, 720, 720, 720, 
		750, 750, 750, 750, 780, 780, 780, 780, 810, 810, 810, 810, 840, 840, 840, 840, 870, 870, 870, 900};	
	public static int[] penetrationList = {600, 630, 630, 630, 630, 660, 660, 660, 660, 690, 690, 690, 690, 720, 720, 720, 720, 750, 750, 750,
		750, 780, 780, 780, 780, 810, 810, 810, 810, 840, 840, 840, 840, 870, 870, 870, 870, 900, 900, 900};

	public static Dictionary<string, int> heroInLeague = new Dictionary<string,int>();


	public static int[] heroLevelUpCostFragm = {1, 2, 4, 6, 8, 10, 12, 14, 16, 20, 25, 30, 35, 40, 45, 50, 55, 60, 70, 80, 90, 100, 110, 120, 130, 140, 
											150, 160, 175, 200, 225, 250, 275, 300, 325, 350, 375, 400, 450};
	public static int[] heroLevelUpCostSoft = {100,200,400,600,800,1000,1200,1400,1600,2000,2500,3000,3500,4000,4500,5000,5500,6000,7000,8000,9000,
												10000,11000,12000,13000,14000,15000,16000,17500,20000,22500,25000,27500,30000,32500,35000,37500,40000,45000};
	public static int[] heroBuyCostFragm = { 5, 25, 100, 250, 500 };

	public static Dictionary<int, float[]> smallChestRewards = new Dictionary<int, float[]>();
	public static Dictionary<int,float[]> bigChestRewards = new Dictionary<int,float[]>();

	public static Dictionary<int, float> rewardCoef = new Dictionary<int,float>();

	public static Dictionary<int, int> leagueRating = new Dictionary<int, int> ();
	public static Dictionary<int, float> leagueRatingLostCoef = new Dictionary<int, float>();

	public static ItemType[] slotTypes = {
		ItemType.HELMET,
		ItemType.WEAPON,
		ItemType.WEAPON,
		ItemType.BOOTS,
		ItemType.AMULET,
		ItemType.ARMOR,
		ItemType.GLOVES,
		ItemType.PANTS
	};

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
		//ItemDefinitionParser.DebugOutputItemDefinitions (itemsDefs);

		heroInLeague.Add ("Аттэна", 1);
		heroInLeague.Add ("Росинант", 1);
		heroInLeague.Add ("Дерханд", 1);
		heroInLeague.Add ("Эрайла", 1);
		heroInLeague.Add ("Линдра", 1);
		heroInLeague.Add ("Караб", 2);
		heroInLeague.Add ("Люми", 2);
		heroInLeague.Add ("Скольд", 3);
		heroInLeague.Add ("Мэкси", 4);
		heroInLeague.Add ("Хупер", 5);
			
		smallChestRewards.Add (1, new float[]{ 1f, 3.5f, 0.62f, 0f, 0f });
		smallChestRewards.Add (2, new float[]{ 1f, 4.2f, 0.75f, 0.11f, 0f });
		smallChestRewards.Add (3, new float[]{ 1.31f, 5.26f, 0.94f, 0.14f, 0f });
		smallChestRewards.Add (4, new float[]{ 1.75f, 7f, 1.25f, 0.18f, 0.0014f });
		smallChestRewards.Add (5, new float[]{ 2.4f, 9.64f, 1.72f, 0.25f, 0.0020f });
		smallChestRewards.Add (6, new float[]{ 3.3f, 13.15f, 2.35f, 0.33f, 0.0027f });
		smallChestRewards.Add (7, new float[]{ 4.38f, 17.5f, 3.14f, 0.45f, 0,0035f });

		bigChestRewards.Add (1, new float[]{ 2.43f, 9.71f, 1.74f, 0f, 0f });
		bigChestRewards.Add (2, new float[]{ 2.91f, 11.65f, 2.08f, 0.30f, 0f });
		bigChestRewards.Add (3, new float[]{ 3.64f, 14.56f, 2.61f, 0.37f, 0f });
		bigChestRewards.Add (4, new float[]{ 4.86f, 19.42f, 3.48f, 0.50f, 0.0039f });
		bigChestRewards.Add (5, new float[]{ 6.68f, 26.7f, 4.78f, 0.68f, 0.0054f });
		bigChestRewards.Add (6, new float[]{ 9.11f, 36.42f, 6.52f, 0.93f, 0.0074f });
		bigChestRewards.Add (7, new float[]{ 12.15f, 48.56f, 8.7f, 1.24f, 0.01f });
	
		rewardCoef.Add (1, 1f);
		rewardCoef.Add (2, 1.2f);
		rewardCoef.Add (3, 1.5f);
		rewardCoef.Add (4, 2f);
		rewardCoef.Add (5, 2.75f);
		rewardCoef.Add (6, 3.75f);
		rewardCoef.Add (7, 5f);

		leagueRatingLostCoef.Add (1, 0.1f);
		leagueRatingLostCoef.Add (2, 0.2f);
		leagueRatingLostCoef.Add (3, 0.3f);
		leagueRatingLostCoef.Add (4, 0.5f);
		leagueRatingLostCoef.Add (5, 0.7f);
		leagueRatingLostCoef.Add (6, 0.9f);
		leagueRatingLostCoef.Add (7, 1f);

		leagueRating.Add (100, 2);
		leagueRating.Add (250, 3);
		leagueRating.Add (900, 4);	
		leagueRating.Add (3000, 5);
		leagueRating.Add (6000, 6);
		leagueRating.Add (10000, 7);
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