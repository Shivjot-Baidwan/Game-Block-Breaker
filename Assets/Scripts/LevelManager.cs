using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

// We will remove the Start and Update function because we will not be using it. 
// We only want to load the game scene level using the script.

	public void LoadLevel(string name) {
		Debug.Log("New Level load " + name );// load level requested, and it is to made public so that it can accessed outside of its class.
		Brick.breakableCount = 0;
		Application.LoadLevel (name);
	}
	
	public void QuitRequest() {
		Debug.Log("Quit requested ");// this will not have any parameter because we are just quiting and not loading another level. Again to be made public.
		Application.Quit();
	}
	
	public  void LoadNextLevel() {
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}	
	
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
