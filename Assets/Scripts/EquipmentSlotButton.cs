using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlotButton : MonoBehaviour {

	private InventoryController inventoryController;

	private LevelManager levelManager;


	private void Awake() {
		inventoryController = Object.FindObjectOfType<InventoryController>();
		levelManager = Object.FindObjectOfType<LevelManager>();
	}

	public void openInventoryForSlot(ItemType itemType) {
		//Model.selectedSlot = slotName;
		levelManager.LoadScene ("ChangeEquip");

	}

	public void openSlot(string slotName) {
		Model.selectedSlot = slotName;
		levelManager.LoadScene ("ChangeEquip");

	}
}
