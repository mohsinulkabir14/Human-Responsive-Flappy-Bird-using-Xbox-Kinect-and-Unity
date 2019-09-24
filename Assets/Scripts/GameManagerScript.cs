using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public Button button;
	public GameObject dragon;
	public Transform bottomObstacle,topObstacle;
	public int myScore;
	public Text myScoreGUI;
	public static GameManagerScript instance;

	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		myScore = 0;
		myScoreGUI = GameObject.Find ("Text")
			.GetComponent<Text> ();
		
		instance = this;
		InvokeRepeating ("ObstacleSpawner", .5f, 5.5f);

		audioSource = gameObject.GetComponent<AudioSource> ();

	}

	public void GmAddScore(){
		this.myScore++;
		myScoreGUI.text="Score: "+myScore;
		audioSource.Play ();
	}


	void ObstacleSpawner() {
		int rand = Random.Range (0, 2);
		float topObstacleMinY = 2f,
		topObstacleMaxY = 6f,
		bottomObstacleMinY = -6f,
		bottomObstacleMaxY = -2f;




		switch (rand) {
		case 0:
			Instantiate (
				bottomObstacle,
				new Vector2 (
					9f, 
					Random.Range (bottomObstacleMinY, bottomObstacleMaxY)
				), 
				Quaternion.identity);

			break;
		case 1:
			Instantiate (
				topObstacle,
				new Vector2 (
					9f, 
					Random.Range (topObstacleMinY, topObstacleMaxY)
				), 
				Quaternion.identity);

			break;
		}


	
	}



}





