using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Images;
using Random = UnityEngine.Random;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Tracetheletter : MonoBehaviour
{

    public GameObject Instruction;
    public GameObject VaryingItem;
    public GameObject MainItem;

    public GameObject debuglog;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    public GameObject item7;
    public GameObject item8;
    public GameObject item9;
    public GameObject item10;

    public String MainTask = "Touch the ";
    public Sprite b;

    Image itemImage1;
    List<Question> quest = new List<Question>();
    public String[] questions;
    public int ColumnCount;

    public GameObject sel1;
    public GameObject sel2;
    public GameObject sel3;
    public GameObject sel4;
    public GameObject sel5;
    public GameObject sel6;
    public GameObject BigNum;
    public String CorrectAnswer;
    public GameObject Score;
    public Boolean Spell=true;
    public GameObject[] Particles;
    public Boolean ReadTheWord = false;

    Boolean IsDancing = false;
    Vector3 Op;
    Quaternion orv;
    public GameObject Bear;
    public GameObject Dance;
    public GameObject BearMusic;
    int DanceOff = 0;
    int DanceOffMax = 3;

    public Boolean NumberSection = false;

    public string xLevelName;
    float xTimeOn;
    int xWrong = 0;
    int xRight = 0;
    float xScore = 0;
    int ParticleIndex = 0;
    int CurrentNumber = 0;
    public AudioSource voice;
    
    //the object you want to serialize
    GameData gameValues = new GameData();

    string fullPath;

    //if true data will be encripted with an XOR function
    bool encrypt = false;

    int ItemCount = 3;
    int OverallScore = 0;
    int InitalNumber = 0;
    bool xExpert = false;
    public Boolean CantsayName = false;
    public Boolean ignoreSightwords=false;
    string varb="a";

    // Use this for initialization
    void Start()
    {
        WordList.AdCount = WordList.AdCount - 1;
        fullPath = Application.persistentDataPath + "/" + xLevelName + "_Data.dat";
        if (ignoreSightwords)
        {
            questions = Global.WhatLetterIsMissing;
        }
        debuglog.GetComponent<Text>().text = "Starting debugging";
        ArrayLoad();
        debuglog.GetComponent<Text>().text = "Loaded";
        PickRandomQuestion();

    }
    public void ClearTrace()
    {

    }
    public void PickRandomQuestion()
    {
        //reset();
        debuglog.GetComponent<Text>().text = "Made it";
        int QuestNum = InitalNumber;
        string Question = quest[QuestNum].pQuestion;
         varb = quest[QuestNum].pVari;

        item1.GetComponent<Text>().text = varb;
        Instruction.GetComponent<Text>().text = Question;
        item1.SetActive(true);

       // UpdateImages(varb);
        /// string Color = RandomColor();
        // string RightAnswer = quest[QuestNum].pRightAnswer;
        //   string Wrong1 = quest[QuestNum].pWrongAnswer1;
        //    string Wrong2 = quest[QuestNum].pWrongAnswer2;
        Debug.Log(Question);

        StartCoroutine(PlayAudio(varb));
       // ShowItem(InitalNumber + 1);
        //lets play audio
    }
    public void UpdateImages(String pic)
    {
        item1.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item1.GetComponent<Image>().color = RandomColor();
        item2.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item2.GetComponent<Image>().color = RandomColor();
        item3.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item3.GetComponent<Image>().color = RandomColor();
        item4.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item4.GetComponent<Image>().color = RandomColor();
        item5.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item5.GetComponent<Image>().color = RandomColor();
        item6.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item6.GetComponent<Image>().color = RandomColor();
        item7.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item7.GetComponent<Image>().color = RandomColor();
        item8.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item8.GetComponent<Image>().color = RandomColor();
        item9.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item9.GetComponent<Image>().color = RandomColor();
        item10.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + pic);
        item10.GetComponent<Image>().color = RandomColor();
    }
    public void RepeatAudio()
    {
        PlayAudio(varb);
    }
    IEnumerator PlayAudio(string word)
    {
        // ChangeColorText(variable);
        //  ShowItem(Num);
        /*    CorrectAnswer = answer;
              Instruction.GetComponent<Text>().text = Question;
              VaryingItem.GetComponent<Text>().text = variable;
              MainItem.GetComponent<Text>().text = answer;
              debuglog.GetComponent<Text>().text = "Change Text";
              */

        String SubSec = "";
        if (NumberSection)
        {
            SubSec = @"numbers\";
        }
        try
        {
            if (Resources.Load(SubSec + word.ToLower()))
            {
                AudioClip add = Resources.Load(SubSec + word.ToLower()) as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();
            }
            else
            {
                //CantsayName = true;
            }
          

          
        }
        catch(Exception ex)
        {
           // CantsayName = true;
        }
        if (CantsayName)
        {
            AudioClip add = Resources.Load("write") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
            yield return new WaitForSeconds(voice.clip.length);

            AudioClip add2 = Resources.Load("yourname") as AudioClip;
            voice.clip = add2;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
            yield return new WaitForSeconds(voice.clip.length);
        }
        else
        {
            yield return new WaitForSeconds(voice.clip.length);
        }
        /// add = Resources.Load(variable) as AudioClip;
        // voice.clip = add;
        // voice.Play();

        yield return new WaitForSeconds(voice.clip.length);
        //   add = Resources.Load(answer) as AudioClip;

        if (Spell)
        {
            StartCoroutine(SpellTheWord(word));
        }
        if (ReadTheWord)
        {
           // voice.clip = add;
           // /oice.Play();
        }
        ///read the letter

    }
    public IEnumerator SpellTheWord(String word)
    {
            for (int i = 0; i < word.Length; i++)
        { 
            AudioClip add = Resources.Load(word[i].ToString().ToLower()) as AudioClip;
            voice.clip = add;
            voice.Play();
            yield return new WaitForSeconds(voice.clip.length);
        }

        String SubSec = "";
        if (NumberSection)
        {
            SubSec = @"numbers\";
        }
        if (!CantsayName)
        {
            AudioClip add2 = Resources.Load(SubSec + word.ToLower()) as AudioClip;
            voice.clip = add2;
            voice.Play();
            yield return new WaitForSeconds(voice.clip.length);
        }
    }
    public void ItemPressBack()
    {
        StopAllCoroutines();
        StartCoroutine(SayNumberBack());
    }
    IEnumerator SayNumberBack()
    {

        item1.SetActive(false);
        InitalNumber = InitalNumber - 1;
        if (InitalNumber == -1)
        {
            InitalNumber = quest.Count-1;
        }
        CurrentNumber = 0;
        yield return new WaitForSeconds(0.2f);
        PickRandomQuestion();


    }
    public void ItemPress()
    {
        StopAllCoroutines();
        if (Global.SingleUse && !NumberSection)
        {
            Global.CurrentLesson = Global.CurrentLesson + 1;
            string NextLesson = Global.LessonPlan.Split(',')[Global.CurrentLesson];

            Debug.Log("sceneName to load: " + NextLesson);
            SceneManager.LoadScene(NextLesson);
        }
        else
        {
            StartCoroutine(SayNumber());
        }
    }
    IEnumerator SayNumber()
    {

            item1.SetActive(false);
            InitalNumber = InitalNumber + 1;
            if (InitalNumber == quest.Count)
            {
                InitalNumber = 0;
            }
            CurrentNumber = 0;
            yield return new WaitForSeconds(0.2f);
            PickRandomQuestion();
        

    }
    public void ShowItem(int num)
    {
        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);
        item4.SetActive(false);
        item5.SetActive(false);
        item6.SetActive(false);
        item7.SetActive(false);
        item8.SetActive(false);
        item9.SetActive(false);
        item10.SetActive(false);
        switch (num)
        {
            case 1:
                item1.SetActive(true);
                break;
            case 2:
                item1.SetActive(true);
                item2.SetActive(true);
                break;
            case 3:
                item1.SetActive(true);
                item2.SetActive(true);
                item3.SetActive(true);
                break;
            case 4:
                item1.SetActive(true);
                item2.SetActive(true);
                item3.SetActive(true);
                item4.SetActive(true);
                break;
            case 5:
                item1.SetActive(true);
                item2.SetActive(true);
                item3.SetActive(true);
                item4.SetActive(true);
                item5.SetActive(true);
                break;
            case 6:
                item1.SetActive(true);
                item2.SetActive(true);
                item3.SetActive(true);
                item4.SetActive(true);
                item5.SetActive(true);
                item6.SetActive(true);
                break;
            case 7:
                item1.SetActive(true);
                item2.SetActive(true);
                item3.SetActive(true);
                item4.SetActive(true);
                item5.SetActive(true);
                item6.SetActive(true);
                item7.SetActive(true);
                break;
            case 8:
                item1.SetActive(true);
                item2.SetActive(true);
                item3.SetActive(true);
                item4.SetActive(true);
                item5.SetActive(true);
                item6.SetActive(true);
                item7.SetActive(true);
                item8.SetActive(true);
                break;
            case 9:
                item1.SetActive(true);
                item2.SetActive(true);
                item3.SetActive(true);
                item4.SetActive(true);
                item5.SetActive(true);
                item6.SetActive(true);
                item7.SetActive(true);
                item8.SetActive(true);
                item9.SetActive(true);
                break;
            case 10:
                item1.SetActive(true);
                item2.SetActive(true);
                item3.SetActive(true);
                item4.SetActive(true);
                item5.SetActive(true);
                item6.SetActive(true);
                item7.SetActive(true);
                item8.SetActive(true);
                item9.SetActive(true);
                item10.SetActive(true);
                break;
        }
    }
    public void ChangeColorText(string VariableColor)
    {

        if (VariableColor.Equals("Yellow"))
        {
            VaryingItem.GetComponent<Text>().color = Color.yellow;
        }
        else if (VariableColor.Equals("Blue"))
        {
            VaryingItem.GetComponent<Text>().color = Color.blue;
        }
        else if (VariableColor.Equals("black"))
        {
            VaryingItem.GetComponent<Text>().color = Color.black;
        }
        else if (VariableColor.Equals("white"))
        {
            VaryingItem.GetComponent<Text>().color = Color.white;
        }
        else if (VariableColor.Equals("green"))
        {
            VaryingItem.GetComponent<Text>().color = Color.green;
        }
        else if (VariableColor.Equals("magenta"))
        {
            VaryingItem.GetComponent<Text>().color = Color.magenta;
        }
        else if (VariableColor.Equals("Red"))
        {
            Color newCol;
            if (ColorUtility.TryParseHtmlString("#FF7B7B", out newCol))
            { //works
                VaryingItem.GetComponent<Text>().color = newCol;
            }

        }
    }
    public void SaveGameValues()
    {
        // logText += "\nSave Started";
        gameValues.LevelName = xLevelName;
        gameValues.PlayerName = "carl";
        gameValues.NumberWrong = xWrong;
        gameValues.NumberRight = xRight;
        gameValues.UnderstandingScore = xScore;
        gameValues.IsExpert = xExpert;
    }

   


    // Update is called once per frame
    void Update()
    {
        //  PlaceRandomLocation();
      
    }
   
    IEnumerator PlayCorrectResponse(GameObject item)
    {
        xRight = xRight + 1;
        if (OverallScore < 100)
        {
            OverallScore = OverallScore + 3;
            xScore = OverallScore;
        }
        else
        {
            OverallScore = 100;
            xScore = OverallScore;
            xExpert = true;
        }
        SaveGameValues();

        Score.GetComponent<Text>().text = OverallScore.ToString();
        //build for up to six
        int rnd = Random.Range(0, 5);
        int rnd2 = Random.Range(0, 8);
        Debug.Log(rnd);

        if (item.name.Equals(item1.name))
        {
            ItemTouchEasy(sel1);
        }
        if (item.name.Equals(item2.name))
        {
            ItemTouchEasy(sel2);
        }
        if (item.name.Equals(item3.name))
        {
            ItemTouchEasy(sel3);
        }

        ParticleIndex = rnd2;
        Particles[ParticleIndex].SetActive(true);
        Particles[ParticleIndex].GetComponent<ParticleSystem>().Play();

        if (rnd.Equals(0))
        {
            AudioClip add = Resources.Load("thatsright") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(1))
        {
            AudioClip add = Resources.Load("awesome") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(2))
        {
            AudioClip add = Resources.Load("yess") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(3))
        {
            AudioClip add = Resources.Load("fantastic") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(4))
        {
            AudioClip add = Resources.Load("goodjob") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(5))
        {
            AudioClip add = Resources.Load("yourdoinggreat") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        yield return new WaitForSeconds(voice.clip.length);



      
            PickRandomQuestion();
    }
 
    public void reset()
    {
        item1.GetComponent<Image>().color = Color.white;
        item2.GetComponent<Image>().color = Color.white;
        item3.GetComponent<Image>().color = Color.white;
        item4.GetComponent<Image>().color = Color.white;
        item5.GetComponent<Image>().color = Color.white;
        item6.GetComponent<Image>().color = Color.white;
        item7.GetComponent<Image>().color = Color.white;
        item8.GetComponent<Image>().color = Color.white;
        item9.GetComponent<Image>().color = Color.white;
        item10.GetComponent<Image>().color = Color.white;
    }
    public void PlayWrongResponse()
    {
        xWrong = xWrong + 1;
        if (OverallScore > -1)
        {
            OverallScore = OverallScore - 5;
            xScore = OverallScore;
        }
        else
        {
            OverallScore = 0;
            xScore = OverallScore;
        }
        Score.GetComponent<Text>().text = OverallScore.ToString();
        SaveGameValues();
        int rnd = Random.Range(0, 3);
        Debug.Log(rnd);

        if (rnd.Equals(0))
        {
            AudioClip add = Resources.Load("awwtryagain") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(1))
        {
            AudioClip add = Resources.Load("maybenexttime") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(2))
        {
            AudioClip add = Resources.Load("mmmno") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
    }
    public Color RandomColor()
    {
        int rnd = Random.Range(0, 6);
        Debug.Log(rnd);

        /* switch (rnd)
         {
             case 0:
                 return Color.red;
             case 1:
                 return Color.blue;
             case 2:
                 return Color.blue;
             case 3:
                 return Color.white;
             case 4:
                 return Color.black;
             case 5:
                 return Color.green;
             case 6:
                 return Color.magenta;
         }*/
        return Color.white;
    }
    public void PlaceRandomLocation(string Right, string Wrong1, string Wrong2)
    {
        //build for up to six
        int rnd = Random.Range(0, ItemCount);
        Debug.Log(rnd);

        if (rnd.Equals(0))
        {
            item1.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Right);
            item1.GetComponent<Image>().color = VaryingItem.GetComponent<Text>().color;
            item2.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Wrong1);
            item2.GetComponent<Image>().color = RandomColor();
            item3.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Wrong2);
            item3.GetComponent<Image>().color = RandomColor();
        }
        if (rnd.Equals(1))
        {
            item2.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Right);
            item2.GetComponent<Image>().color = VaryingItem.GetComponent<Text>().color;
            item1.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Wrong1);
            item1.GetComponent<Image>().color = RandomColor();
            item3.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Wrong2);
            item3.GetComponent<Image>().color = RandomColor();
        }
        if (rnd.Equals(2))
        {
            item3.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Right);
            item3.GetComponent<Image>().color = VaryingItem.GetComponent<Text>().color;
            item2.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Wrong1);
            item2.GetComponent<Image>().color = RandomColor();
            item1.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Wrong2);
            item1.GetComponent<Image>().color = RandomColor();
        }
        if (rnd.Equals(3))
        {
            itemImage1 = item1.GetComponent<Image>();
            itemImage1.sprite = Resources.Load<Sprite>("loving");
        }
        if (rnd.Equals(4))
        {
            itemImage1 = item1.GetComponent<Image>();
            itemImage1.sprite = Resources.Load<Sprite>("yellow");
        }
        if (rnd.Equals(5))
        {
            itemImage1 = item1.GetComponent<Image>();
            itemImage1.sprite = Resources.Load<Sprite>("banana");
        }
    }
    public void ItemTouched(GameObject item)
    {
        Debug.Log("Item touched " + item.name);
        string imageName = item.GetComponent<Image>().sprite.name;
        Debug.Log("Image touched: " + imageName);


        if (imageName.Equals(CorrectAnswer))
        {
            Debug.Log("correct!!!!!!!!!!!!");


            StartCoroutine(PlayCorrectResponse(item));
        }
        else
        {
            Debug.Log("Wrong!!!!!!!!!");
            PlayWrongResponse();
        }


    }
    public void CheckIfCorrect()
    {

    }
    public void ItemTouchEasy(GameObject sel)
    {
        if (!sel.activeSelf)
        {
            sel.SetActive(true);
        }
        else
        {
            sel.SetActive(false);
        }


    }
    public void ArrayLoad()
    {
        try
        {
            if (Global.SingleUse && !NumberSection)
            {
                Question ques1 = new Question
                {
                    pQuestion = MainTask + Global.CrossSceneInformation,
                    pVari = Global.CrossSceneInformation,
                    pRightAnswer = "",
                    pWrongAnswer1 = "",
                    pWrongAnswer2 = ""

                };
                quest.Add(ques1);
            }
            else
            {
                foreach (string Ques in questions)
                {
                    String[] MinorQuestion = Ques.Split(',');
                    Question ques1 = new Question
                    {
                        pQuestion = MainTask + Ques,
                        pVari = Ques,
                        pRightAnswer = "",
                        pWrongAnswer1 = "",
                        pWrongAnswer2 = ""

                    };
                    quest.Add(ques1);
                }
            }
            //   debuglog.GetComponent<Text>().text = "completed ";
        }
        catch (Exception e)
        {
            //   debuglog.GetComponent<Text>().text = "Unable to connect to db "+e.ToString();
        }
    }
}
