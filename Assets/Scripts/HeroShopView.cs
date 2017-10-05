using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroShopView : MonoBehaviour {
	//for visual
	public Text softCurrencyLabel;
	public Text hardCurrencyLabel;
	public Text ratingLabel;
	public Text leagueLabel;
	//herolist
	public GameObject contentList;
	public GameObject heroShopCardPrefab;

	private List<string> availableForBuy = new List<string>();

	// Use this for initialization
	void Start () {
		foreach (KeyValuePair<string,int> pair in Model.heroInLeague) {
			//вьюшка фрагментов
			GameObject heroShopCardGO = Instantiate (heroShopCardPrefab, contentList.transform);
			HeroShopCardView heroShopCard = heroShopCardGO.GetComponent<HeroShopCardView> ();
			//количество шардов данного типа у игрока
			int currentShards = 0;
			foreach (KeyValuePair<string,int> shardsCount in Player.fragmentInventory) {
				if (shardsCount.Key == pair.Key) {
					currentShards = shardsCount.Value;
				}
			}
			//инитим карточку
			heroShopCard.Init (pair.Key, pair.Value, Model.heroBuyCostFragm[0],currentShards);
		}
	}
	
	private void Update() {
		softCurrencyLabel.text = Player.softCurrency.ToString ();
		hardCurrencyLabel.text = Player.hardCurrency.ToString ();
		ratingLabel.text = Player.rating.ToString ();
		leagueLabel.text = "Лига " + Player.league.ToString ();
	}
}