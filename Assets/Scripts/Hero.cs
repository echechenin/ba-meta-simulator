using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero {
	public string name;
	public int level;
	public Item[] equippeditems = new Item[8];

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

	public void equipItemInModel(Item item, int index) {
		//меняем данные в модели
		ChangeHeroStats(item, index);
	}

	public void equipItem(Item item, int index) {
		//Добавляем предмет в инвентарь игроку
		equippeditems [index] = item;
		//меняем вьюху
		GameObject.FindObjectOfType<ManageHeroView> ().equipIteminView(item,index);
		//меняем данные в модели
		//ChangeHeroStats(item, index);
	}

	public void UnEquipItem(int index) {
		//меняем вьюху
		GameObject.FindObjectOfType<ManageHeroView> ().UnEquipIteminView(index);
		//Пересчитываем стату в модели
		//ChangeHeroStats(equippeditems[index], index);
		//Говорим инвентарю, что сняли предмет
		GameObject.FindObjectOfType<InventoryController> ().ReturnItemToInventory(equippeditems[index]);
		//убираем ссылку на предмет из модели игрока
		equippeditems[index] = null;
	}

	public void ChangeHeroStats(Item item, int index)
	{
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

	public void upgradeHero() {
		if (!Player.fragmentInventory.ContainsKey(name)) {
			return;
		}
		if ((Player.fragmentInventory [name] >= Model.heroLevelUpCostFragm [level - 1]) && (Player.softCurrency >= Model.heroLevelUpCostSoft [level - 1])) {
			health = health + Model.healthList [level] - Model.healthList [level - 1];
			strength = strength + Model.strengthList [level] - Model.strengthList [level - 1];
			defense = defense + Model.defenseList [level] - Model.defenseList [level - 1];
			penetration = penetration + Model.penetrationList [level] - Model.penetrationList [level - 1];
			power = health + strength * 10 / 6 + defense * 10 / 6 + penetration * 10 / 6;
			Player.fragmentInventory [name] -= Model.heroLevelUpCostFragm [level - 1];
			Player.softCurrency -= Model.heroLevelUpCostSoft [level - 1];
			level++;
		} else if (Player.fragmentInventory [name] >= Model.heroLevelUpCostFragm [level - 1]) {
			Debug.Log ("Not enough Fragments");
		} else if (Player.softCurrency >= Model.heroLevelUpCostSoft [level - 1]) {
			Debug.Log ("Not enough Soft Currency");
		}
	}
}
