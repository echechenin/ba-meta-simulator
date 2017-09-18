using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEquipView : MonoBehaviour {

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

	public Text itemType;

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

		for (int i = 0; i < items.Length; i++) {
			if (Model.selectedHero.equippeditems [i] != null) {
				items [i].SetActive (true);
				itemNames [i].text = Model.selectedHero.equippeditems [i].name;
				itemLevels [i].text = Model.selectedHero.equippeditems [i].level.ToString();

			}
		}
		itemType.text = Model.selectedSlot.ToString();

/*		ItemType slotname = ItemType.WEAPON;
		switch (itemType.text) {
		case "ОРУЖИЕ":
			slotname = ItemType.WEAPON;
			break;
		case "ШЛЕМ":
			slotname = ItemType.HELMET;
			break;
		case "БРОНЯ":
			slotname = ItemType.ARMOR;
			break;
		case "ШТАНЫ":
			slotname = ItemType.PANTS;
			break;
		case "АМУЛЕТ":
			slotname = ItemType.AMULET;
			break;
		case "ПЕРЧАТКИ":
			slotname = ItemType.GLOVES;
			break;
		case "БОТИНКИ":
			slotname = ItemType.BOOTS;
			break;
		}

		foreach (KeyValuePair<Item,int> item in Player.inventory) {
			if (item.Key.itemDefinition.type == slotname) {
			// создать данный предмет во вьюшке
			}	
		}
*/

	}
}