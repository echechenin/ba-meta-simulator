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
	public static Dictionary<string,Item> inventory = new Dictionary<string,Item>();
	public static Dictionary<string,int> fragmentInventory = new Dictionary<string,int>();


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
		inventory.Add("sword1_1",new Item("sword1_1"));
		inventory.Add("sword1_2",new Item("sword1_2"));
		inventory.Add("sword1_3",new Item("sword1_3"));
		inventory.Add("helmet1_1",new Item("helmet1_1"));
		inventory.Add("helmet1_2",new Item("helmet1_2"));
		inventory.Add("helmet1_3",new Item("helmet1_3"));
		inventory.Add("armor1_1",new Item("armor1_1"));
		inventory.Add("armor1_2",new Item("armor1_2"));
		inventory.Add("armor1_3",new Item("armor1_3"));
		rating = 0;
		softCurrency = 1000;
		hardCurrency = 0;
		league = 1;
	}

}