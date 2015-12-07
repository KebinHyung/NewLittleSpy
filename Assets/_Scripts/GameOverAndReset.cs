/*
Name: Kevin Luu
File: GameOverAndReset.cs
Last Modified by: Kevin Luu
Date Last Modified: October 26, 2015
Program Description: Displays the game over scene to the player and thanks him/her for playing.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverAndReset : MonoBehaviour {

	public Text resetText;

	// Use this for initialization
	void Start () {
		StartCoroutine (Reset ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Reset()
	{
		yield return new WaitForSeconds (6f);
		resetText.enabled = true;
		resetText.text = "Thanks for playing!";
	}
}
