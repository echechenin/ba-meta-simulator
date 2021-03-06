﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeroView : MonoBehaviour {
	public LevelManager levelManager;
	//for visual
	public Text softCurrencyLabel;
	public Text hardCurrencyLabel;
	public Text ratingLabel;
	public Text leagueLabel;

	public Text heroName;
	public Image heroImage;
	public Image heroFragments;

	private List<Hero> heroesInInventory = new List<Hero>();
	private List<string> availableForBuy = new List<string>();

	public GameObject changeButton;
	public GameObject buyButton;
	public Text buyButtonText;

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
		if (Model.selectedHeroToBuy != null) {
			openHero (0);
		} else {
			openHero (0);
		}
	}

	private void Update() {
		softCurrencyLabel.text = Player.softCurrency.ToString ();
		hardCurrencyLabel.text = Player.hardCurrency.ToString ();
		ratingLabel.text = Player.rating.ToString ();
		leagueLabel.text = "Лига " + Player.league.ToString ();
	}
		
	public void showNextHero() {
		index++;
		if (index >= heroesInInventory.Count + availableForBuy.Count)
			index = 0;
		openHero (index);
	}

	public void showPreviousHero() {
		index--;
		if (index < 0)
			index = heroesInInventory.Count + availableForBuy.Count - 1;
		openHero (index);
	}

	private void openHero(int index) {
		if (index < heroesInInventory.Count) {
			heroName.text = heroesInInventory [index].name;
			heroImage.sprite = Resources.Load<Sprite> ("UI/HeroImgs/" + heroesInInventory [index].name);
			changeButton.SetActive (true);
			buyButton.SetActive (false);
		} else if (index < (heroesInInventory.Count + availableForBuy.Count	)) {
			heroName.text = availableForBuy [index - heroesInInventory.Count];
			heroImage.sprite = Resources.Load<Sprite> ("UI/HeroImgs/" + availableForBuy [index - heroesInInventory.Count]);
			heroFragments.sprite = Resources.Load<Sprite> ("UI/HeroIcons/" + availableForBuy [index - heroesInInventory.Count]);
			changeButton.SetActive (false);
			buyButton.SetActive (true);
			if (Player.fragmentInventory.ContainsKey(availableForBuy[index-heroesInInventory.Count])) {
				buyButtonText.text = "Купить " + Player.fragmentInventory[availableForBuy[index-heroesInInventory.Count]].ToString() + "/" + Model.heroBuyCostFragm[0].ToString();
			} else {
				buyButtonText.text = "Купить " + "0/" + Model.heroBuyCostFragm[0].ToString();
			}
		}
	}

	public void changeHero() {
		Player.ChangeHeroInDropteam (Model.selectedHero, heroesInInventory [index]);
		levelManager.LoadScene ("Lobby");
	}

	public void buyHero() {
		if (Player.BuyHeroInDropTeam (Model.selectedHero, new Hero (availableForBuy [index - heroesInInventory.Count]))) {
			levelManager.LoadScene ("Lobby");
		}
	}
}
