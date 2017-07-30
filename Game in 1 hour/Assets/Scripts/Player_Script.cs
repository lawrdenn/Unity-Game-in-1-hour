using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour {

	public float speed;

	public float enemySpeed;

	public int score;

	public GameObject playButton;
	public GameObject gameOverText;
	public Text scoreText;
	public GameObject gameName;


	void Start () {
		gameObject.SetActive (false);
		gameOverText.SetActive (false);
		scoreText.gameObject.SetActive (false);
		gameName.SetActive (true);
	}
	

	void Update () {
		enemySpeed += 0.001f;

		if(Input.GetKey(KeyCode.LeftArrow)){
			if (transform.position.x > -5.5f) {
				transform.position += Vector3.left * Time.deltaTime * 10 * speed;
			}
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			if (transform.position.x < 5.5f) {
				transform.position += Vector3.right * Time.deltaTime * 10 * speed;
			}
		}
		scoreText.text = "" + score;
	}
	void OnTriggerEnter (Collider col){
		if (col.gameObject.name == "Score collider") {
			score += 1;
			col.gameObject.SetActive (false);
		}
	}
	void OnCollisionEnter (Collision col){
		if (col.gameObject.name == "Enemy") {
			gameOver ();
		}
	}
	public void play(){
		gameObject.SetActive (true);
		playButton.SetActive (false);
		gameOverText.SetActive (false);
		scoreText.gameObject.SetActive (true);
		transform.position = new Vector3 (0, 0, -8);
		score = 0;
		gameName.SetActive (false);
		enemySpeed = 1;

	}
	public void gameOver(){
		gameObject.SetActive (false);
		playButton.SetActive (true);
		playButton.GetComponentInChildren<Text> ().text = "Replay?";
		gameOverText.SetActive (true);
		scoreText.gameObject.SetActive (false);

	}
}
