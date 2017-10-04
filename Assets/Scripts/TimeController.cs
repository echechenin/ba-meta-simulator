using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	public void SkipHours(int count) {	
		Player.SkipTime (count);
		Statistics.timepassed += count;
		Statistics.sessions += 1;
	}


}	
