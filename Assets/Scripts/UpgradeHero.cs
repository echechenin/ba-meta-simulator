using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHero : MonoBehaviour {

	public void Upgrade() {
		Model.selectedHero.upgradeHero();
	}
}
