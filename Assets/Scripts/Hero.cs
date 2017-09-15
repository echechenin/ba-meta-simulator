using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero {
	public string name;
	public int level;
	public Item[] equppeditems;

	public Hero(string n) {
		name = n;
		level = 1;
		equppeditems = new Item[8];
	}
}
