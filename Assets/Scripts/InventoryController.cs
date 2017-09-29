using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public GameObject InventoryDialog;
	public GameObject itemCardPrefab;
	public Text inventoryTitle;

	private ItemType currentInventoryFilter;
	private int currentSlotNumber;
	private string currentType;

	public void OpenInventoryForSlot(string value)
	{
		ItemType type = (ItemType) Enum.Parse(typeof(ItemType), value);
		currentType = value;
		InventoryDialog.SetActive (true);
		inventoryTitle.text = value;
		GameObject content = GameObject.Find ("Content");
		GameObject.FindObjectOfType<Text>().text = type.ToString();
		foreach (Transform child in content.transform)
		{
			Destroy (child.gameObject);
		}
		List<ItemCollections> itemCollectionItems = new List<ItemCollections> ();
		foreach (Item item in Player.inventory) 
		{
			if (item.itemDefinition.type == type && !item.isEquip) 
			{
				//сравниваем каждый итем с итемами в коллекции, 
				//если есть такой же предмет с таким же уровнем, увеличиваем количество
				//если таких предметов еще не было, создаем первый
				if (itemCollectionItems.Count > 0 && IsCollectionContainNameLevelItem(itemCollectionItems,item) && !item.isEquip)
					foreach (ItemCollections itemCollection in itemCollectionItems) 
					{
						if (itemCollection.itemCollectionName == item.name && itemCollection.itemCollectionLevel == item.level) 
						{
							itemCollection.collectionCount++;
							break;
						}
					}
				else
					itemCollectionItems.Add(new ItemCollections(item.name, item.level, item, 1));
			}
		}

		foreach (ItemCollections itemCollection in itemCollectionItems) 
		{
			GameObject itemCardButton = Instantiate (itemCardPrefab, content.transform);
			CardItem cardItem = itemCardButton.GetComponent<CardItem> ();
			cardItem.SetCardItem (itemCollection.itemCollectionRef, itemCollection.collectionCount);
		}
	}

	private bool IsCollectionContainNameLevelItem(List<ItemCollections> itemCollections, Item item)
	{
		bool result = false;
		if(itemCollections.Count == 0)
			result = false;
		
		foreach(ItemCollections itemColl in itemCollections)
		{
			if(itemColl.itemCollectionName == item.name && itemColl.itemCollectionLevel == item.level)
				result = true; 
		}
		return result;
	}

	public void SetCurrentSlot(int value)
	{
		currentSlotNumber = value;
	}

	public void CloseInventory()
	{
		InventoryDialog.SetActive (false);
	}

	public void EquipItemInSlotInModel(Item item, int indexSlot)
	{
		Model.selectedHero.equipItemInModel (item, indexSlot);
		item.isEquip = true;
	}

	public void EquipItemInSlot(Item item)
	{
		Model.selectedHero.equipItem (item, currentSlotNumber);
		item.isEquip = true;
		CloseInventory ();
	}

	public void ReturnItemToInventory(Item returnedItem)
	{
		foreach (Item item in Player.inventory) 
		{
			if (returnedItem == item) 
			{
				item.isEquip = false;
			}
		}
	}

	public int GetSourceItemCount(string name)
	{
		int result = 0;
		foreach (Item item in Player.inventory) {
			if (item.name == name && item.level == 1 && !item.isEquip) {
				result++;
			}
		}
		return result;
	}

	public void DeleteSourceItemFromInventory(string name, int count)
	{
		if (GetSourceItemCount (name) >= count) {
			Debug.Log (Player.inventory.Count.ToString());
			List<Item> itemsForRemove = new List<Item> ();
			foreach (Item item in Player.inventory) {
				if (item.name == name && item.level == 1 && !item.isEquip && count > 0) {
					Debug.Log (item.name);
					itemsForRemove.Add (item);
					count--;
				}
			}
			foreach(Item item in itemsForRemove)
			{
				Player.inventory.Remove (item);
			}
			Debug.Log (Player.inventory.Count.ToString());
		}
	}

	public void DisassembleItem(Item item)
	{
		if (item.level > 1) {
			int partCount = item.itemDefinition.allPartOnLevel [item.level - 1];
			for (int i = 0; i <= partCount; i++) {
				Player.inventory.Add (new Item (item.name));
			}
			Player.inventory.Remove (item);
		}
		OpenInventoryForSlot (currentType);
	}
}

public class ItemCollections
{
	public string itemCollectionName;
	public int itemCollectionLevel;
	public Item itemCollectionRef;
	public int collectionCount;

	public ItemCollections(string name, int level, Item item, int count)
	{
		itemCollectionName = name;
		itemCollectionLevel = level;
		itemCollectionRef = item;
		collectionCount = count;
	}
}