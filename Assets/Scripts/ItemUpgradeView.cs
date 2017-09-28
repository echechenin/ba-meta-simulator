using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUpgradeView : MonoBehaviour {

	public InventoryController inventoryController;
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
		itemNameTitle.text = item.name;
		itemImage.sprite = Resources.Load<Sprite> ("UI/ItemsImg/" + item.name);
		itemImageSmall.sprite = Resources.Load<Sprite> ("UI/ItemsImg/" + item.name);
		dialogTitle.text = "Улучшить <b>" + item.name + "</b> до <b>" + (item.level + 1).ToString () + "</b> уровня";
		itemLevel.text = "Текущий уровень: " + item.level.ToString();
		itemRequiredSourceItems.text = item.itemDefinition.partsForUpgrade [item.level] + " / " + inventoryController.GetSourceItemCount (item.name);

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

	}
}
