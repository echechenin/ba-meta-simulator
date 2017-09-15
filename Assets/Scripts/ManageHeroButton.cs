using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageHeroButton : MonoBehaviour {

	public void OnClick(int slotIndex) {
		CurrentHero.hero = Player.dropTeam [slotIndex].hero;
		print ("Managing hero " + CurrentHero.hero.name);
		SceneManager.LoadScene ("ManageHero");
	}
}
