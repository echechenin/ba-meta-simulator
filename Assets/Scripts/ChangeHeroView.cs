using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeroView : MonoBehaviour {

	//for visual
	public Text softCurrencyLabel;
	public Text hardCurrencyLabel;
	public Text ratingLabel;
	public Text leagueLabel;

	public Text heroName;

	private List<Hero> heroesInInventory = new List<Hero>();
	private List<string> availableForBuy = new List<string>();

	public GameObject changeButton;
	public GameObject buyButton;

	private int index;

	private void Awake() {
		foreach (Hero hero in Player.heroes) {
			bool isPresented = false;
			foreach (Slot slot in Player.dropTeam) {
				if (slot.hero == hero) {
					isPresented = true;
				}
			}
			if (!isPresented) {
				heroesInInventory.Add (hero);
			}
		}
		foreach (KeyValuePair<string,int> pair in Model.heroInLeague) {
			if (Player.league >= pair.Value) {
				availableForBuy.Add (pair.Key);
			}
		}
		openFirstHero ();
	}

	private void Update() {
		softCurrencyLabel.text = Player.softCurrency.ToString ();
		hardCurrencyLabel.text = Player.hardCurrency.ToString ();
		ratingLabel.text = Player.rating.ToString ();
		leagueLabel.text = "Лига " + Player.league.ToString ();
	}

	public void openFirstHero() {
		if (heroesInInventory.Count != 0) {
			heroName.text = heroesInInventory [0].name;
			changeButton.SetActive (true);
			buyButton.SetActive (false);
		} else {
			heroName.text = availableForBuy [0];
			changeButton.SetActive (false);
			buyButton.SetActive (true);
		}
		index = 0;

	}

	public void showNextHero() {

	}

	public void showPreviousHero() {

	}
}
