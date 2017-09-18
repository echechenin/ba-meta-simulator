using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageHeroView : MonoBehaviour {
	public Text softCurrencyLabel;
	public Text hardCurrencyLabel;
	public Text ratingLabel;
	public Text leagueLabel;

	public Text power;
	public Text health;
	public Text strength;
	public Text defense;
	public Text penetration;

	public Text heroName;
	public Text heroLevel;
	public Text heroRequiredItems;

	public GameObject[] items;
	public Text[] itemNames;
	public Text[] itemLevels;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		softCurrencyLabel.text = Player.softCurrency.ToString();
		hardCurrencyLabel.text = Player.hardCurrency.ToString ();
		ratingLabel.text = Player.rating.ToString ();
		leagueLabel.text = "Лига " + Player.league.ToString ();

		health.text = Model.selectedHero.health.ToString ();
		strength.text = Model.selectedHero.strength.ToString ();
		defense.text = Model.selectedHero.defense.ToString ();
		penetration.text = Model.selectedHero.penetration.ToString ();
		power.text = Model.selectedHero.power.ToString ();

		heroName.text = Model.selectedHero.name;
		heroLevel.text = "Уровень " + Model.selectedHero.level.ToString();

		for (int i = 0; i < items.Length; i++) {
			if (Model.selectedHero.equippeditems [i] != null) {
				items [i].SetActive (true);
				itemNames [i].text = Model.selectedHero.equippeditems [i].name;
				itemLevels [i].text = Model.selectedHero.equippeditems [i].level.ToString();
				
			}
		}

	}
}
