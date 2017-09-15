using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour {

	//for visual
	public Text softCurrencyLabel;
	public Text hardCurrencyLabel;
	public Text ratingLabel;
	public Text leagueLabel;
	public List<GameObject> dropTeamGO;
	public List<Text> dropTeamGONames;
	public List<Text> dropTeamGOLevels;
	
	private void Update() {
		softCurrencyLabel.text = Player.softCurrency.ToString();
		hardCurrencyLabel.text = Player.hardCurrency.ToString ();
		ratingLabel.text = Player.rating.ToString ();
		leagueLabel.text = "Лига " + Player.league.ToString ();

		foreach (GameObject slot in dropTeamGO) {
			if (Player.dropTeam[dropTeamGO.IndexOf(slot)].hero != null) {
				slot.SetActive(true);
				dropTeamGONames[dropTeamGO.IndexOf (slot)].text = Player.dropTeam [dropTeamGO.IndexOf (slot)].hero.name;
				dropTeamGOLevels[dropTeamGO.IndexOf (slot)].text = Player.dropTeam [dropTeamGO.IndexOf (slot)].hero.level.ToString();
			}
		}

	}
}
