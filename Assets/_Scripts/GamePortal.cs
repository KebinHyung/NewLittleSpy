using UnityEngine;
using System.Collections;

public class GamePortal : MonoBehaviour {
	private int SceneToLoad;

	void Start ()
	{
		Debug.Log(Application.loadedLevel);
	}

	void Awake()
	{
		SceneToLoad = Application.loadedLevel;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Application.LoadLevel (SceneToLoad + 1);
	}
	
}
