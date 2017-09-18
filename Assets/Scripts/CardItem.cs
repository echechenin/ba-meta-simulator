using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour {

	private Image cardImage;
	private Text cardText;

	// Use this for initialization
	void Start () {
		cardImage = GetComponent<Image> ();
		cardText = GetComponentsInChildren<Text> ()[0];
	}
	
	public void SetCardItem(Item item, int cardCount)
	{
		cardImage = GetComponent<Image> ();
		cardText = GetComponentsInChildren<Text> ()[0];
		string iconPath = "UI/ItemsImg/" + item.name;
		cardImage.sprite = Resources.Load<Sprite>("UI/ItemsImg/"+item.name);
		cardText.text = "x"+cardCount.ToString ();
	}
}
