using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleRewardView : MonoBehaviour {
	public Text battleResult;
	public Text softRewardValue;
	public Text ratingRewardValue;

	private bool result;
	private int softReward;
	private int ratingReward;


	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = Object.FindObjectOfType<LevelManager> ();

		if (Random.value < 0.5) {
			result = true;
		} else {
			result = false;
		}
			
		calculatingRewards ();
		Statistics.battles += 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (result) {
			battleResult.text = "Victory";
		} else {
			battleResult.text = "Lose";
		}
	}

	private void calculatingRewards() {
		if (result) {
			softReward = Mathf.FloorToInt(1142 * Model.rewardCoef [Player.league] * 1.5f * Random.Range(0.8f,1.2f));
			ratingReward = 30;
			ratingRewardValue.text = "+ " + ratingReward.ToString ();
			if (Player.bigChestsReady > 0) {
				Player.bigChestProgress++;
			}
		} else {
			softReward = Mathf.FloorToInt(1142 * Model.rewardCoef [Player.league] * Random.Range(0.8f,1.2f));
			ratingReward -= Mathf.FloorToInt(30 * Model.leagueRatingLostCoef [Player.league]);
			ratingRewardValue.text = ratingReward.ToString ();
		}
		softRewardValue.text = "+ " + softReward.ToString ();
		Player.softCurrency += softReward;
		Player.rating += ratingReward;
		if (Player.rating < 0) {
			Player.rating = 0;
		}
	}

	public void openNextScene() {

		int newleague = 1;
		foreach (KeyValuePair<int, int> pair in Model.leagueRating) {
			if (Player.rating < pair.Key) {
				newleague = pair.Value - 1;
				break;
			}
		}
		if (newleague > Player.league) {
			Player.league = newleague;
			levelManager.LoadScene ("LeagueUp");
		} else {
			levelManager.LoadScene ("Lobby");
		}
	}
}
	