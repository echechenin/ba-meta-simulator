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
	public static Dictionary<Item,int> inventory = new Dictionary<Item,int>();


	//starting Data
	static Player() {
		heroes.Add (new Hero ("Линдра"));
		heroes [0].equipItem (new Item("Оружие 1, тир 1"), 0);
		heroes.Add (new Hero ("Росинант"));
		dropTeam.Add (new Slot(heroes[0]));
		dropTeam.Add (new Slot(heroes[1]));
		dropTeam.Add (new Slot ());
		dropTeam.Add (new Slot ());
		dropTeam.Add (new Slot ());
		rating = 0;
		softCurrency = 1000;
		hardCurrency = 0;
		league = 1;
	}

}
