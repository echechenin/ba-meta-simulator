﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDefinition {
	public string name;
	public ItemType type;
	public int league;
	public int maxLevel;
	public int[] bonusHealth;
	public int[] bonusStrength;
	public int[] bonusDefense;
	public int[] bonusPenetration;


	public ItemDefinition(string n, ItemType t, int leag, int level, int[] health, int[] strength, int[] defense, int[] penetration) {
		name = n;
		type = t;
		league = leag;
		maxLevel = level;
		bonusHealth = health;
		bonusStrength = strength;
		bonusDefense = defense;
		bonusPenetration = penetration;
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


