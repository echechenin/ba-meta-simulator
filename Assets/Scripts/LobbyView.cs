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

	public GameObject thirdSlot;
	public GameObject fourthSlot;
	public GameObject fifthSlot;

	public GameObject recommendPanel;
	public GameObject bigChestReadyToOpenPanel;
	public GameObject smallChestReadyToOpenPanel;
	public GameObject heroReadyToUpgradePanel;
	public GameObject itemReadyToUpgradePanel;
	public GameObject bigChestAlmostReadyPanel;
	public GameObject heroReadyToUpgradePanelNoSoft;
	public GameObject itemReadyToUpgradePanelNoSoft;


	
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
				slot.transform.Find("HeroPicName").transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/HeroImgs/" + Player.dropTeam [dropTeamGO.IndexOf (slot)].hero.name);
			}
		}
		int heroesDropTeamCount = 0;
		foreach (Slot slot in Player.dropTeam) {
			if (slot.hero != null) {
				heroesDropTeamCount++;
			} else
				break;
		}
		switch (heroesDropTeamCount) {
		case 2: 
			thirdSlot.SetActive (true);
			break;
		case 3:
			fourthSlot.SetActive (true);
			break;
		case 4:
			fifthSlot.SetActive (true);
			break;
		}  

		if (Player.bigChestsReady > 0 && Player.bigChestProgress >= 3) {
			recommendPanel.SetActive (true);
			bigChestReadyToOpenPanel.SetActive (true);
			smallChestReadyToOpenPanel.SetActive (false);
			heroReadyToUpgradePanel.SetActive (false);
			itemReadyToUpgradePanel.SetActive (false);
			bigChestAlmostReadyPanel.SetActive (false);
			heroReadyToUpgradePanelNoSoft.SetActive (false);
			itemReadyToUpgradePanelNoSoft.SetActive (false);
		} else if (Player.smallChestsReady > 0) {
			recommendPanel.SetActive (true);
			bigChestReadyToOpenPanel.SetActive (false);
			smallChestReadyToOpenPanel.SetActive (true);
			heroReadyToUpgradePanel.SetActive (false);
			itemReadyToUpgradePanel.SetActive (false);
			bigChestAlmostReadyPanel.SetActive (false);			
			heroReadyToUpgradePanelNoSoft.SetActive (false);
			itemReadyToUpgradePanelNoSoft.SetActive (false);
		} else if (cheapestHeroReadyForUpgrade () != null) {
			Hero hero = cheapestHeroReadyForUpgrade ();
			recommendPanel.SetActive (true);
			bigChestReadyToOpenPanel.SetActive (false);
			smallChestReadyToOpenPanel.SetActive (false);
			heroReadyToUpgradePanel.SetActive (true);
			itemReadyToUpgradePanel.SetActive (false);
			bigChestAlmostReadyPanel.SetActive (false);
			heroReadyToUpgradePanelNoSoft.SetActive (false);
			itemReadyToUpgradePanelNoSoft.SetActive (false);
			heroReadyToUpgradePanel.GetComponentsInChildren<Image> () [0].sprite = Resources.Load<Sprite> ("UI/HeroIcons/" + hero.name);
			heroReadyToUpgradePanel.GetComponentsInChildren<Text> () [0].text = "Улучшите героя " + hero.name + " до уровня " + (hero.level + 1);
		} else if (cheapestItemReadyForUpgrade () != null) {
			Item item = cheapestItemReadyForUpgrade ();
			recommendPanel.SetActive (true);
			bigChestReadyToOpenPanel.SetActive (false);
			smallChestReadyToOpenPanel.SetActive (false);
			heroReadyToUpgradePanel.SetActive (false);
			itemReadyToUpgradePanel.SetActive (true);
			bigChestAlmostReadyPanel.SetActive (false);
			heroReadyToUpgradePanelNoSoft.SetActive (false);
			itemReadyToUpgradePanelNoSoft.SetActive (false);
			itemReadyToUpgradePanel.GetComponentsInChildren<Image> () [0].sprite = Resources.Load<Sprite> ("UI/ItemsImg/" + item.name);
			itemReadyToUpgradePanel.GetComponentsInChildren<Text> () [0].text = "Улучшите " + item.name + " до уровня " + (item.level + 1);
		} else if (Player.bigChestsReady > 0 && Player.bigChestProgress < 3) {
			recommendPanel.SetActive (true);
			bigChestReadyToOpenPanel.SetActive (false);
			smallChestReadyToOpenPanel.SetActive (false);
			heroReadyToUpgradePanel.SetActive (false);
			itemReadyToUpgradePanel.SetActive (false);
			bigChestAlmostReadyPanel.SetActive (true);
			heroReadyToUpgradePanelNoSoft.SetActive (false);
			itemReadyToUpgradePanelNoSoft.SetActive (false);
			bigChestAlmostReadyPanel.GetComponentsInChildren<Text> () [1].text = Player.bigChestProgress + "/3";
		} else if (cheapestHeroReadyForUpgradeNoSoft () != null) {
			Hero hero = cheapestHeroReadyForUpgradeNoSoft ();
			recommendPanel.SetActive (true);
			bigChestReadyToOpenPanel.SetActive (false);
			smallChestReadyToOpenPanel.SetActive (false);
			heroReadyToUpgradePanel.SetActive (false);
			itemReadyToUpgradePanel.SetActive (false);
			bigChestAlmostReadyPanel.SetActive (false);
			heroReadyToUpgradePanelNoSoft.SetActive (true);
			itemReadyToUpgradePanelNoSoft.SetActive (false);
			heroReadyToUpgradePanelNoSoft.GetComponentsInChildren<Image> () [0].sprite = Resources.Load<Sprite> ("UI/HeroIcons/" + hero.name);
			heroReadyToUpgradePanelNoSoft.GetComponentsInChildren<Text> () [0].text = "Улучшите героя " + hero.name + " до уровня " + (hero.level + 1);
		} else if (cheapestItemReadyForUpgradeNoSoft () != null) {
			Item item = cheapestItemReadyForUpgradeNoSoft ();
			recommendPanel.SetActive (true);
			bigChestReadyToOpenPanel.SetActive (false);
			smallChestReadyToOpenPanel.SetActive (false);
			heroReadyToUpgradePanel.SetActive (false);
			itemReadyToUpgradePanel.SetActive (false);
			bigChestAlmostReadyPanel.SetActive (false);
			heroReadyToUpgradePanelNoSoft.SetActive (false);
			itemReadyToUpgradePanelNoSoft.SetActive (true);
			itemReadyToUpgradePanelNoSoft.GetComponentsInChildren<Image> () [0].sprite = Resources.Load<Sprite> ("UI/ItemsImg/" + item.name);
			itemReadyToUpgradePanelNoSoft.GetComponentsInChildren<Text> () [0].text = "Улучшите " + item.name + " до уровня " + (item.level + 1);
		} else {
			recommendPanel.SetActive (false);

		}
	}

	private Hero cheapestHeroReadyForUpgrade() {
		List<Hero> heroesReadyForUpgrade = new List<Hero> ();
		foreach (Slot slot in Player.dropTeam) {
			if (slot.hero != null) {
				Hero currenthero = slot.hero;
				int requiredFragments = Model.heroLevelUpCostFragm [currenthero.level - 1];
				int requiredSoft = Model.heroLevelUpCostSoft [currenthero.level - 1];
				if (Player.fragmentInventory.ContainsKey (currenthero.name) && Player.fragmentInventory [currenthero.name] >= requiredFragments && Player.softCurrency >= requiredSoft) {
					heroesReadyForUpgrade.Add (currenthero);
				}
			}
		}
		if (heroesReadyForUpgrade.Count == 0)
			return null;
		else if (heroesReadyForUpgrade.Count == 1)
			return heroesReadyForUpgrade [0];
		else {
			Hero cheapest = heroesReadyForUpgrade [0];
			for (int i = 1; i < heroesReadyForUpgrade.Count; i++) {
				if (Model.heroLevelUpCostSoft [heroesReadyForUpgrade [i].level - 1] < Model.heroLevelUpCostSoft [cheapest.level - 1]) {
					cheapest = heroesReadyForUpgrade [i];
				}
			}
			return cheapest;
		}
	}

	private Item cheapestItemReadyForUpgrade() {
		List<Item> itemsReadyForUpgrade = new List<Item> ();
		foreach (Slot slot in Player.dropTeam) {
			if (slot.hero != null) {
				Hero currenthero = slot.hero;
				for (int i = 0; i < currenthero.equippeditems.Length; i++) {
					if (currenthero.equippeditems [i] != null) {
						Item currentItem = currenthero.equippeditems [i];
						int currentItemUpgCount = 0;
						foreach (Item item in Player.inventory) {
							if (item.name == currentItem.name && item.level == 1 && item.isEquip == false) {
								currentItemUpgCount++;
							}
						}
						if (currentItemUpgCount >= Model.heroLevelUpCostFragm [currentItem.level - 1] && Player.softCurrency >= Model.heroLevelUpCostSoft[currentItem.level - 1])
							itemsReadyForUpgrade.Add (currentItem);
					}
				}
			}
		}
		if (itemsReadyForUpgrade.Count == 0)
			return null;
		else if (itemsReadyForUpgrade.Count == 1)
			return itemsReadyForUpgrade [0];
		else {
			Item cheapest = itemsReadyForUpgrade [0];
			for (int i = 1; i < itemsReadyForUpgrade.Count; i++) {
				if (Model.heroLevelUpCostSoft [itemsReadyForUpgrade [i].level - 1] < Model.heroLevelUpCostSoft [cheapest.level - 1]) {
					cheapest = itemsReadyForUpgrade [i];
				}
			}
			return cheapest;
		}
	}

	private Hero cheapestHeroReadyForUpgradeNoSoft() {
		List<Hero> heroesReadyForUpgrade = new List<Hero> ();
		foreach (Slot slot in Player.dropTeam) {
			if (slot.hero != null) {
				Hero currenthero = slot.hero;
				int requiredFragments = Model.heroLevelUpCostFragm [currenthero.level - 1];
				int requiredSoft = Model.heroLevelUpCostSoft [currenthero.level - 1];
				if (Player.fragmentInventory.ContainsKey (currenthero.name) && Player.fragmentInventory [currenthero.name] >= requiredFragments) {
					heroesReadyForUpgrade.Add (currenthero);
				}
			}
		}
		if (heroesReadyForUpgrade.Count == 0)
			return null;
		else if (heroesReadyForUpgrade.Count == 1)
			return heroesReadyForUpgrade [0];
		else {
			Hero cheapest = heroesReadyForUpgrade [0];
			for (int i = 1; i < heroesReadyForUpgrade.Count; i++) {
				if (Model.heroLevelUpCostSoft [heroesReadyForUpgrade [i].level - 1] < Model.heroLevelUpCostSoft [cheapest.level - 1]) {
					cheapest = heroesReadyForUpgrade [i];
				}
			}
			return cheapest;
		}
	}

	private Item cheapestItemReadyForUpgradeNoSoft() {
		List<Item> itemsReadyForUpgrade = new List<Item> ();
		foreach (Slot slot in Player.dropTeam) {
			if (slot.hero != null) {
				Hero currenthero = slot.hero;
				for (int i = 0; i < currenthero.equippeditems.Length; i++) {
					if (currenthero.equippeditems [i] != null) {
						Item currentItem = currenthero.equippeditems [i];
						int currentItemUpgCount = 0;
						foreach (Item item in Player.inventory) {
							if (item.name == currentItem.name && item.level == 1 && item.isEquip == false) {
								currentItemUpgCount++;
							}
						}
						if (currentItemUpgCount >= Model.heroLevelUpCostFragm [currentItem.level - 1])
							itemsReadyForUpgrade.Add (currentItem);
					}
				}
			}
		}
		if (itemsReadyForUpgrade.Count == 0)
			return null;
		else if (itemsReadyForUpgrade.Count == 1)
			return itemsReadyForUpgrade [0];
		else {
			Item cheapest = itemsReadyForUpgrade [0];
			for (int i = 1; i < itemsReadyForUpgrade.Count; i++) {
				if (Model.heroLevelUpCostSoft [itemsReadyForUpgrade [i].level - 1] < Model.heroLevelUpCostSoft [cheapest.level - 1]) {
					cheapest = itemsReadyForUpgrade [i];
				}
			}
			return cheapest;
		}
	}

	public void openUpgradeHeroPanel(bool noSoft) {
		if (noSoft) {
			Model.selectedHero = cheapestHeroReadyForUpgradeNoSoft ();
		} else {
			Model.selectedHero = cheapestHeroReadyForUpgrade ();
		}
		Object.FindObjectOfType<LevelManager> ().LoadScene ("ManageHero");
	}

	public void openUpgradeItemPanel(bool noSoft) {
		if (noSoft) {
			Model.selectedItem = cheapestItemReadyForUpgradeNoSoft (); 
		} else {
			Model.selectedItem = cheapestItemReadyForUpgrade ();
		}
		foreach (Slot slot in Player.dropTeam) {
			if (slot.hero != null) {
				for (int i = 0; i < slot.hero.equippeditems.Length; i++) {
					if (slot.hero.equippeditems [i] != null && slot.hero.equippeditems[i] == Model.selectedItem) {
						Model.selectedHero = slot.hero;
						break;
					}
				}
			}
		}
		Object.FindObjectOfType<LevelManager> ().LoadScene ("ManageHero");


	}
}
