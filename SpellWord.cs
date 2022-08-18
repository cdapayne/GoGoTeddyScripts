using Assets.Images;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellWord : MonoBehaviour {

    public GameObject Letter1, Letter2, Letter3, Letter4, Letter5, Letter6;
    public GameObject Letter7, Letter8, Letter9, Letter10, Letter11, Letter12;

    public GameObject Emp1, Emp2, Emp3, Emp4, Emp5, Emp6;
    public GameObject Emp7, Emp8, Emp9, Emp10;

    List<Question> quest = new List<Question>();

    Boolean IsDancing = false;
    Vector3 Op;
    Quaternion orv;
    public GameObject Bear;
    public GameObject Dance;
    public GameObject BearMusic;
    int DanceOff = 0;
    int DanceOffMax = 3;

    public String[] questions;
    String MainQuestion = "Spell The word";

    // Use this for initialization
    void Start () {
        WordList.AdCount = WordList.AdCount - 1;
        Op = Dance.transform.position;
        orv = Dance.transform.rotation;
        ArrayLoad();
        PlaceLetters();
        Global.SpellWords = new string[10] { "", "", "", "", "", "", "", "", "", ""};
    }
    public void PlaceLetters()
    {
       // reset();
       // debuglog.GetComponent<Text>().text = "Made it";
        int QuestNum = 0;
        if (Global.CrossSceneInformation != null)
        {
            QuestNum = int.Parse(Global.CrossSceneInformation);
        }
        else
        {
            Global.CrossSceneInformation = "0";
        }

        if (QuestNum > questions.Length-1)
        {
            QuestNum = 0;
            Global.CrossSceneInformation = "0";
        }

     //   string Question = "Drag over " + quest[QuestNum].pVari + " " + quest[QuestNum].pRightAnswer + "s";
        string Word = quest[QuestNum].pVari;

        if (!Global.SpellThis.Equals(""))
        {
            Word = Global.SpellThis;
        }
        Global.SpellingBee = true;
        if (Global.SpellingBee)
        {
            if (Global.SpellingBeeIndex == null)
            {
                Global.SpellingBeeIndex = "0";
            }
            int SBIndex = Int32.Parse(Global.SpellingBeeIndex);
            Word = Global.SpellingWordList1[SBIndex];
        }
        ShowCorrectAmountOfSpace(Word.Length);
        RandomLetters();
        PlaceCorrectLetters(Word, Word.Length);
        Global.SpellingWord = Word;
        Debug.Log(Word);


    }
    
    public void ShowCorrectAmountOfSpace(int num)
    {
        switch (num)
        {
            case 2:
                Emp1.SetActive(true); Emp2.SetActive(true);Emp3.SetActive(false); Emp4.SetActive(false); Emp5.SetActive(false); Emp6.SetActive(false);
                Emp7.SetActive(false); Emp8.SetActive(false); Emp9.SetActive(false); Emp10.SetActive(false);
                break;
            case 3:
                Emp1.SetActive(true); Emp2.SetActive(true); Emp3.SetActive(true); Emp4.SetActive(false); Emp5.SetActive(false); Emp6.SetActive(false);
                Emp7.SetActive(false); Emp8.SetActive(false); Emp9.SetActive(false); Emp10.SetActive(false);
                break;
            case 4:
                Emp1.SetActive(true); Emp2.SetActive(true); Emp3.SetActive(true); Emp4.SetActive(true); Emp5.SetActive(false); Emp6.SetActive(false);
                Emp7.SetActive(false); Emp8.SetActive(false); Emp9.SetActive(false); Emp10.SetActive(false);
                break;
            case 5:
                Emp1.SetActive(true); Emp2.SetActive(true); Emp3.SetActive(true); Emp4.SetActive(true); Emp5.SetActive(true); Emp6.SetActive(false);
                Emp7.SetActive(false); Emp8.SetActive(false); Emp9.SetActive(false); Emp10.SetActive(false);
                break;
            case 6:
                Emp1.SetActive(true); Emp2.SetActive(true); Emp3.SetActive(true); Emp4.SetActive(true); Emp5.SetActive(true); Emp6.SetActive(true);
                Emp7.SetActive(false); Emp8.SetActive(false); Emp9.SetActive(false); Emp10.SetActive(false);
                break;
            case 7:
                Emp1.SetActive(true); Emp2.SetActive(true); Emp3.SetActive(true); Emp4.SetActive(true); Emp5.SetActive(true); Emp6.SetActive(true);
                Emp7.SetActive(true); Emp8.SetActive(false); Emp9.SetActive(false); Emp10.SetActive(false);
                break;
            case 8:
                Emp1.SetActive(true); Emp2.SetActive(true); Emp3.SetActive(true); Emp4.SetActive(true); Emp5.SetActive(true); Emp6.SetActive(true);
                Emp7.SetActive(true); Emp8.SetActive(true); Emp9.SetActive(false); Emp10.SetActive(false);
                break;
            case 9:
                Emp1.SetActive(true); Emp2.SetActive(true); Emp3.SetActive(true); Emp4.SetActive(true); Emp5.SetActive(true); Emp6.SetActive(true);
                Emp7.SetActive(true); Emp8.SetActive(true); Emp9.SetActive(true); Emp10.SetActive(false);
                break;
            case 10:
                Emp1.SetActive(true); Emp2.SetActive(true); Emp3.SetActive(true); Emp4.SetActive(true); Emp5.SetActive(true); Emp6.SetActive(true);
                Emp7.SetActive(true); Emp8.SetActive(true); Emp9.SetActive(true); Emp10.SetActive(true);
                break;

        }
    }
    public String GetRandomLetter()
    {
        int rnd = UnityEngine.Random.Range(0, 26);
        switch (rnd)
        {
            case 0:
                return "A";
            case 1:
                return "B";
            case 2:
                return "C";
            case 3:
                return "D";
            case 4:
                return "E";
            case 5:
                return "F";
            case 6:
                return "G";
            case 7:
                return "H";
            case 8:
                return "I";
            case 9:
                return "J";
            case 10:
                return "K";
            case 11:
                return "L";
            case 12:
                return "M";
            case 13:
                return "N";
            case 14:
                return "O";
            case 15:
                return "P";
            case 16:
                return "Q";
            case 17:
                return "R";
            case 18:
                return "S";
            case 19:
                return "T";
            case 20:
                return "U";
            case 21:
                return "V";
            case 22:
                return "W";
            case 23:
                return "X";
            case 24:
                return "Y";
            case 25:
                return "Z";
        }
        return "S";
    }
    public void RandomLetters()
    {
        Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter2.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter3.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter4.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter5.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter6.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter7.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter8.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter9.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter11.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
        Letter12.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + GetRandomLetter());
    }
    public void PlaceCorrectLetters(String Word,int Length)
    {
       
        switch (Length)
        {
            case 2:
                Letter8.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter4.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                break;
            case 3:
                Letter8.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                Letter4.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[2].ToString().ToUpper());
                break;
            case 4:
                Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter9.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                Letter3.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[2].ToString().ToUpper());
                Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[3].ToString().ToUpper());
                break;
            case 5:
                Letter2.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter7.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                Letter11.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[2].ToString().ToUpper());
                Letter9.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[3].ToString().ToUpper());
                Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[4].ToString().ToUpper());
                break;
            case 6:
                Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter4.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                Letter3.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[2].ToString().ToUpper());
                Letter12.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[3].ToString().ToUpper());
                Letter5.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[4].ToString().ToUpper());
                Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[5].ToString().ToUpper());
                break;
            case 7:
                Letter6.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter9.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[2].ToString().ToUpper());
                Letter3.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[3].ToString().ToUpper());
                Letter5.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[4].ToString().ToUpper());
                Letter11.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[5].ToString().ToUpper());
                Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[6].ToString().ToUpper());
                break;
            case 8:
                Letter12.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                Letter2.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[2].ToString().ToUpper());
                Letter7.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[3].ToString().ToUpper());
                Letter3.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[4].ToString().ToUpper());
                Letter8.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[5].ToString().ToUpper());
                Letter11.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[6].ToString().ToUpper());
                Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[7].ToString().ToUpper());
                break;
            case 9:
                Letter11.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter2.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                Letter4.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[2].ToString().ToUpper());
                Letter3.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[3].ToString().ToUpper());
                Letter5.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[4].ToString().ToUpper());
                Letter6.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[5].ToString().ToUpper());
                Letter8.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[6].ToString().ToUpper());
                Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[7].ToString().ToUpper());
                Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[8].ToString().ToUpper());
                break;
            case 10:
                Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[0].ToString().ToUpper());
                Letter2.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[1].ToString().ToUpper());
                Letter5.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[2].ToString().ToUpper());
                Letter4.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[3].ToString().ToUpper());
                Letter8.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[4].ToString().ToUpper());
                Letter11.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[5].ToString().ToUpper());
                Letter7.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[6].ToString().ToUpper());
                Letter12.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[7].ToString().ToUpper());
                Letter9.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[8].ToString().ToUpper());
                Letter10.GetComponent<Image>().sprite = Resources.Load<Sprite>("cardboard/" + Word[9].ToString().ToUpper());
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
     
    }

    public void ArrayLoad()
    {
        try
        {

            foreach (string Ques in questions)
            {
                String[] MinorQuestion = Ques.Split(',');
                Question ques1 = new Question
                {
                    pQuestion = MainQuestion,
                    pVari = MinorQuestion[0].ToString()
                    /*pRightAnswer = MinorQuestion[1].ToString(),
                    pWrongAnswer1 = MinorQuestion[2].ToString(),
                    pWrongAnswer2 = MinorQuestion[3].ToString(),
                    pWrongAnswer3 = MinorQuestion[4].ToString()*/

                };
                quest.Add(ques1);
            }
            //   debuglog.GetComponent<Text>().text = "completed ";
        }
        catch (Exception e)
        {
            //   debuglog.GetComponent<Text>().text = "Unable to connect to db "+e.ToString();
        }
    }
}
