/*
Name: Kevin Luu
File: PlatformFall.cs
Last Modified by: Kevin Luu
Date Last Modified: October 26, 2015
Program Description: A certain kind of platform on the level will fall after 1 second. 
 */

using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {

	public float fallDelay = 1f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Invoke ("Fall", fallDelay);
		}
	}
	
	void Fall()
	{
		rb2d.isKinematic = false;
		gameObject.GetComponent<Collider2D> ().enabled = false;
	}
	

}
