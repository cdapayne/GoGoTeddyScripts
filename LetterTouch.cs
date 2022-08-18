using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Images;
using Random = UnityEngine.Random;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class LetterTouch : MonoBehaviour
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
    public GameObject ParticleFlyer1;
    public GameObject ParticleFlyer2;
    public GameObject ParticleFlyer3;
    public GameObject ParticleFlyer4;
    public GameObject ParticleFlyer5;
    public GameObject ParticleFlyer6;
    public GameObject ParticleFlyer7;
    public GameObject ParticleFlyer8;
    public Boolean isPhonics = false;


    public Boolean NumberMode;
    public Boolean StopTalking = false;

    public AudioSource voice;
    public Boolean LowerCaseMode;
    
    Boolean IsDancing = false;
    Vector3 Op;
    Quaternion orv;
    public GameObject Bear;
    public GameObject Dance;
    public GameObject BearMusic;
    int DanceOff = 0;
    int DanceOffMax = 3;

    int ItemCount = 3;
    int OverallScore = 0;
    int maxLetter = 25;
    int InitialStart = 0;
    String Question, Colorx, RightAnswer, Wrong1, Wrong2;
   

    // Use this for initialization
    void Start()
    {
        WordList.AdCount = WordList.AdCount - 1;
        Op = Dance.transform.position;
        orv = Dance.transform.rotation;

        debuglog.GetComponent<Text>().text = "Starting debugging";
        ArrayLoad();
        debuglog.GetComponent<Text>().text = "Loaded";
        PickRandomQuestion();
       
      

    }
    void Update()
    {
        if (Dance.activeSelf && IsDancing)
        {
                IsDancing = false;
                StartCoroutine(returnToMenu());
        }

       

    }
    IEnumerator returnToMenu()
    {

        int rnd2 = Random.Range(0, 5);
    
        AudioClip axx;
        axx = Resources.Load("goteddy3") as AudioClip;
        voice.clip = axx;
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
            default:
                axx = Resources.Load("goteddy6") as AudioClip;
                voice.clip = axx;
                break;
        }

        if (voice.clip == null)
        {
            axx = Resources.Load("goteddy6") as AudioClip;
            voice.clip = axx;
        }
            voice.Play();
            yield return new WaitForSeconds(voice.clip.length);
            Dance.SetActive(false);
            PickRandomQuestion();
       
       
    }
    public void PickRandomQuestion()
    {
    
        debuglog.GetComponent<Text>().text = "Made it";
        int QuestNum = InitialStart;
        

       
            Question = quest[QuestNum].pQuestion;
            Colorx = quest[QuestNum].pVari;
            RightAnswer = quest[QuestNum].pRightAnswer;
            Wrong1 = quest[QuestNum].pWrongAnswer1;
            Wrong2 = quest[QuestNum].pWrongAnswer2;
            Debug.Log(Question);

        if (LowerCaseMode)
        {
            RightAnswer = RightAnswer.ToLower();
            Wrong1 = Wrong1.ToLower();
            Wrong2 = Wrong2.ToLower();
        }
        // PlayAudio(Question, Color, RightAnswer, Wrong1, Wrong2);



        StartCoroutine(PlayAudio(Question, Colorx, RightAnswer, Wrong1, Wrong2,true));
        //lets play audio
    }
    public void RepeatAudio()
    {
        StartCoroutine(PlayAudio(Question, Colorx, RightAnswer, Wrong1, Wrong2,false));
    }
    IEnumerator PlayAudio(string Question, string variable, string answer, string Wrong1, string Wrong2,Boolean Replace)
    {
        //  ChangeColorText(variable);
        if (Replace)
        {
            PlaceRandomLocation(answer, Wrong1, Wrong2);
        }
        CorrectAnswer = answer;
        Instruction.GetComponent<Text>().text = Question;
        VaryingItem.GetComponent<Text>().text = variable;
        MainItem.GetComponent<Text>().text = answer;
        debuglog.GetComponent<Text>().text = "Change Text";

        if (isPhonics)
        {
            Instruction.GetComponent<Text>().text = "What letter makes the sound";
            //MainItem.GetComponent<Text>().text = answer;
            //debuglog.GetComponent<Text>().text = "Change Text";

            if (!StopTalking)
            { 

                AudioClip add = Resources.Load("whatlettermakesthissound") as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();

                yield return new WaitForSeconds(voice.clip.length);
                add = Resources.Load("x" + answer.ToLower()) as AudioClip;
                voice.clip = add;
                voice.Play();
            }
        }
        else
        {
            if (!StopTalking)
            {
                AudioClip add = Resources.Load(Question.Replace(" ", "")) as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();

                yield return new WaitForSeconds(voice.clip.length);
                add = Resources.Load(variable) as AudioClip;
                voice.clip = add;
                voice.Play();

                yield return new WaitForSeconds(voice.clip.length);
                add = Resources.Load(answer) as AudioClip;
                voice.clip = add;
                voice.Play();
            }
        }
    }
    public void ChangeColorText(string VariableColor)
    {
        if (VariableColor.Equals("wfw"))
        {
            VaryingItem.GetComponent<Text>().color = Color.red;
        }
        else if (VariableColor.Equals("Yellow"))
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
    IEnumerator PlayCorrectResponse(GameObject item)
    {
   


        StopTalking = false;
        InitialStart = InitialStart + 1;
        if (InitialStart > maxLetter)
        {
            if (Global.CrossSceneInformation != null)
            {
                if (Global.SingleUse)
                {
                    try
                    {
                        Global.CurrentLesson = Global.CurrentLesson + 1;
                        string NextLesson = Global.LessonPlan.Split(',')[Global.CurrentLesson];

                        Debug.Log("sceneName to load: " + NextLesson);
                        SceneManager.LoadScene(NextLesson);
                    }
                    catch(Exception e)
                    {
                        SceneManager.LoadScene("AllDone");
                    }
                }
            }
            InitialStart = 0;
        }

        if (OverallScore < 100)
        {
            OverallScore = OverallScore + 3;
        }
        else
        {
            OverallScore = 100;
        }


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



        if (rnd2.Equals(0))
        {
            ParticleFlyer1.SetActive(true);
            ParticleFlyer1.GetComponent<ParticleSystem>().Play();
            ParticleFlyer2.SetActive(true);
            ParticleFlyer2.GetComponent<ParticleSystem>().Play();
        }
        else if (rnd2.Equals(1))
        {
            ParticleFlyer1.SetActive(true);
            ParticleFlyer1.GetComponent<ParticleSystem>().Play();
            ParticleFlyer2.SetActive(true);
            ParticleFlyer2.GetComponent<ParticleSystem>().Play();
        }
        else if (rnd2.Equals(2))
        {
            ParticleFlyer3.SetActive(true);
            ParticleFlyer3.GetComponent<ParticleSystem>().Play();
        }
        else if (rnd2.Equals(3))
        {
            ParticleFlyer4.SetActive(true);
            ParticleFlyer4.GetComponent<ParticleSystem>().Play();
        }
        else if (rnd2.Equals(4))
        {
            ParticleFlyer5.SetActive(true);
            ParticleFlyer5.GetComponent<ParticleSystem>().Play();
        }
        else if (rnd2.Equals(5))
        {
            ParticleFlyer6.SetActive(true);
            ParticleFlyer6.GetComponent<ParticleSystem>().Play();
        }
        else if (rnd2.Equals(6))
        {
            ParticleFlyer7.SetActive(true);
            ParticleFlyer7.GetComponent<ParticleSystem>().Play();
        }
        else if (rnd2.Equals(7))
        {
            ParticleFlyer8.SetActive(true);
            ParticleFlyer8.GetComponent<ParticleSystem>().Play();
        }

        if (!StopTalking)
        {
            if (rnd.Equals(0))
            {
                AudioClip add = Resources.Load("right/thatsright") as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();
            }
            else if (rnd.Equals(1))
            {
                AudioClip add = Resources.Load("right/awesome") as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();
            }
            else if (rnd.Equals(2))
            {
                AudioClip add = Resources.Load("right/yess") as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();
            }
            else if (rnd.Equals(3))
            {
                AudioClip add = Resources.Load("right/fantastic") as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();
            }
            else if (rnd.Equals(4))
            {
                AudioClip add = Resources.Load("right/goodjob") as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();
            }
            else if (rnd.Equals(5))
            {
                AudioClip add = Resources.Load("right/yourdoinggreat") as AudioClip;
                voice.clip = add;
                //  voice.clip = Resources.Load<AudioClip>("14.mp3");
                voice.Play();
            }
            yield return new WaitForSeconds(voice.clip.length);
        }
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

       // PickRandomQuestion();
    }
    public void reset()
    {
        if (ParticleFlyer1.GetComponent<ParticleSystem>().isPlaying)
        {
            ParticleFlyer1.GetComponent<ParticleSystem>().Stop();
            ParticleFlyer2.GetComponent<ParticleSystem>().Stop();
        }
        if (ParticleFlyer3.GetComponent<ParticleSystem>().isPlaying)
        {
            ParticleFlyer3.GetComponent<ParticleSystem>().Stop();
        }
        if (ParticleFlyer4.GetComponent<ParticleSystem>().isPlaying)
        {
            ParticleFlyer4.GetComponent<ParticleSystem>().Stop();
        }
        if (ParticleFlyer5.GetComponent<ParticleSystem>().isPlaying)
        {
            ParticleFlyer5.GetComponent<ParticleSystem>().Stop();
        }

        if (ParticleFlyer6.GetComponent<ParticleSystem>().isPlaying)
        {
            ParticleFlyer6.GetComponent<ParticleSystem>().Stop();
        }
        if (ParticleFlyer7.GetComponent<ParticleSystem>().isPlaying)
        {
            ParticleFlyer7.GetComponent<ParticleSystem>().Stop();
        }
        if (ParticleFlyer8.GetComponent<ParticleSystem>().isPlaying)
        {
            ParticleFlyer8.GetComponent<ParticleSystem>().Stop();
        }

        sel1.SetActive(false);
        sel2.SetActive(false);
        sel3.SetActive(false);
    }
    public void PlayWrongResponse()
    {
        StopTalking = false;
        if (OverallScore > -1)
        {
            OverallScore = OverallScore - 5;
        }
        else
        {
            OverallScore = 0;
        }
        Score.GetComponent<Text>().text = OverallScore.ToString();

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
            item1.GetComponent<Text>().text = Right;
            item1.GetComponent<Text>().color = RandomColor();
            item2.GetComponent<Text>().text = Wrong1;
            item2.GetComponent<Text>().color = RandomColor();
            item3.GetComponent<Text>().text = Wrong2;
            item3.GetComponent<Text>().color = RandomColor();
        }
        if (rnd.Equals(1))
        {
            item2.GetComponent<Text>().text = Right;
            item2.GetComponent<Text>().color = VaryingItem.GetComponent<Text>().color;
            item1.GetComponent<Text>().text = Wrong1;
            item1.GetComponent<Text>().color = RandomColor();
            item3.GetComponent<Text>().text = Wrong2;
            item3.GetComponent<Text>().color = RandomColor();
        }
        if (rnd.Equals(2))
        {
            item3.GetComponent<Text>().text = Right;
            item3.GetComponent<Text>().color = VaryingItem.GetComponent<Text>().color;
            item2.GetComponent<Text>().text = Wrong1;
            item2.GetComponent<Text>().color = RandomColor();
            item1.GetComponent<Text>().text = Wrong2;
            item1.GetComponent<Text>().color = RandomColor();
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

        //Check if right play sound
        //Then c hange question
        //PickRandomQuestion();
    }
    public void ItemTouched(GameObject item)
    {
        Dance.SetActive(false);
        StopAllCoroutines();



        Debug.Log("Item touched " + item.name);
        string imageName = item.GetComponent<Text>().text;
        Debug.Log("Image touched: " + imageName);
        StopTalking = true;
        voice.Stop();

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

        //take some time to show congrats animation


        /* if (item.name.Equals(item4.name))
         {
             ItemTouchEasy(sel4);
         }
         if (item.name.Equals(item5.name))
         {
             ItemTouchEasy(sel5);
         }
         if (item.name.Equals(item6.name))
         {
             ItemTouchEasy(sel6);
         }*/


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
    public void ArrayLoad()
    {
        try
        {
            
                foreach (string Ques in questions)
                {
                    String[] MinorQuestion = Ques.Split(',');
                    String Vari = "Letter";
                    if (NumberMode)
                    {
                        Vari = "Number";
                    }
                    Question ques1 = new Question
                    {
                        pQuestion = MainTask,
                        pVari = Vari,
                        pRightAnswer = MinorQuestion[0].ToString(),
                        pWrongAnswer1 = MinorQuestion[1].ToString(),
                        pWrongAnswer2 = MinorQuestion[2].ToString()

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
