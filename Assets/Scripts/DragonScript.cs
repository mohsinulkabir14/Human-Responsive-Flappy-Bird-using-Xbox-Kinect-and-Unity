using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonScript : MonoBehaviour {

	public static int scoreboi = 0;
	private Rigidbody2D myRigidBody;
	public Button play;
	public int jumpcount=0;

	private Vector2 eset;
	private Animator myAnimator;
	private float jumpForce;
	private float calorieburn;
	public int c;
	public bool isAlive;
	GameManagerScript gameManager;
	public Text greText;
	uint UserID;
	KinectManager kinectManager;

	void Start () {
		for (int i = 0; i < 100; i++) {
			c++;
		}

		greText = GameObject.Find ("Text").GetComponent<Text> ();
		//greText.text = "Press any key to start the game";
		Time.timeScale = 0;

	}


	// Update is called once per frame
	void Update () {

		if(Input.anyKeyDown)
		{
			Time.timeScale = 1;
			isAlive = true;
			myRigidBody = gameObject.GetComponent<Rigidbody2D> ();
			myAnimator = gameObject.GetComponent<Animator> ();

			Vector2 eset = transform.position;



			jumpForce = 8f;
			myRigidBody.gravityScale = 0.5f;

			gameManager = GameObject.Find ("GameManager")
				.GetComponent<GameManagerScript> ();

			if (kinectManager == null)
			{
				kinectManager = KinectManager.Instance;
			}

//			UserID = kinectManager.GetPlayer1ID ();
			
		}

	
	//	if(kinectManager.GetGestureProgress(UserID,KinectGestures.Gestures.Jump)>0.5)
		if(Input.GetKeyUp(KeyCode.UpArrow))
				{
			 //   greText.text ="Right hand Raised";

			Flap ();
			jumpcount++;
			Invoke ("stopflap", 0.1f);
			 
			}

		if (Input.GetKeyDown(KeyCode.Space))
			{	
				if (Time.timeScale == 1)
					Time.timeScale=0;
				else 
					Time.timeScale=1;
			}



		//gameManager.myScoreGUI.text = gameObject.transform.position.y.ToString("R");


		//CheckIfDragonVisibleOnScreen ();
		/*if (isAlive) {
			if (Input.GetMouseButton (0)) {
				Flap ();
			} 
			CheckIfDragonVisibleOnScreen ();
		} */
	}


	void Flap(){
		myRigidBody.velocity = 
			new Vector2 (0,jumpForce);
//		kinectManager.ResetGesture (UserID, KinectGestures.Gestures.Jump);
		myAnimator.SetTrigger ("Flap");

	}


	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Obstacles") {
			isAlive = false;
			Time.timeScale = 0f;
			c = gameManager.myScore;
			calorieburn = jumpcount * 0.2f;
			gameManager.myScoreGUI.text = "Final Score: "+c+"\n\nCalorie Burn: "+calorieburn*1000+" mili calorie";
			Destroy (myRigidBody);
			Destroy (gameObject);




		}
	}

	void CheckIfDragonVisibleOnScreen() {
		if (Mathf.Abs(gameObject.transform.position.y) > 5.3f) {
			eset.y = Mathf.Clamp (eset.y, -10.0f, 10.0f);
			gameObject.transform.position = eset;
			//isAlive = false;
			//Time.timeScale = 0f;
		}


	}

	void stopflap(){
		myAnimator.SetTrigger ("stopflap");
	}
		
}















