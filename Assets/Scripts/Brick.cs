using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	// This code will basically calculate the number of times each brick is hit by incrementing its initial number. 
	//Also it shows on the inspector window of that particular brick, hw many times it's been hit.
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	//public int maxHits;
	//public int timesHit; Initially we used this as public so that we could see. But we will actually use it as private.
	
	 private int timesHit; 
	 
	 private LevelManager levelManager;
	 private bool isBreakable;

	// Use this for initialization
	void Start () {
		
		isBreakable = (this.tag == "Breakable");
		//Keep track of the breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
}
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHit = timesHit + 1;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprites();
			}
		}
	void PuffSmoke() {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
			} else {
			    Debug.LogError ("Brick Sprite missing");
			    }
		}
		
		//TODO Remove this method once we actually win!
		void SimulateWin () {
		     levelManager.LoadNextLevel();
		}
	}