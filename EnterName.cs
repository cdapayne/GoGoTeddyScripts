using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterName : MonoBehaviour {

    public GameObject InputBox;
    public GameObject NextBtn;
    string fullPath="EnterName";
    bool encrypt = false;
    GameData gameValues = new GameData();
    
    Vector3 Op;
    Quaternion orv;
    public GameObject Bear;
    public GameObject Dance;
    public GameObject BearMusic;
    int DanceOff = 0;
    int DanceOffMax = 3;

    // Use this for initialization
    void Start () {
        WordList.AdCount = WordList.AdCount - 1;
        Op = Dance.transform.position;
        orv = Dance.transform.rotation;

    }
	
	// Update is called once per frame
	void Update () {
		
	}






   /* private void DataWasSaved(SaveResult result, string message)
    {
        Debug.Log("\nData Was Saved");
        Debug.Log("\nresult: " + result + ", message: " + message);
        if (result == SaveResult.Error)
        {
            Debug.Log("\nError saving data");
        }
    }*/

   /* private void DataWasLoaded(GameData data, SaveResult result, string message)
    {
        Debug.Log("\nData Was Loaded");
        Debug.Log("\nresult: " + result + ", message: " + message);

        if (result == SaveResult.EmptyData || result == SaveResult.Error)
        {
            Debug.Log("\nNo Data File Found -> Creating new data...");
            gameValues = new GameData();
        }

        if (result == SaveResult.Success)
        {
            gameValues = data;

            Debug.Log("loaded " + gameValues.LevelName);
            Debug.Log("loaded " + gameValues.PlayerName);
            Debug.Log("loaded " + gameValues.NumberRight);
            Debug.Log("loaded " + gameValues.NumberWrong);

            string PlayerName = gameValues.PlayerName.ToString();
            InputBox.GetComponent<Text>().text = PlayerName;

            Global.CrossSceneInformation = PlayerName;
            Global.CurrentLesson = 0;
            Global.LessonPlan = "TraceWord,LetterTouch,TraceLower";
            Global.SingleUse = true;

        }
    }*/
}
