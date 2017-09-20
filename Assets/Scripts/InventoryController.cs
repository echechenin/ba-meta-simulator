using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public GameObject InventoryDialog;
	public GameObject itemCardPrefab;
	public GameObject inventoryTitle;

	public void OpenInventoryForSlot(string value)
	{
		ItemType type = (ItemType) Enum.Parse(typeof(ItemType), value);
		InventoryDialog.SetActive (true);
		GameObject content = GameObject.Find ("Content");
		GameObject.FindObjectOfType<Text>().text = type.ToString();
		foreach (Transform child in content.transform)
		{
			Destroy (child.gameObject);
		}
		foreach (Item item in Player.inventory.Values) 
		{
			if (item.itemDefinition.type == type) 
			{
				GameObject itemCardButton = Instantiate (itemCardPrefab, content.transform);
				CardItem cardItem = itemCardButton.GetComponent<CardItem> ();
				cardItem.SetCardItem (item, 1);
			}
		}
	}

	public void CloseInventory()
	{
		InventoryDialog.SetActive (false);
	}
}