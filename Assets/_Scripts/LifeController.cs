/*
Name: Kevin Luu
File: LifeController.cs
Last Modified by: Kevin Luu
Date Last Modified: October 26, 2015
Program Description: Displays the amount of lives the player has left. When it reaches 0, it will launch GameOver Scene
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeController : MonoBehaviour {

	public Text LifeText;
	public Text restart;
	public int life;
	private float activateTime;

	void OnLevelWasLoaded()
	{
		life -= 1;
		//Debug.Log ("LevelWasLoaded");
	}

	// Use this for initialization
	void Start () {
		activateTime = Time.time + 1.0f;
		LifeText.text = "x " + life;
		//Debug.Log ("Start");
		if (life == 0) {
			StartCoroutine(GameOver());
		}
	}


	
	// Update is called once per frame
	void Update () {
		if (Time.time > activateTime) 
		{
			restart.enabled = true;
			restart.text = "Press 'Space' to start";

		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel("Main");
		}
	}

	IEnumerator GameOver()
	{
		yield return new WaitForSeconds (2f);
		Application.LoadLevel("GameOver");
	}

}
