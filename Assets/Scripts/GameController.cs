using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController:MonoBehaviour {

	private static GameController gameController = null;

	public static GameController Instance {
		get
		{
			return gameController;
		}
	}

	private void Awake() {
		if (gameController == null) { 
			gameController = this;
			Model.Init();
			Player.Init();
			DontDestroyOnLoad (this.gameObject);
		}
	}
}
