using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChangeHeroButton : MonoBehaviour {

	private LevelManager levelManager;

	private void Awake() {
		levelManager = Object.FindObjectOfType<LevelManager>();
	}

	public void ChangeHero(int slotIndex) {
		Model.selectedHero = Player.dropTeam [slotIndex].hero;
		print ("Changing hero " + Model.selectedHero.name);
		levelManager.LoadScene ("ChangeHero");	
	}

	public void BuyHero() {
		Model.selectedHero = null;
		levelManager.LoadScene ("ChangeHero");
	}
}
