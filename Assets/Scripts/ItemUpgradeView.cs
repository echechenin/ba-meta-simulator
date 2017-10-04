using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUpgradeView : MonoBehaviour {

	private Item currentItem;

	private InventoryController inventoryController;
	public Image itemImage;
	public Image itemImageSmall;

	public Text dialogTitle; 
	public Text itemNameTitle;
	public Text itemLevel;
	public Text itemRequiredSourceItems;
	public Text healthTitle;
	public Text healthBonusTitle;
	public Text strengthTitle;
	public Text strengthBonusTitle;
	public Text defenseTitle;
	public Text defenseBonusTitle;
	public Text penetrationTitle;
	public Text penetrationBonusTitle;
	public Text buttonUpgrade;

	public void Init(Item item)
	{
		inventoryController = FindObjectOfType<InventoryController> ();
		currentItem = item;
		itemNameTitle.text = item.name;
		itemImage.sprite = Resources.Load<Sprite> ("UI/ItemsImg/" + item.name);
		itemImageSmall.sprite = Resources.Load<Sprite> ("UI/ItemsImg/" + item.name);
		dialogTitle.text = "Улучшить <b>" + item.name + "</b> до <b>" + (item.level + 1).ToString () + "</b> уровня";
		itemLevel.text = "Текущий уровень: " + item.level.ToString();
		itemRequiredSourceItems.text = inventoryController.GetSourceItemCount (item.name) + " / " + item.itemDefinition.partsForUpgrade [item.level];

		healthTitle.text = item.itemDefinition.bonusHealth [item.level - 1].ToString();
		healthBonusTitle.text = "+" + (item.itemDefinition.bonusHealth [item.level] - item.itemDefinition.bonusHealth [item.level - 1]).ToString();

		strengthTitle.text = item.itemDefinition.bonusStrength [item.level - 1].ToString();
		strengthBonusTitle.text = "+" + (item.itemDefinition.bonusStrength [item.level] - item.itemDefinition.bonusStrength [item.level - 1]).ToString();

		defenseTitle.text = item.itemDefinition.bonusDefense [item.level - 1].ToString();
		defenseBonusTitle.text = "+" + (item.itemDefinition.bonusDefense [item.level] - item.itemDefinition.bonusDefense [item.level - 1]).ToString();

		penetrationTitle.text = item.itemDefinition.bonusPenetration [item.level - 1].ToString();
		penetrationBonusTitle.text = "+" + (item.itemDefinition.bonusPenetration [item.level] - item.itemDefinition.bonusPenetration [item.level - 1]).ToString();

		buttonUpgrade.text = "Улучшить " + item.itemDefinition.softForUpgrade [item.level].ToString();
	}

	public void UpgradeCurrentItem()
	{
		Debug.Log (inventoryController.GetSourceItemCount (currentItem.name).ToString() + "/" + currentItem.itemDefinition.partsForUpgrade [currentItem.level]); 
		if ((inventoryController.GetSourceItemCount (currentItem.name) >= currentItem.itemDefinition.partsForUpgrade [currentItem.level]) && (Player.softCurrency >= currentItem.itemDefinition.softForUpgrade [currentItem.level])) 
		{
			//улучшаем предмет, вычитаем валюты и айтемы
			inventoryController.DeleteSourceItemFromInventory(currentItem.name,currentItem.itemDefinition.partsForUpgrade[currentItem.level]);
			Player.softCurrency -= currentItem.itemDefinition.softForUpgrade [currentItem.level];
			currentItem.level++;
			Model.selectedHero.calculateHeroStats ();
			//обновляем вьюхи
			if(inventoryController.InventoryDialog.activeSelf)
				inventoryController.OpenInventoryForSlot(currentItem.itemDefinition.type.ToString());
			Init (currentItem);
		} else if (inventoryController.GetSourceItemCount (currentItem.name) < currentItem.itemDefinition.partsForUpgrade [currentItem.level]) {
			Debug.Log ("Not enough source items: " + currentItem.name);
		} else if (Player.softCurrency < currentItem.itemDefinition.softForUpgrade [currentItem.level]) {
			Debug.Log ("Not enough Soft Currency");
		}
	}
}
