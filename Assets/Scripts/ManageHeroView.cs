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

		health.text = Model.healthList [Model.selectedHero.level - 1].ToString ();
		strength.text = Model.strengthList [Model.selectedHero.level - 1].ToString ();
		defense.text = Model.defenseList [Model.selectedHero.level - 1].ToString ();
		penetration.text = Model.penetrationList [Model.selectedHero.level - 1].ToString ();
		power.text = (Model.healthList [Model.selectedHero.level - 1] + Model.strengthList [Model.selectedHero.level - 1] * 10 / 6 +
						Model.defenseList [Model.selectedHero.level - 1] * 10 / 6 + Model.penetrationList [Model.selectedHero.level - 1] * 10 / 6).ToString ();

		heroName.text = Model.selectedHero.name;

		for (int i = 0; i < items.Length; i++) {
			if (Model.selectedHero.equippeditems [i] != null) {
				items [i].SetActive (true);
				itemNames [i].text = Model.selectedHero.equippeditems [i].name;
				itemLevels [i].text = Model.selectedHero.equippeditems [i].level.ToString();
				
			}
		}

	}
}
