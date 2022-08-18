using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Images;
using Random = UnityEngine.Random;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class TouchThePhonics : MonoBehaviour
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

    public GameObject ItemText1;
    public GameObject ItemText2;
    public GameObject ItemText3;
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
    public String CorrectAnswer;
    public GameObject Score;
    public GameObject[] Particles;
    public Boolean IsPhonics = false;

    Boolean IsDancing = false;
    Vector3 Op;
    Quaternion orv;
    public GameObject Bear;
    public GameObject Dance;
    public GameObject BearMusic;
    int DanceOff = 0;
    int DanceOffMax = 3;

    public string xLevelName;
    float xTimeOn;
    int xWrong = 0;
    int xRight = 0;
    float xScore = 0;
    int ParticleIndex = 0;
    public AudioSource voice;

    //the object you want to serialize
    GameData gameValues = new GameData();

    string fullPath;

    //if true data will be encripted with an XOR function
    bool encrypt = false;
    int QuestNum = 0;
    int ItemCount = 3;
    int OverallScore = 0;
    bool xExpert = false;

    // Use this for initialization
    void Start()
    {
        WordList.AdCount = WordList.AdCount - 1;
        Op = Dance.transform.position;
        orv = Dance.transform.rotation;

        fullPath = Application.persistentDataPath + "/" + xLevelName + "_Data.dat";
        
        debuglog.GetComponent<Text>().text = "Starting debugging";
        ArrayLoad();
        debuglog.GetComponent<Text>().text = "Loaded";
        PickRandomQuestion();

    }
    public void PickRandomQuestion()
    {
        reset();
        debuglog.GetComponent<Text>().text = "Made it";

        string Question = quest[QuestNum].pQuestion;
        string Color = quest[QuestNum].pVari;
        string RightAnswer = quest[QuestNum].pRightAnswer;
        string Wrong1 = quest[QuestNum].pWrongAnswer1;
        string Wrong2 = quest[QuestNum].pWrongAnswer2;
        QuestNum = QuestNum + 1;
        if (QuestNum >= quest.Count)
        {
            QuestNum = 0;
        }
        Debug.Log(Question);
      

        StartCoroutine(PlayAudio(Question, Color, RightAnswer, Wrong1, Wrong2));
        //lets play audio
    }
    IEnumerator PlayAudio(string Question, string variable, string answer, string Wrong1, string Wrong2)
    {
        //   ChangeColorText(variable);
        PlaceRandomLocation(answer, Wrong1, Wrong2);
        CorrectAnswer = answer;
        Instruction.GetComponent<Text>().text = Question;
        VaryingItem.GetComponent<Text>().text = variable;
        //MainItem.GetComponent<Text>().text = answer;
        //debuglog.GetComponent<Text>().text = "Change Text";

        if (IsPhonics)
        {
            Instruction.GetComponent<Text>().text = "What starts with the sound ";
        }

        AudioClip add = Resources.Load("whatstartswiththeletter") as AudioClip;
        voice.clip = add;
        //  voice.clip = Resources.Load<AudioClip>("14.mp3");
        voice.Play();

        yield return new WaitForSeconds(voice.clip.length);
        add = Resources.Load(variable.ToLower()) as AudioClip;
        voice.clip = add;
        voice.Play();
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
        if (Dance.activeSelf && IsDancing)
        {
            IsDancing = false;
            StartCoroutine(returnToMenu());
        }
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


        reset();
        DanceOff = DanceOff + 1;
        if (DanceOff >= DanceOffMax)
        {
            DanceOff = 0;
            DanceBear();
        }
        else
        {
            PickRandomQuestion();
        }
      
    }
    IEnumerator returnToMenu()
    {
        int rnd2 = Random.Range(0, 5);
        AudioClip axx;
        switch (rnd2)
        {
            case 0:
                axx = Resources.Load("goteddy") as AudioClip;
                voice.clip = axx;
                break;
            case 1:
                axx = Resources.Load("goteddy2") as AudioClip;
                voice.clip = axx;
                break;
            case 2:
                axx = Resources.Load("goteddy3") as AudioClip;
                voice.clip = axx;
                break;
            case 3:
                axx = Resources.Load("goteddy4") as AudioClip;
                voice.clip = axx;
                break;
            case 4:
                axx = Resources.Load("goteddy5") as AudioClip;
                voice.clip = axx;
                break;
            case 5:
                axx = Resources.Load("goteddy6") as AudioClip;
                voice.clip = axx;
                break;
        }
        if (voice.clip == null)
        {
            axx = Resources.Load("goteddy6") as AudioClip;
            voice.clip = axx;
        }
        //  voice.clip = Resources.Load<AudioClip>("14.mp3");
        voice.Play();
        yield return new WaitForSeconds(voice.clip.length);
        Dance.SetActive(false);
        PickRandomQuestion();
    }
    public void DanceBear()
    {
        Dance.SetActive(true);
        IsDancing = true;

        Animator anim = Dance.GetComponent<Animator>();
        Transform DanceT = Dance.GetComponent<Transform>();
        DanceT.rotation = orv;
        DanceT.position = Op;
        // Actually i was using "Resources" folder in assets folder. And i was loading animation by this way.
        int rnd2 = Random.Range(0, 18);
        String DanceMode = "TD1";
        switch (rnd2)
        {
            case 0:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD1");
                DanceMode = "TD1";
                break;
            case 1:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD2");
                DanceMode = "TD2";
                break;
            case 2:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD3");
                DanceMode = "TD3";
                break;
            case 3:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD4");
                DanceMode = "TD4";
                break;
            case 4:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD5");
                DanceMode = "TD5";
                break;
            case 5:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD6");
                DanceMode = "TD6";
                break;
            case 6:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD7");
                DanceMode = "TD7";
                break;
            case 7:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD8");
                DanceMode = "TD8";
                break;
            case 8:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TD9");
                DanceMode = "TD9";
                break;
            case 9:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance1");
                DanceMode = "TeddyDance1";
                break;
            case 10:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance2");
                DanceMode = "TeddyDance2";
                break;
            case 11:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance3");
                DanceMode = "TeddyDance3";
                break;
            case 12:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance4");
                DanceMode = "TeddyDance4";
                break;
            case 13:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance8");
                DanceMode = "TeddyDance8";
                break;
            case 14:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance6");
                DanceMode = "TeddyDance6";
                break;
            case 15:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance8");
                DanceMode = "TeddyDance8";
                break;
            case 16:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance8");
                DanceMode = "TeddyDance8";
                break;
            case 17:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance9");
                DanceMode = "TeddyDance9";
                break;
            case 18:
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("TeddyDance10");
                DanceMode = "TeddyDance10";
                break;
        }

        anim.Play(DanceMode);

    }
    public void reset()
    {
        if (Particles[ParticleIndex].GetComponent<ParticleSystem>().isPlaying)
        {
            Particles[ParticleIndex].GetComponent<ParticleSystem>().Stop();
        }

        sel1.SetActive(false);
        sel2.SetActive(false);
        sel3.SetActive(false);
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

        switch (rnd)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.yellow;
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
        }
        return Color.blue;
    }
    public void PlaceRandomLocation(string Right, string Wrong1, string Wrong2)
    {
        //build for up to six
        int rnd = Random.Range(0, ItemCount);
        Debug.Log(rnd);

        if (rnd.Equals(0))
        {
            item1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Right);
            item2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Wrong1);
            item3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Wrong2);

            ItemText1.GetComponent<Text>().text = CleanUpImageWording(Right);
            ItemText2.GetComponent<Text>().text = CleanUpImageWording(Wrong1);
            ItemText3.GetComponent<Text>().text = CleanUpImageWording(Wrong2);
        }
        if (rnd.Equals(1))
        {
            item2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Right);
            item1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Wrong1);
            item3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Wrong2);

            ItemText2.GetComponent<Text>().text = CleanUpImageWording(Right);
            ItemText1.GetComponent<Text>().text = CleanUpImageWording(Wrong1);
            ItemText3.GetComponent<Text>().text = CleanUpImageWording(Wrong2);
        }
        if (rnd.Equals(2))
        {
            item3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Right);
            item2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Wrong1);
            item1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + Wrong2);

            ItemText3.GetComponent<Text>().text = CleanUpImageWording(Right);
            ItemText2.GetComponent<Text>().text = CleanUpImageWording(Wrong1);
            ItemText1.GetComponent<Text>().text = CleanUpImageWording(Wrong2);
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
    public String CleanUpImageWording(String Word)
    {
        Word = Word.Replace("1", "");
        Word = Word.Replace("2", "");
        Word = Word.Replace("3", "");
        Word = Word.Replace(" (1)", "");
        Word = Word.Replace(" (2)", "");
        Word = Word.Replace(" (3)", "");

        Word = char.ToUpper(Word[0]) + Word.Substring(1);
        return Word;
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

            foreach (string Ques in questions)
            {
                String[] MinorQuestion = Ques.Split(',');
                Question ques1 = new Question
                {
                    pQuestion = MainTask,
                    pVari = MinorQuestion[0].ToString(),
                    pRightAnswer = MinorQuestion[1].ToString(),
                    pWrongAnswer1 = MinorQuestion[2].ToString(),
                    pWrongAnswer2 = MinorQuestion[3].ToString()

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
