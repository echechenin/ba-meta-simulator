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
		heroes.Add (new Hero ("Линдра"));
		heroes [0].equipItemInModel (new Item("Оружие 1, тир 1"), 0);
		heroes.Add (new Hero ("Росинант"));
		dropTeam.Add (new Slot(heroes[0]));
		dropTeam.Add (new Slot(heroes[1]));
		dropTeam.Add (new Slot ());
		dropTeam.Add (new Slot ());
		dropTeam.Add (new Slot ());
		AddItemToInventory ("weapon1_1");
		AddItemToInventory ("weapon1_2");
		AddItemToInventory ("weapon1_3");
		AddItemToInventory ("armor1_1");
		AddItemToInventory ("armor1_2");
		AddItemToInventory ("armor1_3");
		AddItemToInventory ("Шлем 1, тир 1");
		AddItemToInventory ("Шлем 1, тир 2");
		AddItemToInventory ("Шлем 1, тир 3");
		rating = 0;
		softCurrency = 1000;
		hardCurrency = 0;
		league = 1;
		Player.fragmentInventory.Add ("Линдра", 100);
	}

	public static void AddItemToInventory(string name)
	{
		inventory.Add (name, new Item (name));
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