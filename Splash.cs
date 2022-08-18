using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	public float delaytime;
	// Use this for initialization
	void Start () {
		Invoke ("LoadLevel", delaytime);
	}
	public void LoadLevel()
	{
		SceneManager.LoadScene ("HomeScreen");
	}
}
