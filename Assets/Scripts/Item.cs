using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public string name;
	public int level;
	public ItemDefinition itemDefinition;
	public bool isEquip;


	public Item(string n, int lvl = 1) {
		name = n;
		level = lvl;
		itemDefinition = Model.getItemDef(n);
		isEquip = false;
	}

	public void AddDefinition()
	{
		itemDefinition = Model.getItemDef(name);
	}
}


