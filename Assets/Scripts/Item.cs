﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public string name;
	public int level;
	public ItemDefinition itemDefinition;
	public bool isEquip;


	public Item(string n) {
		name = n;
		level = 1;
		itemDefinition = Model.getItemDef(n);
		isEquip = false;
	}

	public void AddDefinition()
	{
		itemDefinition = Model.getItemDef(name);
	}
}


