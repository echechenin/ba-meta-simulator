using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public GameObject InventoryDialog;
	public GameObject itemCardPrefab;
	public GameObject inventoryTitle;

	private ItemType currentInventoryFilter;
	private int currentSlotNumber;

	public void OpenInventoryForSlot(string value)
	{
		ItemType type = (ItemType) Enum.Parse(typeof(ItemType), value);
		InventoryDialog.SetActive (true);
		inventoryTitle.GetComponent<Text> ().text = value;
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
				if (itemCollectionItems.Count > 0 && IsCollectionContainNameLevelItem(itemCollectionItems,item))
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