using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class Player {


	//declaring PLAYER
	public static int rating ;
	public static int softCurrency;
	public static int hardCurrency;
	public static int league;

	public static List<Hero> heroes = new List<Hero>();
	public static List<Slot> dropTeam = new List<Slot> ();
	public static List<Item> inventory = new List<Item>();
	public static Dictionary<string,int> fragmentInventory = new Dictionary<string,int>();

	private const int smallChestTimer = 4;
	private const int smallChestMaximum = 2;
	public static int smallChestsReady;
	public static int timeLeftForNextSmallChest;

	private const int bigChestTimer = 8;
	private const int bigChestMaximum = 2;
	private const int bigChestRequiredWins = 2;
	public static int bigChestsReady;
	public static int bigChestProgress;
	public static int timeLeftForNextBigChest;


	//стата по предметам
	public static Dictionary<string,int> totalItemsCount = new Dictionary<string, int>();
	public static Dictionary<string,int> totalFragmentsCount = new Dictionary<string,int>();

	public static void Init()
	{
		//Добавление героев
		heroes.Add (new Hero ("Линдра"));
		totalFragmentsCount.Add ("Линдра", 5);

		heroes.Add (new Hero ("Росинант"));
		totalFragmentsCount.Add ("Росинант", 5);

		dropTeam.Add (new Slot(heroes[0]));
		dropTeam.Add (new Slot(heroes[1]));
		dropTeam.Add (new Slot ());
		dropTeam.Add (new Slot ());
		dropTeam.Add (new Slot ());

		//Добавление стартовых предметов в инвентарь
		AddItemToInventory ("Оружие 1, тир 1");

		//Одевание стартовых предметов на героев
		EquipItemInModel (0, 1, "Оружие 1, тир 1", 1);

		//Стартовые значение игрока в мете
		rating = 0;
		softCurrency = 1000;
		hardCurrency = 0;	
		league = 1;
		smallChestsReady = 1;
		timeLeftForNextSmallChest = 4;
		bigChestsReady = 1;
		bigChestProgress = 0;
		timeLeftForNextBigChest = 8;


	}

	public static void AddItemToInventory(string name, int level = 1)
	{
		inventory.Add (new Item (name, level));
		if (totalItemsCount.ContainsKey (name)) {
			totalItemsCount [name] += 1;
		} else {
			totalItemsCount.Add (name, 1);
		}
	}

	public static void EquipItemInModel(int heroID, int indexSlot, string name, int level)
	{
		foreach (Item item in inventory) {
			if (item.name == name && item.level == level) {
				item.isEquip = true;
				heroes [heroID].equippeditems [indexSlot] = item;
			}
		}
	}

	public static void ChangeHeroInDropteam(Hero oldHero, Hero newHero) {
		foreach (Slot slot in dropTeam) {
			if (slot.hero == oldHero) {
				slot.hero = newHero;
				return;
			}
		}
	}

	public static bool BuyHeroInDropTeam(Hero oldHero, Hero newHero) {
		if ((Player.fragmentInventory.ContainsKey (newHero.name))
		    && (Player.fragmentInventory [newHero.name] >= Model.heroBuyCostFragm [0])) {
			Player.fragmentInventory [newHero.name] -= Model.heroBuyCostFragm [0];
			Player.heroes.Add (newHero);
			ChangeHeroInDropteam (oldHero, newHero);
			return true;
		}
		return false;
	}

	public static void SkipTime(int hours) {
		if (smallChestsReady < smallChestMaximum) {
			timeLeftForNextSmallChest -= hours;
			int x = smallChestsReady;
			for (int i = 0; i < (smallChestMaximum-x); i++) {
				if (timeLeftForNextSmallChest <= 0) {
					smallChestsReady++;
					timeLeftForNextSmallChest += smallChestTimer;
				}
			}
			if (smallChestsReady == smallChestMaximum)
				timeLeftForNextSmallChest = smallChestTimer;
		}

		if (bigChestsReady < bigChestMaximum) {
			timeLeftForNextBigChest -= hours;
			int x = bigChestsReady;
			for (int i = 0; i < (bigChestMaximum-x); i++) {
				if (timeLeftForNextBigChest <= 0) {
					bigChestsReady++;
					timeLeftForNextBigChest += bigChestTimer;
				}
			}
			if (bigChestsReady == bigChestMaximum)
				timeLeftForNextBigChest = bigChestTimer;
		}
			
	}
}