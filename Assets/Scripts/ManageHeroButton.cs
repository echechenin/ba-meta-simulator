using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageHeroButton : MonoBehaviour {

	public void OnClick(int slotIndex) {
		Model.selectedHero = Player.dropTeam [slotIndex].hero;
		print ("Managing hero " + Model.selectedHero.name);
		SceneManager.LoadScene ("ManageHero");	
	}
}
