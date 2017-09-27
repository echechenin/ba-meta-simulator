using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestShopView : MonoBehaviour {
	public Text softCurrencyLabel;
	public Text hardCurrencyLabel;
	public Text ratingLabel;
	public Text leagueLabel;

	public Text smallChestFragments;
	public Text smallChestItems;
	public GameObject smallChestFixedHint;
	public GameObject smallChestIfRares;
	public Text smallChestNumberOfRares;
	public GameObject smallChestIfEpics;
	public Text smallChestNumberOfEpics;
	public GameObject smallChestHint;
	public GameObject smallChestButton;


	public Text bigChestFragments;
	public Text bigChestItems;
	public GameObject bigChestFixedHint;
	public GameObject bigChestIfRares;
	public Text bigChestNumberOfRares;
	public GameObject bigChestIfEpics;
	public Text bigChestNumberOfEpics;
	public GameObject bigChestHint;
	public GameObject bigChestButton;

	// Use this for initialization
	void Start () {

		int[] smallChestRewards = calculateItemsFromChest (Player.league, false);	
		int[] bigChestRewards = calculateItemsFromChest (Player.league, true);

		smallChestFragments.text = smallChestRewards[0] + "-" + smallChestRewards[1];
		smallChestItems.text = smallChestRewards [2] + "-" + smallChestRewards [3];

		if ((Mathf.FloorToInt (Model.smallChestRewards [Player.league] [2])) >= 1) {
			smallChestFixedHint.SetActive (true);
			smallChestIfRares.SetActive (true);
			smallChestNumberOfRares.text = "x" + (Mathf.FloorToInt (Model.smallChestRewards [Player.league] [2])).ToString ();
		} else {
			smallChestFixedHint.SetActive (false);
			smallChestIfRares.SetActive (false);
		}
		if ((Mathf.FloorToInt (Model.smallChestRewards [Player.league] [3])) >= 1) {
			smallChestIfEpics.SetActive (true);
			smallChestNumberOfEpics.text = "x" + (Mathf.FloorToInt (Model.smallChestRewards [Player.league] [3])).ToString ();
		} else {
			smallChestIfEpics.SetActive (false);
		}

		if (Player.smallChestsReady == 0) {
			smallChestHint.SetActive (true);
			smallChestButton.SetActive (false);
		} else {
			smallChestHint.SetActive (false);
			smallChestButton.SetActive (true);
		}

		bigChestFragments.text = bigChestRewards [0] + "-" + bigChestRewards [1];
		bigChestItems.text = bigChestRewards [2] + "-" + bigChestRewards [3];

		if ((Mathf.FloorToInt (Model.bigChestRewards [Player.league] [2])) >= 1) {
			bigChestFixedHint.SetActive (true);
			bigChestIfRares.SetActive (true);
			bigChestNumberOfRares.text = "x" + (Mathf.FloorToInt (Model.bigChestRewards [Player.league] [2])).ToString ();
		} else {
			bigChestFixedHint.SetActive (false);
			bigChestIfRares.SetActive (false);
		}
		if ((Mathf.FloorToInt (Model.bigChestRewards [Player.league] [3])) >= 1) {
			bigChestIfEpics.SetActive (true);
			bigChestNumberOfEpics.text = "x" + (Mathf.FloorToInt (Model.bigChestRewards [Player.league] [3])).ToString ();
		} else {
			bigChestIfEpics.SetActive (false);
		}
			
		if (Player.bigChestProgress < 3) {
			bigChestHint.SetActive (true);
			bigChestHint.GetComponent<Text> ().text = Player.bigChestProgress + "/3";
			bigChestButton.SetActive (false);
		} else {
			bigChestHint.SetActive (false);
			bigChestButton.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		softCurrencyLabel.text = Player.softCurrency.ToString();
		hardCurrencyLabel.text = Player.hardCurrency.ToString ();
		ratingLabel.text = Player.rating.ToString ();
		leagueLabel.text = "Лига " + Player.league.ToString ();

	}

	private int[] calculateItemsFromChest(int league, bool isBig) {
		float[] items;
		if (isBig) {
			items = Model.bigChestRewards [league];
		} else {
			items = Model.smallChestRewards [league];
		}
		int minItems = 0;
		int maxItems = 0;
		for (int i = 1; i < items.Length; i++) {
			minItems += Mathf.FloorToInt (items [i]);
			maxItems += Mathf.CeilToInt (items [i]);
		}
		return new int[] {Mathf.FloorToInt(items[0]),Mathf.CeilToInt(items[0]),minItems,maxItems};
	}
}


