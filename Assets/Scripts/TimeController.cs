using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	public void Skip4Hours() {	
		Player.SkipTime (4);
		Statistics.timepassed += 4;
		Statistics.sessions += 1;
	}
}
