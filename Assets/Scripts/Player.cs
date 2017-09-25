﻿using System.Collections;
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
	public static Dictionary<string,Item> inventory = new Dictionary<string,Item>();
	public static Dictionary<string,int> fragmentInventory = new Dictionary<string,int>();


	//starting Data
	static Player() {
	}

	public static void Init()
	{
		//Добавление героев
		heroes.Add (new Hero ("Линдра"));
		heroes.Add (new Hero ("Росинант"));
		dropTeam.Add (new Slot(heroes[0]));
		dropTeam.Add (new Slot(heroes[1]));
		dropTeam.Add (new Slot ());
		dropTeam.Add (new Slot ());
		dropTeam.Add (new Slot ());

		//Добавление стартовых предметов в инвентарь
		AddItemToInventory ("Оружие 1, тир 1");
		AddItemToInventory ("Оружие 2, тир 1");
		AddItemToInventory ("Оружие 3, тир 1");
		AddItemToInventory ("Броня 1, тир 1");
		AddItemToInventory ("Броня 2, тир 1");
		AddItemToInventory ("Броня 3, тир 1");
		AddItemToInventory ("Шлем 1, тир 1");
		AddItemToInventory ("Шлем 2, тир 1");
		AddItemToInventory ("Шлем 3, тир 1");

		//Добавление стартовых шардов героев в инвентарь
		fragmentInventory.Add ("Линдра", 100);

		//Одевание стартовых предметов на героев
		EquipItemInModel (0, 1, "Оружие 1, тир 1", 1);

		//Стартовые значение игрока в мете
		rating = 0;
		softCurrency = 1000;
		hardCurrency = 0;
		league = 1;
	}

	public static void AddItemToInventory(string name)
	{
		inventory.Add (name, new Item (name));
	}

	public static void EquipItemInModel(int heroID, int indexSlot, string name, int level)
	{
		foreach (string itemName in inventory.Keys) {
			if (itemName == name && inventory[itemName].level == level) {
				inventory [itemName].isEquip = true;
				heroes [heroID].equippeditems [indexSlot] = inventory [itemName];
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
}