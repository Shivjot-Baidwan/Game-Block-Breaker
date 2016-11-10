using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;// we make it private so that it's no longer exposed in the inspector.
	
	private bool hasStarted = false;// we give this to solve the problem 
	
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;// this tells us the difference between the ball and the paddle.
		//print(paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted) {// this is used in relation to the boolean hasStarted function ie if  game hasnt started
			//Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//wait for a mouse press for launch.
			if(Input.GetMouseButtonDown(0)) {// it is to be used on every frame therefore it is in the update fnc. 
				// we use getmouse down because it works with a single click whereas getmouse buttoon requires clicking.
		
				print("Mouse Button clicked, ball launching");// to launch the ball, it needs velocity which we will give in the next statement.
				hasStarted = true;// when has started becomes true run this part.
			
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);// coordinates 2x and 10y.But the ball doesnt work with this one as as soon as 
				//the ball is about to move we force it back with the code in line 19.
			
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		// *Ball doesnot trigger sound when brick is destroyed.
		//* Not 100% sure why, possibly because brick isn't there.
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range (0f, 0.2f));
		
		if(hasStarted) {
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
}
