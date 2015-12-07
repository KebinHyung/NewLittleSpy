/*
Name: Kevin Luu
File: DestroyByContact.cs
Last Modified by: Kevin Luu
Date Last Modified: October 26, 2015
Program Description: Destroys the coin gameobject when the player tagged gameobject collides with it after playing a 
sound clip.
 */

using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Destroy(gameObject, 0.4f);
			GetComponent<AudioSource>().Play();

		}
	}
}
