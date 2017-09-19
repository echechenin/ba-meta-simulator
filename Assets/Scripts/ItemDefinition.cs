using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDefinition {
	public string name;
	public ItemType type;
	public int maxLevel;
	//economy stats
	public int[] partsForUpgrade;
	public int[] softForUpgrade;
	public int[] timeForUpgrade; //in minutes
	public int[] allPartOnLevel;
	//battle stats
	public int[] bonusHealth;
	public int[] bonusStrength;
	public int[] bonusDefense;
	public int[] bonusPenetration;


	public ItemDefinition(string n, ItemType t, int level, int[] parts, int[] soft, int[] time, int[] allParts, int[] health, int[] strength, int[] defense, int[] penetration) {
		name = n;
		type = t;
		maxLevel = level;

		partsForUpgrade = parts;
		softForUpgrade = soft;
		timeForUpgrade = time;
		allPartOnLevel = allParts;

		bonusHealth = health;
		bonusStrength = strength;
		bonusDefense = defense;
		bonusPenetration = penetration;
	}

	public ItemDefinition(string n, ItemType t)
	{
		name = n;
		type = t;
	}
}

public enum ItemType {
	WEAPON = 1,
	ARMOR = 2,
	PANTS = 3,
	GLOVES = 4,
	BOOTS = 5,
	HELMET = 6,
	AMULET = 7
}


