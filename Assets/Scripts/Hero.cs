using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero {
	public string name;
	public int level;
	public Item[] equippeditems= new Item[8];

	public Hero(string n) {
		name = n;
		level = 1;
	}
}
