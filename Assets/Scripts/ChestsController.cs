﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChestsController : MonoBehaviour {
	public GameObject chestRewardPopup;
	public GameObject itemCardPrefab;

	//public int itemCount;
	//public string[] itemArr;

	//Словари - полные инвентари игроков + отсутствующие у игрока предметы
	private Dictionary<string,int> totalFragmentsCount = new Dictionary<string,int>();
	private Dictionary<string,int> totalItemsCount = new Dictionary<string, int>();

	//списки сгенерированных предметов (без количества)
	private List<string> resultFragments = new List<string>();
	private List<string> resultItems = new List<string>();

	private List<int> resultFragmentsCount = new List<int>();
	private List<int> resultItemsCount = new List<int>();


	void Awake() {
		//подсчет словарей
		foreach (KeyValuePair<string,int> pair in Model.heroInLeague) {
			if ((pair.Value <= Player.league) && (!Player.totalFragmentsCount.ContainsKey (pair.Key))) {
				totalFragmentsCount.Add (pair.Key, 0);
			} else if (pair.Value <= Player.league) {
				totalFragmentsCount.Add (pair.Key, Player.totalFragmentsCount [pair.Key]);
			}
		}
		foreach (ItemDefinition item in Model.itemsDefs) {
			if ((item.league <= Player.league) && (!Player.totalItemsCount.ContainsKey (item.name))) {
				totalItemsCount.Add (item.name, 0);
			} else if (item.league <= Player.league) {
				totalItemsCount.Add (item.name, Player.totalItemsCount [item.name]);
			}
		}
	}

	public void OpenSmallChest() {
		//rolling counts
		resultFragmentsCount.Add(selectRandomFromFloat(Model.smallChestRewards[Player.league][0]));
		for (int i = 1; i < Model.smallChestRewards[Player.league].Length; i++) {
			resultItemsCount.Add (selectRandomFromFloat (Model.smallChestRewards [Player.league][i]));
		}



		float f = Random.Range(0f, 1f);
		if (f < 0.5f) {
			SelectLowestFragments (1);
		} else {
			SelectRandomFragments (1);
		}
		for (int i = 0; i < 4; i++) {
			if (resultItemsCount [i] > 0) {
				f = Random.Range (0f, 1f);
				if (f < 0.5f) {
					SelectLowerItems (1, i+1);
				} else {
					SelectRandomItems (1, i+1);
				}
			}
		}
		string fulllist = "";
		for (int i = 0; i < resultFragments.Count; i++) {
			fulllist += " " + resultFragments [i] + " - " + resultFragmentsCount[i] + "\t";
		}
		for (int i = 0; i < resultItems.Count; i++) {
			fulllist += " " + resultItems [i] + " - " + resultItemsCount[i] + "\t";
		}
		Debug.Log (fulllist);
		OpenChest();
		Player.smallChestsReady--;
	}

	public void OpenBigChest() {
		int chestFragmentRewards = selectRandomFromFloat (Model.bigChestRewards [Player.league] [0]);
		int countFirst = Mathf.FloorToInt(chestFragmentRewards*Random.Range(0.4f,0.6f));

		resultFragmentsCount.Add(countFirst);
		resultFragmentsCount.Add(chestFragmentRewards-countFirst);

		for (int i = 1; i < Model.bigChestRewards[Player.league].Length; i++) {
			if (i == 1) {
				int chestItemRewards = selectRandomFromFloat (Model.bigChestRewards [Player.league] [i]);
				countFirst = Mathf.FloorToInt(chestItemRewards*Random.Range(0.4f,0.6f));
				resultItemsCount.Add (countFirst);
				resultItemsCount.Add (chestItemRewards - countFirst);
			} else {
				resultItemsCount.Add (selectRandomFromFloat (Model.bigChestRewards [Player.league] [i]));
			}
		}

		SelectLowestFragments (1);
		SelectRandomFragments (1);

		for (int i = 0; i < resultItemsCount.Count; i++) {
			if (resultItemsCount [i] > 0) {
				switch (i) {
				case 0:
					SelectLowerItems (1, 1);
					SelectRandomItems (1, 1);
					i++;
					break;
				case 2:
				case 3:
				case 4:
					float f = Random.Range (0f, 1f);
					if (f < 0.5f) {
						SelectLowerItems (1, i);
					} else {
						SelectRandomItems (1, i);
					}
					break;
				}
			
			}
		}
		string fulllist = "";
		for (int i = 0; i < resultFragments.Count; i++) {
			fulllist += " " + resultFragments [i] + " - " + resultFragmentsCount[i] + "\t";
		}
		for (int i = 0; i < resultItems.Count; i++) {
			fulllist += " " + resultItems [i] + " - " + resultItemsCount[i] + "\t";
		}
		Debug.Log (fulllist);
		OpenChest();
		Player.bigChestsReady--;
		Player.bigChestProgress = 0;
	}


	private int selectRandomFromFloat(float f) {
		//string s = Mathf.Floor(f) + "-" + Mathf.Ceil(f);
		float random = Random.Range(Mathf.Floor(f),Mathf.Ceil(f));
		//s += "  randomed - " + random;
		if (random > f) {
			//Debug.Log(s + " returned " + Mathf.FloorToInt(f));
			return Mathf.FloorToInt(f);
		} else {
			//Debug.Log(s + " returned " + Mathf.CeilToInt(f));
			return Mathf.CeilToInt(f);
		}
	}

	private void SelectLowestFragments(int count) {
		//временный массив для count*2 самых слабых предметов
		List<string> minimalFragments = new List<string> ();
		for (int i = 0; i < count * 2; i++) {
			string minimal = "";
			int min = 99999;
			foreach (KeyValuePair<string,int> pair in totalFragmentsCount) {
				if (pair.Value < min) {
					minimal = pair.Key;
					min = pair.Value;
				}
			}
			if (minimal != "") {
				minimalFragments.Add (minimal);
				totalFragmentsCount.Remove (minimal);
			}
		}
		//выбираем count нужных из массива выше
		for (int i = 0; i < count; i++) {
			int random = Random.Range (0, minimalFragments.Count);
			resultFragments.Add (minimalFragments [random]);
			totalFragmentsCount.Remove (minimalFragments [random]);
			minimalFragments.Remove(minimalFragments[random]);
		}
	}

	private void SelectRandomFragments(int count) {
		List<string> fragments = new List<string>();
		foreach (KeyValuePair<string,int> pair in totalFragmentsCount) {
			fragments.Add (pair.Key);
		}
		for (int i = 0; i < count; i++) {
			int random = Random.Range (0, fragments.Count);	
			resultFragments.Add (fragments [random]);
			totalFragmentsCount.Remove (fragments[random]);
			fragments.Remove (fragments[random]);
		}
	}

	private void SelectLowerItems(int count, int tier) {
		//временный массив для count*2 самых слабых предметов
		List<string> minimalItems = new List<string> ();
		for (int i = 0; i < count * 2; i++) {
			string minimal = "";
			int min = 99999;
			foreach (KeyValuePair<string,int> pair in totalItemsCount) {
				if ((Model.getItemDef(pair.Key).tier == tier) && (pair.Value < min)) {
					minimal = pair.Key;
					min = pair.Value;
				}
			}
			if (minimal != "") {
				minimalItems.Add (minimal);
				totalItemsCount.Remove (minimal);
			}
		}
		//выбираем count нужных из массива выше
		for (int i = 0; i < count; i++) {
			int random = Random.Range (0, minimalItems.Count);
			resultItems.Add (minimalItems [random]);
			totalItemsCount.Remove (minimalItems [random]);
			minimalItems.Remove(minimalItems[random]);
		}
	} 

	private void SelectRandomItems(int count, int tier) {
		List<string> items = new List<string>();
		foreach (KeyValuePair<string,int> pair in totalItemsCount) {
			if (Model.getItemDef (pair.Key).tier == tier) {
				items.Add (pair.Key);
			}
		}
		for (int i = 0; i < count; i++) {
			int random = Random.Range (0, items.Count);	
			resultItems.Add (items [random]);
			totalItemsCount.Remove (items[random]);
			items.Remove (items[random]);
		}
	}


	//public void OpenChest()
	private void OpenChest()
	{
		chestRewardPopup.SetActive (true);
		GameObject content = GameObject.Find ("Content");
		foreach (Transform child in content.transform)
		{
				Destroy (child.gameObject);
		}

		for (int i = 0; i < resultFragments.Count; i++) {
			//вьюшка фрагментов
			GameObject itemCardButton = Instantiate (itemCardPrefab, content.transform);
			CardItem cardItem = itemCardButton.GetComponent<CardItem> ();
			cardItem.SetCardItem (resultFragments [i], resultFragmentsCount [i]);
			//добавление в инвентарь
			if (Player.fragmentInventory.ContainsKey (resultFragments [i])) {
				Player.fragmentInventory [resultFragments [i]] += resultFragmentsCount [i];
			} else {
				Player.fragmentInventory.Add (resultFragments [i], resultFragmentsCount [i]);
			}
			if (Player.totalFragmentsCount.ContainsKey(resultFragments[i])) {
				Player.totalFragmentsCount [resultFragments [i]] += resultFragmentsCount [i];
			} else {
				Player.totalFragmentsCount.Add (resultFragments [i], resultFragmentsCount [i]);
			}
		}

		for (int i = 0; i < resultItems.Count; i++) {
			//вьюшка предметов
			GameObject itemCardButton = Instantiate (itemCardPrefab, content.transform);
			CardItem cardItem = itemCardButton.GetComponent<CardItem> ();
			Item item = new Item (resultItems [i]);
			int value = resultItemsCount [i];
			cardItem.SetChestCardItem (item, value);
			//добавление в инвентарь
			for (int j = 0; j < resultItemsCount [i]; j++) {
				Player.inventory.Add (new Item (resultItems [i]));
			}
			if (Player.totalItemsCount.ContainsKey (resultItems [i])) {
				Player.totalItemsCount [resultItems [i]] += resultItemsCount [i];
			} else {
				Player.totalItemsCount.Add (resultItems [i], resultItemsCount [i]);
			}


		}

		/*for (int i = 0; i < itemCount; i++)
		{
			GameObject itemCardButton = Instantiate (itemCardPrefab, content.transform);
			CardItem cardItem = itemCardButton.GetComponent<CardItem> ();
			//Item item = new Item (itemArr [Random.Range (0, 9)]);
			//int value = Random.Range (1, 13);
			cardItem.SetCardItem (item, value);
		}*/
	}
}
