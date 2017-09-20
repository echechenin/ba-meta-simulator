using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlotButton : MonoBehaviour {
	private LevelManager levelManager;

	private void Awake() {
		levelManager = Object.FindObjectOfType<LevelManager>();
	}

	public void openSlot(string slotName) {
		Model.selectedSlot = slotName;
		levelManager.LoadScene ("ChangeEquip");
	}

	public void openInventoryForSlot(ItemType itemType) {
		//Model.selectedSlot = slotName;
		levelManager.LoadScene ("ChangeEquip");

	}
}
