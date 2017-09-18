using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageHeroButton : MonoBehaviour {
	private LevelManager levelManager;

	private void Awake() {
		levelManager = Object.FindObjectOfType<LevelManager>();
	}

	public void OnClick(int slotIndex) {
		Model.selectedHero = Player.dropTeam [slotIndex].hero;
		print ("Managing hero " + Model.selectedHero.name);
		levelManager.LoadScene ("ManageHero");	
	}
}
