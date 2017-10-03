using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour {
	public GameObject buttons;
	public Text cardName;
	public Text cardLevel;

	private Image cardImage;
	private Text cardText;
	private Item itemRef;

	// Use this for initialization
	void Start () {
		cardImage = GetComponent<Image> ();
		cardText = GetComponentsInChildren<Text> ()[0];
	}
	
	public void SetCardItem(Item item, int cardCount)
	{
		cardName.text = item.name;
		cardLevel.text = item.level.ToString();
		cardImage = GetComponent<Image> ();
		cardText = GetComponentsInChildren<Text> ()[0];
		string iconPath = "UI/ItemsImg/" + item.name;
		cardImage.sprite = Resources.Load<Sprite>(iconPath);
		cardText.text = "x"+cardCount.ToString ();
		if (cardCount == 0)
			cardText.text = "";	
		itemRef = item;
	}

	public void SetCardItem(string hero, int cardCount) 
	{
		cardName.text = hero;
		cardLevel.text = "";
		cardImage = GetComponent<Image> ();
		cardText = GetComponentsInChildren<Text> () [0];
		string iconPath = "UI/HeroIcons/" + hero;
		cardImage.sprite = Resources.Load<Sprite> (iconPath);
		cardText.text = "x" + cardCount.ToString ();
		if (cardCount == 0)
			cardText.text = "";
		
	}

	public void openMenu() {
		buttons.SetActive (!buttons.activeSelf);
		if (cardLevel.text == "1") {
			if (buttons.transform.Find ("DisassmButton") != null) {
				buttons.transform.Find ("DisassmButton").gameObject.SetActive (false);
			}
		}
	}

	public void equipItem()
	{
		GameObject.FindObjectOfType<InventoryController> ().EquipItemInSlot (itemRef);
	}

	public void disassembleItem()
	{
		if(itemRef.level > 1) 
			GameObject.FindObjectOfType<InventoryController> ().DisassembleItem (itemRef);
	}
}
