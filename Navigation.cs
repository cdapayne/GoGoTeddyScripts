using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void CoinCheck(string scenename)
    {
        if (WordList.AdCount > 0)
        {
            Debug.Log("sceneName to load: " + scenename);
            SceneManager.LoadScene(scenename);
        }
        else
        {
            Debug.Log("sceneName to load: " + scenename);
            SceneManager.LoadScene("adscene");
        }
    }
}
