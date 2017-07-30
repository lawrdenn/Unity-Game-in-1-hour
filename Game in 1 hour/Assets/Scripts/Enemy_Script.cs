using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {

	private float speed;

	private float transformZ;

	public GameObject player;


	void Start () {

		transform.position = new Vector3 (Random.Range(-5.5f, 5.5f), 1, transform.position.z);

		speed = player.GetComponent<Player_Script> ().enemySpeed;

		transformZ = transform.position.z;
	}
	

	void Update () {
		speed = player.GetComponent<Player_Script> ().enemySpeed;
		transform.position += Vector3.back * Time.deltaTime * 10 * speed;
	}
	void OnCollisionEnter (Collision col){
		if (col.gameObject.name == "collider") {
			transform.position = new Vector3 (Random.Range(-5.5f, 5.5f), 1, 40);
			transform.GetChild (0).gameObject.SetActive (true);
		}
	}
	public void play(){
		
		transform.position = new Vector3 (Random.Range (-5.5f, 5.5f), 1, transformZ);

	}
}
