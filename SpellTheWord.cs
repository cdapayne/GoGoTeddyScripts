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
public class SpellTheWord : MonoBehaviour {

    public GameObject Home;
    public GameObject Title;
    public GameObject Repeat;
    public GameObject input;
    public GameObject inputParent;
    public GameObject score;

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
        ListSize = Global.SpellingWordList1.Length;
        GetArray(Global.SpellingWordList1);
        PickRandomQuestion();

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
                    pQuestion = "Spell The Word?",
                    pVari = Ques

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
    public void PickRandomQuestion()
    {
        reset();

        correctWord = quest[LetterMissingIndex].pVari.ToLower();

        StartCoroutine(SaySpellingWord(quest[LetterMissingIndex].pVari));
        //lets play audio
    }
    public IEnumerator SaySpellingWord(String Word)
    {
        AudioClip add = Resources.Load("spelltheword") as AudioClip;
        voice.clip = add;
        //  voice.clip = Resources.Load<AudioClip>("14.mp3");
        voice.Play();

        yield return new WaitForSeconds(voice.clip.length);

        AudioClip add2 = Resources.Load(Word) as AudioClip;
        voice.clip = add2;
        //  voice.clip = Resources.Load<AudioClip>("14.mp3");
        voice.Play();
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


        PickRandomQuestion();
    }
    // Update is called once per frame
    void Update () {
        //  PlaceRandomLocation();
        if (Dance.activeSelf && IsDancing)
        {
            IsDancing = false;
            StartCoroutine(returnToMenu());
        }
    }
    public void CheckWordCorrect(GameObject item)
    {
       String InputSpelling= input.GetComponent<Text>().text;

        if (LetterMissingIndex < ListSize - 1)
        {
            LetterMissingIndex = LetterMissingIndex + 1;
        }
        else
        {
            LetterMissingIndex = 0;
        }
    
        if (InputSpelling.ToLower().Equals(correctWord))
        {
            Debug.Log("Spelt correct");
            StartCoroutine(PlayCorrectResponse());
        }
        else
        {
            StartCoroutine(PlayWrongResponse());
        }
    }


    public void reset()
    {
        inputParent.GetComponent<InputField>().text = " ";
        inputParent.GetComponent<InputField>().Select();
        inputParent.GetComponent<InputField>().ActivateInputField();


        /*   if (Particles[ParticleIndex].GetComponent<ParticleSystem>().isPlaying)
           {
               Particles[ParticleIndex].GetComponent<ParticleSystem>().Stop();
           }*/
    }
  

}
