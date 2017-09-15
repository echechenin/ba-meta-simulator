using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//Singleton interpretation
	private static LevelManager levelManager = null;

	public static LevelManager Instance {
		get
		{
			return levelManager;
		}
	}

	private void Awake() {
		if (levelManager == null) { 
			levelManager = this;
			DontDestroyOnLoad (this.gameObject);
		}
	}

	public void LoadScene(string scene) {
		SceneManager.LoadScene (scene);
	}
}