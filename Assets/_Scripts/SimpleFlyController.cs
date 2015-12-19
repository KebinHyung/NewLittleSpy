using UnityEngine;
using System.Collections;

public class SimpleFlyController : MonoBehaviour {

	public Transform weakness;
	public GameObject deathPlay;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
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
		Instantiate (deathPlay, transform.position , Quaternion.identity);
		Destroy (this.gameObject, 0.2f);
		Destroy (deathPlay, 0.2f);
	}
}
