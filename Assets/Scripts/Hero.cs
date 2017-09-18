using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero {
	public string name;
	public int level;
	public Item[] equippeditems= new Item[8];

	public int power;
	public int health;
	public int strength;
	public int defense;
	public int penetration;

	public Hero(string n) {
		name = n;
		level = 1;
		health = Model.healthList [level - 1];
		strength = Model.strengthList [level - 1];
		defense = Model.defenseList [level - 1];
		penetration = Model.penetrationList [level - 1];
		power = health + strength * 10 / 6 + defense * 10 / 6 + penetration * 10 / 6;
	}

	public void equipItem(Item item, int index) {
		equippeditems [index] = item;
		int itemLevel = item.level;
		if (item.itemDefinition.bonusHealth.Length > 0) {
			health += item.itemDefinition.bonusHealth [itemLevel - 1];
		}
		if (item.itemDefinition.bonusStrength.Length > 0) {
			strength += item.itemDefinition.bonusStrength [itemLevel - 1];
		}
		if (item.itemDefinition.bonusDefense.Length > 0) {
			defense += item.itemDefinition.bonusDefense [itemLevel - 1];
		}
		if (item.itemDefinition.bonusPenetration.Length > 0) {
			penetration += item.itemDefinition.bonusPenetration [itemLevel - 1];
		}
		power = health + strength * 10 / 6 + defense * 10 / 6 + penetration * 10 / 6;
	}
}
