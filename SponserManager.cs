using UnityEngine;
using System.Collections;


public class SponserManager : MonoBehaviour {
	public float delaytime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(string LevelName)
	{
		Debug.Log ("what the hell");
		Application.LoadLevel (LevelName);
	}


}
