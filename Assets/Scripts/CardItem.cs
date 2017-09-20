using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour {
	public GameObject buttons;

//	private Image cardImage;
	private Text cardText;

	// Use this for initialization
	void Start () {
//		cardImage = GetComponent<Image> ();
		cardText = GetComponentsInChildren<Text> ()[0];
	}
	
	public void SetCardItem(Item item, int cardCount)
	{
//		cardImage = GetComponent<Image> ();
		cardText = GetComponentsInChildren<Text> ()[0];
		string iconPath = "UI/ItemsImg/" + item.name;
//		cardImage.sprite = Resources.Load<Sprite>(iconPath);
		cardText.text = "x"+cardCount.ToString ();
	}

	public void openMenu() {
		buttons.SetActive (true);
	}
}
