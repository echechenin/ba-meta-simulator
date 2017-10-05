using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroShopCardView:MonoBehaviour
{
	private string _heroName;
	private int _heroLeague;
	private int _heroCost;
	private int _currentShardCount;

	public Image heroImage;
	public Text heroNameText;
	public Text shardCountText;

	public void Init(string name, int league, int cost, int currentShard)
	{
		_heroName = name;
		_heroLeague = league;
		_heroCost = cost;
		_currentShardCount = currentShard;

		heroImage.sprite = Resources.Load<Sprite>("UI/HeroImgs/" + _heroName);
		heroNameText.text = name;
		if(Player.league >= _heroLeague)
			shardCountText.text = _heroCost.ToString () + " / " + _currentShardCount.ToString ();
		else
			shardCountText.text = "Достигни " + _heroLeague.ToString() + " лиги";
	}

	public void BuyHero()
	{
		Model.selectedHeroToBuy = _heroName;
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().LoadScene ("ChangeHero");
	}
}