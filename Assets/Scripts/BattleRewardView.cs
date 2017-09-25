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

	private Dictionary<int, int> leagueRating = new Dictionary<int, int> ();
	private Dictionary<int, float> leagueRatingLostCoef = new Dictionary<int, float>();

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = Object.FindObjectOfType<LevelManager> ();

		if (Random.value < 0.5) {
			result = true;
		} else {
			result = false;
		}


		leagueRatingLostCoef.Add (1, 0.1f);
		leagueRatingLostCoef.Add (2, 0.2f);
		leagueRatingLostCoef.Add (3, 0.3f);
		leagueRatingLostCoef.Add (4, 0.5f);
		leagueRatingLostCoef.Add (5, 0.7f);
		leagueRatingLostCoef.Add (6, 0.9f);
		leagueRatingLostCoef.Add (7, 1f);

		leagueRating.Add (100, 2);
		leagueRating.Add (250, 3);
		leagueRating.Add (2250, 4);
		leagueRating.Add (6250, 5);
		leagueRating.Add (11000, 6);
		leagueRating.Add (15000, 7);
			
		calculatingRewards ();
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
		} else {
			softReward = Mathf.FloorToInt(1142 * Model.rewardCoef [Player.league] * Random.Range(0.8f,1.2f));
			ratingReward -= Mathf.FloorToInt(30 * leagueRatingLostCoef [Player.league]);
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
		foreach (KeyValuePair<int, int> pair in leagueRating) {
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
	