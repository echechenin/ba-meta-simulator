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
	public Text buttonUpgradeText;

	public GameObject[] items;
	public Text[] itemNames;
	public Text[] itemLevels;

	public Text heroNamePopup;
	public Text heroLevelPopup;
	public Text heroRequiredItemsPopup;
	public Text healthPopup;
	public Text healthBonusPopup;
	public Text strengthPopup;
	public Text strengthBonusPopup;
	public Text defensePopup;
	public Text defenseBonusPopup;
	public Text penetrationPopup;
	public Text penetrationBonusPopup;
	public Text buttonUpgradeTextPopup;



	// Use this for initialization
	void Start () {
//		for (int i = 0; i < items.Length; i++) {
//			if (Model.selectedHero.equippeditems [i] != null) {
//				items [i].SetActive (true);
//				itemNames [i].text = Model.selectedHero.equippeditems [i].name;
//				itemLevels [i].text = Model.selectedHero.equippeditems [i].level.ToString();
//			}
//		}
		int i = 0;
		foreach (GameObject itemGO in items) {
			if (Model.selectedHero.equippeditems [i++] != null) {
				CardItem cardItem = itemGO.GetComponent<CardItem> ();
				cardItem.SetCardItem (Model.selectedHero.equippeditems [i-1], 0);
			}
		}

	}

	public void equipIteminView(Item item, int slotNum)
	{
		items [slotNum].SetActive (true);
		CardItem cardItem = items[slotNum].GetComponent<CardItem> ();
		cardItem.SetCardItem (item, 0);
	}

	public void UnEquipIteminView(int slotNum)
	{
		//говорим модели убрать элемент в инвентарь
		Model.selectedHero.UnEquipItem(slotNum);

		//Прячем предмет в слоте
		items [slotNum].GetComponent<CardItem>().openMenu();
		items [slotNum].SetActive (false);
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

		if (Player.fragmentInventory.ContainsKey (Model.selectedHero.name)) {
			heroRequiredItems.text = Player.fragmentInventory [Model.selectedHero.name].ToString() + "/" + Model.heroLevelUpCostFragm [Model.selectedHero.level - 1].ToString();
		} else {
			heroRequiredItems.text = "0/" + Model.heroLevelUpCostFragm [Model.selectedHero.level - 1].ToString ();
		}

		buttonUpgradeText.text = "Улучшить " + Model.heroLevelUpCostSoft [Model.selectedHero.level - 1].ToString ();

		heroNamePopup.text = heroName.text;
		heroLevelPopup.text = heroLevel.text;
		heroRequiredItemsPopup.text = heroRequiredItems.text;
		healthPopup.text = Model.healthList[Model.selectedHero.level-1].ToString();
		strengthPopup.text = Model.strengthList[Model.selectedHero.level-1].ToString();
		defensePopup.text = Model.defenseList[Model.selectedHero.level-1].ToString();
		penetrationPopup.text = Model.penetrationList[Model.selectedHero.level-1].ToString();
		buttonUpgradeTextPopup.text = buttonUpgradeText.text;
		if (Model.healthList [Model.selectedHero.level] > Model.healthList [Model.selectedHero.level - 1]) {
			healthBonusPopup.text = "+ " + (Model.healthList [Model.selectedHero.level] - Model.healthList [Model.selectedHero.level - 1]).ToString ();
		} else {
			healthBonusPopup.text = "";
		}
		if (Model.strengthList [Model.selectedHero.level] > Model.strengthList [Model.selectedHero.level - 1]) {
			strengthBonusPopup.text = "+ " + (Model.strengthList [Model.selectedHero.level] - Model.strengthList [Model.selectedHero.level - 1]).ToString ();
		}else {
			strengthBonusPopup.text = "";
		}
		if (Model.defenseList [Model.selectedHero.level] > Model.defenseList [Model.selectedHero.level - 1]) {
			defenseBonusPopup.text = "+ " + (Model.defenseList [Model.selectedHero.level] - Model.defenseList [Model.selectedHero.level - 1]).ToString ();
		}else {
			defenseBonusPopup.text = "";
		}
		if (Model.penetrationList [Model.selectedHero.level] > Model.penetrationList [Model.selectedHero.level - 1]) {
			penetrationBonusPopup.text = "+ " + (Model.penetrationList [Model.selectedHero.level] - Model.penetrationList [Model.selectedHero.level - 1]).ToString ();
		}else {
			penetrationBonusPopup.text = "";
		}
	}
}