using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsView : MonoBehaviour {
	public Text time;
	public Text sessions;
	public Text battles;

	private static StatisticsView statisticsView = null;

	public static StatisticsView Instance {
		get
		{
			return statisticsView;
		}
	}

	private void Awake() {
		if (statisticsView == null) { 
			statisticsView = this;
			DontDestroyOnLoad (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		time.text = "Суммарное время: " + Statistics.timepassed + ":00:00";
		sessions.text = "Число сессий: " + Statistics.sessions;
		battles.text = "Число боев: " + Statistics.battles;

	}
}
