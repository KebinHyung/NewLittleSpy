using UnityEngine;
using System.Collections;

public class ToMenu : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		Application.LoadLevel ("initialMenu");
	}

}
