using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDefinition {
	public string name;
	public ItemType type;
	public int tier;
	public int league;
	public int maxLevel;
	public int[] partsForUpgrade;
	public int[] softForUpgrade;
	public int[] timeForUpgrade;
	public int[] allPartOnLevel;
	public int[] bonusHealth;
	public int[] bonusStrength;
	public int[] bonusDefense;
	public int[] bonusPenetration;
	public string[] passive;


	public ItemDefinition(
		string n, ItemType t, int level, int leag, int tie, 
		//meta
		int[] PartsForUpgrade,
		int[] SoftForUpgrade,
		int[] TimeForUpgrade,
		int[] AllPartOnLevel, 
		//core
		int[] health, 
		int[] strength, 
		int[] defense, 
		int[] penetration,
		string[] passiveAbil) 
	{
		name = n;
		type = t;
		maxLevel = level;
		league = leag;
		tier = tie;
		//meta
		partsForUpgrade = PartsForUpgrade;
		softForUpgrade = SoftForUpgrade;
		timeForUpgrade = TimeForUpgrade;
		allPartOnLevel = AllPartOnLevel;
		//core
		bonusHealth = health;
		bonusStrength = strength;
		bonusDefense = defense;
		bonusPenetration = penetration;
		passive = passiveAbil;
	}

	public ItemDefinition(string n, ItemType t) {
		name = n;
		type = t;
	}

}

public enum ItemType {
	WEAPON,
	ARMOR,
	PANTS,
	GLOVES,
	BOOTS,
	HELMET,
	AMULET
}


