using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestsController : MonoBehaviour {
	public GameObject chestRewardPopup;
	public GameObject itemCardPrefab;
	public int itemCount;
	public string[] itemArr;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenChest()
	{
		chestRewardPopup.SetActive (true);
		GameObject content = GameObject.Find ("Content");
		foreach (Transform child in content.transform)
		{
				Destroy (child.gameObject);
		}
		for(int i = 0; i < itemCount; i++)
		{
			GameObject itemCardButton = Instantiate (itemCardPrefab, content.transform);
			CardItem cardItem = itemCardButton.GetComponent<CardItem> ();
			Item item = new Item (itemArr [Random.Range (0, 9)]);
			int value = Random.Range (1, 13);
			cardItem.SetCardItem (item, value);
		}
	}
}
