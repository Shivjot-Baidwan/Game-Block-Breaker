using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null; // static is used because we want one music player. MusicPlayer is the type of data like int. and instance is 
	// the name of music player. also we have it equal to null as at start there will be no defined thing called instance. 
	// Use this for initialization
	
	void Start () {
	if(instance != null) {
		Destroy (gameObject);
		print ("Duplicate music player start!");
	} else {
		instance = this; // this will only run when we reach the start menu for the first time.
		GameObject.DontDestroyOnLoad(gameObject);
	}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
// the if statement was initially in the start () but in lect 65 we created a void awake() to debug the double music playing and added the if statements in it.