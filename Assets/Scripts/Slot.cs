using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot {
	public Hero hero;

	public Slot(Hero her) {
		hero = her;
	}

	public Slot() {
		hero = null;
	}
}