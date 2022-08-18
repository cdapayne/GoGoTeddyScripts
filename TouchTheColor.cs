using Assets.Images;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTheColor : MonoBehaviour {


    public GameObject Title;
    public GameObject Word;
    public GameObject RepeatWord;
    public GameObject HomeBtn;
    public GameObject Score;
    public GameObject Color1, Color2, Color3;
    public String Color1x, Color2x, Color3x;
    public String[] questions;
    List<Question> quest = new List<Question>();
    int LetterMissingIndex = 0;
    public String correctColor = "";
    public GameObject[] Particles;
    public AudioSource voice;
    int ParticleIndex = 0;
    String c1="", c2="", c3="";
    String Question, Colorx, RightAnswer, Wrong1, Wrong2;

    Boolean IsDancing = false;
    Vector3 Op;
    Quaternion orv;
    public GameObject Bear;
    public GameObject Dance;
    public GameObject BearMusic;
    int DanceOff = 0;
    int DanceOffMax = 3;

    int ListSize = 0;
    public string correctWord = "";
    // Use this for initialization
    void Start () {
        WordList.AdCount = WordList.AdCount - 1;
        Op = Dance.transform.position;
        orv = Dance.transform.rotation;
        String[] Colors = WordList.Colors.Split(',');
        ListSize = Colors.Length;
        GetArray(Colors);

        PlaceRandomColors(quest[LetterMissingIndex].pVari);
    }

    public void PlaceRandomColors(String RandomLet)
    {
        reset();
        c1 = GetRandomStringColor();
        c2 = GetRandomStringColor();
        c3 = GetRandomStringColor();
        Color1.GetComponent<Image>().color = GetColor(c1);
        Color2.GetComponent<Image>().color = GetColor(c2);
        Color3.GetComponent<Image>().color = GetColor(c3);



        correctColor = RandomLet;
        if (c1.Equals(correctColor) || c2.Equals(correctColor) || c3.Equals(correctColor))
        {
            PlaceRandomColors(RandomLet);
            return;
        }
        Word.GetComponent<Text>().color = GetColor(RandomLet);
        Word.GetComponent<Text>().text = RandomLet;

        int rnd = UnityEngine.Random.Range(0, 3);

        switch (rnd)
        {
            case 0:
                c1= RandomLet;
                Color1.GetComponent<Image>().color = GetColor(c1);
                break;
            case 1:
                c2 = RandomLet;
                Color2.GetComponent<Image>().color = GetColor(c2);
                break;
            case 2:
                c3 = RandomLet;
                Color3.GetComponent<Image>().color = GetColor(c3);
                break;
            case 3:
                c2 = RandomLet;
                Color2.GetComponent<Image>().color = GetColor(c2);
                break;
        }
        StartCoroutine(PlayAudio(correctColor));
    }
    public void RepeatAudio()
    {
        StartCoroutine(PlayAudio(correctColor));
    }

    IEnumerator PlayAudio(string word)
    {

        AudioClip add = Resources.Load("touchthecolor2") as AudioClip;
        voice.clip = add;
        //  voice.clip = Resources.Load<AudioClip>("14.mp3");
        voice.Play();
        /// add = Resources.Load(variable) as AudioClip;
        // voice.clip = add;
        // voice.Play();

        yield return new WaitForSeconds(voice.clip.length);

        AudioClip add2 = Resources.Load(word) as AudioClip;
        voice.clip = add2;
        //  voice.clip = Resources.Load<AudioClip>("14.mp3");
        voice.Play();

        yield return new WaitForSeconds(voice.clip.length);
        
        //   add = Resources.Load(answer) as AudioClip;


        ///read the letter

    }
    public void reset()
    {
        if (Particles[ParticleIndex].GetComponent<ParticleSystem>().isPlaying)
        {
            Particles[ParticleIndex].GetComponent<ParticleSystem>().Stop();
        }
    }
    public IEnumerator PlayCorrectResponse()
    {
        //build for up to six
        int rnd = UnityEngine.Random.Range(0, 7);
        int rnd2 = UnityEngine.Random.Range(0, 5);
        Debug.Log(rnd);

        if (LetterMissingIndex < ListSize - 1)
        {
            LetterMissingIndex = LetterMissingIndex + 1;
        }
        else
        {
            LetterMissingIndex = 0;
        }


        ParticleIndex = rnd2;
        Particles[ParticleIndex].SetActive(true);
        Particles[ParticleIndex].GetComponent<ParticleSystem>().Play();

        if (rnd.Equals(0))
        {
            AudioClip add = Resources.Load("right/thatsright") as AudioClip;
            voice.clip = add;
            Debug.Log("thastright");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(1))
        {
            AudioClip add = Resources.Load("right/yess") as AudioClip;
            voice.clip = add;
            Debug.Log("yess");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(2))
        {
            AudioClip add = Resources.Load("right/yess") as AudioClip;
            voice.clip = add;
            Debug.Log("yess");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(3))
        {
            AudioClip add = Resources.Load("right/fantastic") as AudioClip;
            voice.clip = add;
            Debug.Log("fantastic");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(4))
        {
            AudioClip add = Resources.Load("right/goodjob") as AudioClip;
            voice.clip = add;
            Debug.Log("goodjob");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(5))
        {
            AudioClip add = Resources.Load("right/yourdoinggreat") as AudioClip;
            voice.clip = add;
            Debug.Log("yourdoinggreat");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(6))
        {
            AudioClip add = Resources.Load("right/sensational") as AudioClip;
            voice.clip = add;
            Debug.Log("sensational");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(7))
        {
            AudioClip add = Resources.Load("right/youdidit") as AudioClip;
            voice.clip = add;
            Debug.Log("youdidit");
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }
        else if (rnd.Equals(8))
        {
            AudioClip add = Resources.Load("right/greatjob") as AudioClip;
            voice.clip = add;
            Debug.Log("greatjob");
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
            PlaceRandomColors(quest[LetterMissingIndex].pVari);
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
        int rnd2 = UnityEngine.Random.Range(0, 18);
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
    IEnumerator returnToMenu()
    {
        int rnd2 = UnityEngine.Random.Range(0, 6);
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
        PlaceRandomColors(quest[LetterMissingIndex].pVari);
    }
    public void CheckIfCorrect(GameObject item)
    {
        StopAllCoroutines();
        String ClickedLetter = item.GetComponent<Image>().name;
        if (ClickedLetter.Equals("Item1"))
        {
            if (correctColor.Equals(c1))
            {
                StartCoroutine(PlayCorrectResponse());
            }
            else
            {
                StartCoroutine(PlayWrongResponse());
            }
        }
        else if (ClickedLetter.Equals("Item2"))
        {
            if (correctColor.Equals(c2))
            {
                StartCoroutine(PlayCorrectResponse());
            }
            else
            {
                StartCoroutine(PlayWrongResponse());
            }
        }
        else if (ClickedLetter.Equals("Item3"))
        {
            if (correctColor.Equals(c3))
            {
                StartCoroutine(PlayCorrectResponse());
            }
            else
            {
                StartCoroutine(PlayWrongResponse());
            }
        }
        
    }
    public IEnumerator PlayWrongResponse()
    {

        int rnd = UnityEngine.Random.Range(0, 3);
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
            AudioClip add = Resources.Load("yourclose") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
        }

        yield return new WaitForSeconds(voice.clip.length);
    }
    public String GetRandomStringColor()
    {
        String newCol="";
        int rnd = UnityEngine.Random.Range(0, 9);
        switch (rnd)
        {
            case 0:
                return "black";
            case 1:
                return "white";
            case 2:
                return "brown";
            case 3:
                return "purple";
            case 4:
                return "orange";
            case 5:
                return "blue";
            case 6:
                return "red";
            case 7:
                return "green";
            case 8:
                return "yellow";
            case 9:
                return "pink";
        }
        return "white";
    }
    public Color GetColor(String Colorx)
    {
        Color newCol;
        Color SelectedColor = Color.blue ;
        if (Colorx.Equals("black"))
        {
            if (ColorUtility.TryParseHtmlString("#000000", out newCol))
            {
                SelectedColor = newCol;
            }
        }
        else if (Colorx.Equals("white"))
        {
            if (ColorUtility.TryParseHtmlString("#FFFFFF", out newCol))
            {
                SelectedColor = newCol;
            }
        }
        else if (Colorx.Equals("brown"))
        {
            if (ColorUtility.TryParseHtmlString("#006432", out newCol))
            {
                SelectedColor= newCol;
            }
        }
        else if (Colorx.Equals("purple"))
        {
            if (ColorUtility.TryParseHtmlString("#C80FA0", out newCol))
            {
                SelectedColor = newCol;
            }
        }
        else if (Colorx.Equals("orange"))
        {
            if (ColorUtility.TryParseHtmlString("#FFC800", out newCol))
            {
                SelectedColor = newCol;
            }
        }
        else if (Colorx.Equals("blue"))
        {
            if (ColorUtility.TryParseHtmlString("#230FD2", out newCol))
            {
                SelectedColor = newCol;
            }
        }
        else if (Colorx.Equals("red"))
        {
            if (ColorUtility.TryParseHtmlString("#FF5000", out newCol))
            {
                SelectedColor = newCol;
            }
        }
        else if (Colorx.Equals("green"))
        {
            if (ColorUtility.TryParseHtmlString("#00C800", out newCol))
            {
                SelectedColor = newCol;
            }
        }
         else if (Colorx.Equals("yellow"))
        {
            if (ColorUtility.TryParseHtmlString("#FFFF00", out newCol))
            {
                SelectedColor = newCol;
            }
        }
         else if (Colorx.Equals("pink"))
        {
            if (ColorUtility.TryParseHtmlString("#FF0064", out newCol))
            {
                SelectedColor = newCol;
            }
        }
        return SelectedColor;
    }
    public Color GetRandomColor()
    {

        int rnd = UnityEngine.Random.Range(0, 8);
        Color newCol;
        switch (rnd)
        {
            case 0:
                if (ColorUtility.TryParseHtmlString("#00000", out newCol))
                {
                    return newCol;
                }
                return Color.black;
            case 1:
                if (ColorUtility.TryParseHtmlString("#FF5000", out newCol))
                {
                    return newCol;
                }
                return Color.white;
            case 2:
                if (ColorUtility.TryParseHtmlString("#230FD2", out newCol))
                {
                    return newCol;
                }
                return Color.white;
            case 3:
                if (ColorUtility.TryParseHtmlString("#FFFF00", out newCol))
                {
                    return newCol;
                }
                return Color.white;
            case 4:
                if (ColorUtility.TryParseHtmlString("#FF0064", out newCol))
                {
                    return newCol;
                }
                return Color.white;
            case 5:
                if (ColorUtility.TryParseHtmlString("#00C800", out newCol))
                {
                    return newCol;
                }
                return Color.white;
            case 6:
                if (ColorUtility.TryParseHtmlString("#FFFFFF", out newCol))
                {
                    return newCol;
                }
                return Color.white;
            case 7:
                if (ColorUtility.TryParseHtmlString("#C80FA0", out newCol))
                {
                    return newCol;
                }
                return Color.white;
            case 8:
                if (ColorUtility.TryParseHtmlString("#006432", out newCol))
                {
                    return newCol;
                }
                return Color.white;
            case 9:
                if (ColorUtility.TryParseHtmlString("#FFC800", out newCol))
                {
                    return newCol;
                }
                return Color.white;
        }
        return Color.black;
    }

    public void GetArray(string[] ArrayName)
    {
        try
        {
            questions = ArrayName;

            foreach (string Ques in questions)
            {
                Question ques1 = new Question
                {
                    pQuestion = "Touch the color "+Ques,
                    pVari = Ques
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

    // Update is called once per frame
    void Update () {
        if (Dance.activeSelf && IsDancing)
        {
            IsDancing = false;
            StartCoroutine(returnToMenu());
        }
    }
}
