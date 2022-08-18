using Assets.Images;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhatLetterIsMissing : MonoBehaviour {

    public GameObject Title;
    public GameObject Word;
    public GameObject RepeatWord;
    public GameObject HomeBtn;
    public GameObject Score;
    public GameObject Letter1, Letter2, Letter3;
    public String[] questions;
    List<Question> quest = new List<Question>();
    int LetterMissingIndex = 0;
    public char CorrectLetter = 'x';
    public AudioSource voice;
    public string correctWord = "";

    Boolean IsDancing = false;
    Vector3 Op;
    Quaternion orv;
    public GameObject Bear;
    public GameObject Dance;
    public GameObject BearMusic;
    int DanceOff = 0;
    int DanceOffMax = 3;

    int ListSize = 0;
    // Use this for initialization
    void Start () {
        WordList.AdCount = WordList.AdCount - 1;
        Op = Dance.transform.position;
        orv = Dance.transform.rotation;
        ListSize = Global.WhatLetterIsMissing.Length;
        GetArray(Global.WhatLetterIsMissing);
        
        RemoveRandomLetter(quest[LetterMissingIndex].pVari);

    }
    public void PlaceRandomLetters(char RandomLet)
    {
        string l1 = GetRandomLetter().ToLower().ToString();
        string l2 = GetRandomLetter().ToLower().ToString();
        string l3 = GetRandomLetter().ToLower().ToString();

        Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Lets/" + l1.ToLower().ToString());
        Letter2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Lets/" + l2.ToLower().ToString());
        Letter3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Lets/" + l3.ToLower().ToString());

        if (l1.ToLower().ToString().Equals(RandomLet.ToString()) || l2.ToLower().Equals(RandomLet.ToString()) || l3.ToLower().Equals(RandomLet.ToString()))
        {
            PlaceRandomLetters(RandomLet);
        }
    }
    public void RemoveRandomLetter(string word)
    {
        int rnd = UnityEngine.Random.Range(0, word.Length);
        correctWord = word;
        CorrectLetter = word[rnd];
        word = word.Replace(CorrectLetter, '_');
        PlaceRandomLetters(CorrectLetter);
        StartCoroutine(PlayAudio(correctWord));
        
        PlaceRandomCorrect(CorrectLetter);
        Word.GetComponent<Text>().text = word;

    }
    public void RepeatVal()
    {
        AudioClip add2 = Resources.Load(correctWord.ToLower().ToString()) as AudioClip;
        voice.clip = add2;
        //  voice.clip = Resources.Load<AudioClip>("14.mp3");
        voice.Play();
    }
    //IEnumerator PlayAudio(string Question)
    public IEnumerator PlayAudio(String SayThis,int resp=0)
    {
        if (resp == 0)
        {
            AudioClip add = Resources.Load("whatletterismissing") as AudioClip;
            voice.clip = add;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();

            yield return new WaitForSeconds(voice.clip.length);
        }

        AudioClip add2 = Resources.Load(SayThis.ToLower().ToString()) as AudioClip;
        voice.clip = add2;
        //  voice.clip = Resources.Load<AudioClip>("14.mp3");
        voice.Play();

        if (resp==1)
        {
            Word.GetComponent<Text>().text = correctWord;
            yield return new WaitForSeconds(voice.clip.length);
            StartCoroutine(PlayCorrectResponse());
          
        }
        else if (resp == 2)
        {
            StartCoroutine(PlayWrongResponse());
        }
    }
    public void PlaceRandomCorrect(char letterx)
    {
       
            int rnd = UnityEngine.Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                Letter1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Lets/" + letterx.ToString());
                break;
            case 1:
                Letter2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Lets/" + letterx.ToString());
                break;
            case 2:
                Letter3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Lets/" + letterx.ToString());
                break;
        }
    }
    public void CheckIfCorrect(GameObject item)
    {
        String ClickedLetter = item.GetComponent<Image>().sprite.name.ToString();
        if (ClickedLetter.Equals(CorrectLetter.ToString().ToLower()))
        {
            StartCoroutine(PlayAudio(CorrectLetter.ToString().ToLower(),1));
            
            if (LetterMissingIndex < ListSize-1)
            {
                LetterMissingIndex = LetterMissingIndex + 1;
            }
            else
            {
                LetterMissingIndex = 0;
            }
           // PlayAudio(CorrectLetter.ToString().ToLower(), 1);
         
        }
        else
        {
            StartCoroutine(PlayWrongResponse());
        }
    }

    public IEnumerator PlayCorrectResponse()
    {
        //build for up to six
        int rnd = UnityEngine.Random.Range(0, 7);
        int rnd2 = UnityEngine.Random.Range(0, 7);
        Debug.Log(rnd);




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

       
        DanceOff = DanceOff + 1;
        if (DanceOff >= DanceOffMax)
        {
            DanceOff = 0;
            DanceBear();
        }
        else
        {
            RemoveRandomLetter(quest[LetterMissingIndex].pVari);
        }
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
        RemoveRandomLetter(quest[LetterMissingIndex].pVari);
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

    // Update is called once per frame
    void Update () {
        if (Dance.activeSelf && IsDancing)
        {
            IsDancing = false;
            StartCoroutine(returnToMenu());
        }
    }
    public void GetArray(string[] ArrayName)
    {
        try
        {
            questions =ArrayName;

            foreach (string Ques in questions)
            {
                Question ques1 = new Question
                {
                    pQuestion = "What Letter is missing?",
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
}
