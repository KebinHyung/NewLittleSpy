/*
Name: Kevin Luu
File: PlayerController.cs
Last Modified by: Kevin Luu
Date Last Modified: October 26, 2015
Program Description: Allows the player to move, die and increase coin amount when interacting with coin gameobject
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	private bool facingRight = true;
	private Rigidbody2D rb2d;

	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	bool doubleJump = false;
	bool isDead;

	public Text coinValue;
	private int coinAmt = 0;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isDead == true) 
		{
			StartCoroutine(waitForDeath());
			return;
		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground", grounded);

		if (grounded) {
			doubleJump = false;
		}

		anim.SetFloat ("vSpeed", rb2d.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update()
	{
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool("ground", false);
			rb2d.AddForce(new Vector2(0, jumpForce));

			if(!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if ((other.tag == "Enemy" || other.tag == "Boundary") && !isDead) 
		{
			anim.SetBool("Hit", true);
			rb2d.AddForce(new Vector2(0,400));
			isDead = true;
		}
		if (other.tag == "Coin") {
			coinAmt +=1;
			coinValue.text = "x " + coinAmt;
		}
	}

	IEnumerator waitForDeath()
	{
		yield return new WaitForSeconds (2f);
		Application.LoadLevel ("Lives");
	}


}
