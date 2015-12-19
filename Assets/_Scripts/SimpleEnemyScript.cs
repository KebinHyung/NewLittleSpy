/*
Name: Kevin Luu
File: SimpleEnemyScript.cs
Last Modified by: Kevin Luu
Date Last Modified: October 26, 2015
Program Description: Animates the enemy, will flip when it collides with something or when there is no ground ahead. Will
be killed when stomped on head. 
 */

using UnityEngine;
using System.Collections;

public class SimpleEnemyScript : MonoBehaviour {

	public float velocity = 1f;
	private Rigidbody2D rb2d;
	Animator anim;
	public GameObject deathPlay;

	public LayerMask whatIsGround;

	public Transform sightStart;
	public Transform sightEnd;
	public Transform groundStart;
	public Transform groundEnd;

	public Transform weakness;

	public bool colliding;
	public bool groundAhead;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2 (velocity, rb2d.velocity.y);

		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position);
		groundAhead = Physics2D.Linecast (groundStart.position, groundEnd.position);

		//if (colliding) {
		//	transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		//	velocity *= -1;
		//}
		if (groundAhead == false) {
			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			velocity *= -1;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;

		Gizmos.DrawLine (sightStart.position, sightEnd.position);
		Gizmos.DrawLine (groundStart.position, groundEnd.position);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (colliding && col.gameObject.tag == "Coin") {
			return;
		}
		if (colliding && col.gameObject.tag != "Player" && col.gameObject.tag != "Coin") {
			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			velocity *= -1;
		}

		if (col.gameObject.tag == "Player") {
			float height = col.contacts[0].point.y - weakness.position.y;
			if(height < 0)
			{
				Dead();
				col.rigidbody.AddForce(new Vector2(0,300f));
			}
		}
	}

	void Dead()
	{
		anim.SetBool ("Hit", true);
		deathPlay = (GameObject) Instantiate (deathPlay, transform.position , Quaternion.identity);
		//Instantiate (deathPlay, transform.position , Quaternion.identity);
		Destroy (this.gameObject, 0.2f);
		Destroy (deathPlay, 0.4f);
	}
}
