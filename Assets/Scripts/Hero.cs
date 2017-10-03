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
		calculateHeroStats();
	}

	public void calculateHeroStats() {
		health = Model.healthList [level - 1];
		strength = Model.strengthList [level - 1];
		defense = Model.defenseList [level - 1];
		penetration = Model.penetrationList [level - 1];
		for (int i = 0; i < equippeditems.Length; i++) {
			if (equippeditems [i] != null) {
				ItemDefinition itemStats = equippeditems [i].itemDefinition;
				if (itemStats.bonusHealth.Length != 0) {
					health += itemStats.bonusHealth [equippeditems [i].level];
				}
				if (itemStats.bonusStrength.Length != 0) {
					strength += itemStats.bonusStrength [equippeditems [i].level];
				}
				if (itemStats.bonusDefense.Length != 0) {
					defense += itemStats.bonusDefense [equippeditems [i].level];
				}
				if (itemStats.bonusPenetration.Length != 0) {
					penetration += itemStats.bonusPenetration [equippeditems [i].level];
				}
			}
		}
		power = health + strength * 10 / 6 + defense * 10 / 6 + penetration * 10 / 6;
	}

	public void equipItemInModel(Item item, int indexSlot) {
		//Добавляем предмет в инвентарь игроку
		equippeditems [indexSlot] = item;
		item.isEquip = true;
		//меняем данные в модели
		//ChangeHeroStats(item, indexSlot);
		calculateHeroStats();
	}

	public void equipItem(Item item, int indexSlot) {
		//Добавляем предмет в инвентарь игроку
		equippeditems [indexSlot] = item;
		//меняем вьюху
		GameObject.FindObjectOfType<ManageHeroView> ().equipIteminView(item,indexSlot);
		//меняем данные в модели
		//ChangeHeroStats(item, indexSlot, true);
		calculateHeroStats();
	}

	public void UnEquipItem(int index) {
		//меняем вьюху
		//GameObject.FindObjectOfType<ManageHeroView> ().UnEquipIteminView(index);
		//Пересчитываем стату в модели
		//ChangeHeroStats(equippeditems[index], index, false);
		//Говорим инвентарю, что сняли предмет
		GameObject.FindObjectOfType<InventoryController> ().ReturnItemToInventory(equippeditems[index]);
		//убираем ссылку на предмет из модели игрока
		equippeditems[index].isEquip = false;
		equippeditems[index] = null;
		calculateHeroStats ();
	}

	public void ChangeHeroStats(Item item, int index, bool add)
	{
		equippeditems [index] = item;
		int itemLevel = item.level;
		if (item.itemDefinition.bonusHealth.Length > 0) {
			if (add) {
				health += item.itemDefinition.bonusHealth [itemLevel - 1];
			} else {
				health -= item.itemDefinition.bonusHealth [itemLevel - 1];
			}
		}
		if (item.itemDefinition.bonusStrength.Length > 0) {
			if (add) {
				strength += item.itemDefinition.bonusStrength [itemLevel - 1];
			} else {
				strength -= item.itemDefinition.bonusStrength [itemLevel - 1];
			}
		}
		if (item.itemDefinition.bonusDefense.Length > 0) {
			if (add) {
				defense += item.itemDefinition.bonusDefense [itemLevel - 1];
			} else {
				defense -= item.itemDefinition.bonusDefense [itemLevel - 1];
			}
		}
		if (item.itemDefinition.bonusPenetration.Length > 0) {
			if (add) {
				penetration += item.itemDefinition.bonusPenetration [itemLevel - 1];
			} else {
				penetration -= item.itemDefinition.bonusPenetration [itemLevel - 1];
			}
		}
		power = health + strength * 10 / 6 + defense * 10 / 6 + penetration * 10 / 6;
	}

	public void upgradeHero() {
		if (!Player.fragmentInventory.ContainsKey(name)) {
			return;
		}
		if ((Player.fragmentInventory [name] >= Model.heroLevelUpCostFragm [level - 1]) && (Player.softCurrency >= Model.heroLevelUpCostSoft [level - 1])) {
			Player.fragmentInventory [name] -= Model.heroLevelUpCostFragm [level - 1];
			Player.softCurrency -= Model.heroLevelUpCostSoft [level - 1];
			level++;
			calculateHeroStats ();
		} else if (Player.fragmentInventory [name] >= Model.heroLevelUpCostFragm [level - 1]) {
			Debug.Log ("Not enough Fragments");
		} else if (Player.softCurrency >= Model.heroLevelUpCostSoft [level - 1]) {
			Debug.Log ("Not enough Soft Currency");
		}
	}
}
