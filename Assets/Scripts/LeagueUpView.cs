using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeagueUpView : MonoBehaviour {

	public Text title;
	public GameObject[] newItems;

	public Text smallChestFragmentsBefore;
	public Text smallChestFragmentsAfter;
	public Text smallChestItemsBefore;
	public Text smallChestItemsAfter;
	public Text bigChestFragmentsBefore;
	public Text bigChestFragmentsAfter;
	public Text bigChestItemsBefore;
	public Text bigChestItemsAfter;

	public Text incomeBonus;

	void Start () {
		switch (Player.league) {
		case 2:
			title.text = "Вы перешли в Серебряную лигу!";
			break;
		case 3:
			title.text = "Вы перешли в Золотую лигу!";
			break;
		case 4: 
			title.text = "Вы перешли в Платиновую лигу!";
			break;
		case 5:
			title.text = "Вы перешли в Алмазную лигу!";
			break;
		case 6:
			title.text = "Вы перешли в Мастер лигу!";
			break;
		case 7:
			title.text = "Вы перешли в Легендарную лигу!";
			break;
		}

		List<ItemDefinition> items = new List<ItemDefinition>();
		foreach (ItemDefinition item in Model.itemsDefs) {
			if (item.league == Player.league) {
				items.Add (item);
			}
		}
		for (int i = 0; i < items.Count; i++) {
			newItems [i].SetActive (true);
			newItems [i].GetComponentsInChildren<Image> () [0].sprite = Resources.Load<Sprite> ("UI/ItemsImg/" + items[i].name);
			newItems [i].GetComponent<LeagueUpItemNameScript> ().itemName.text = items [i].name;
			if (i == 7)
				break;
		}


		int[] smallChestRewardsBefore = calculateItemsFromChest (Player.league-1, false);
		int[] bigChestRewardsBefore = calculateItemsFromChest (Player.league-1, true);
		int[] smallChestRewardsAfter = calculateItemsFromChest (Player.league, false);
		int[] bigChestRewardsAfter = calculateItemsFromChest (Player.league, true);

		smallChestFragmentsBefore.text = smallChestRewardsBefore[0] + "-" + smallChestRewardsBefore[1];
		smallChestFragmentsAfter.text = smallChestRewardsAfter [0] + "-" + smallChestRewardsAfter [1];
		smallChestItemsBefore.text = smallChestRewardsBefore [2] + "-" + smallChestRewardsBefore [3];
		smallChestItemsAfter.text = smallChestRewardsAfter [2] + "-" + smallChestRewardsAfter [3];

		bigChestFragmentsBefore.text = bigChestRewardsBefore [0] + "-" + bigChestRewardsBefore [1];
		bigChestFragmentsAfter.text = bigChestRewardsAfter [0] + "-" + bigChestRewardsAfter [1];
		bigChestItemsBefore.text = bigChestRewardsBefore [2] + "-" + bigChestRewardsBefore [3];
		bigChestItemsAfter.text = bigChestRewardsAfter [2] + "-" + bigChestRewardsAfter [3];

		incomeBonus.text = "+ " + Mathf.FloorToInt ((Model.rewardCoef [Player.league] / Model.rewardCoef [Player.league - 1] - 1) * 100) + "% награда за бой";

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
