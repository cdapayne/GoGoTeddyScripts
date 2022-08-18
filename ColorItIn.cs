using Assets.Images;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorItIn : MonoBehaviour {

    public GameObject Title;
    public GameObject Prev;
    public GameObject Next;
    public GameObject Home;
    public GameObject Picture;
    public GameObject Color1, Color2, Color3;
    public GameObject Color1Select, Color2Select, Color3Select;

    public String[] questions;
    List<Question> quest = new List<Question>();
    int Indexa = 0;
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
        ListSize = WordList.ColorItIn.Split(',').Length;
        GetArray(WordList.ColorItIn.Split(','));
        PickRandomQuestion();
    }
 
 
    public void PickRandomQuestion()
    {
        Reset();
        ChangePicture(quest[Indexa].pVari);
        Title.GetComponent<Text>().text = quest[Indexa].pQuestion;

 
      StartCoroutine(PlayAudio(quest[Indexa].pVari,quest[Indexa].pRightAnswer));
        SetupColorSelection(quest[Indexa].pRightAnswer);
        //lets play audio
    }
    public void SetupColorSelection(String CorrectColor)
    {
        int rnd = UnityEngine.Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                Color1.GetComponent<Image>().color = GetRandomColor(CorrectColor);
                Color2.GetComponent<Image>().color = GetColor(CorrectColor);
                Color3.GetComponent<Image>().color = GetRandomColor(CorrectColor);
                break;
            case 1:
                Color1.GetComponent<Image>().color = GetRandomColor(CorrectColor);
                Color2.GetComponent<Image>().color = GetRandomColor(CorrectColor);
                Color3.GetComponent<Image>().color = GetColor(CorrectColor);
                break;
            case 2:
                Color1.GetComponent<Image>().color = GetColor(CorrectColor);
                Color2.GetComponent<Image>().color = GetRandomColor(CorrectColor);
                Color3.GetComponent<Image>().color = GetRandomColor(CorrectColor);
                break;
        }
    }
    public Color GetRandomColor(String NotthisColor)
    {
        Color newCol;
        Color SelectedColor = Color.blue;
        int rnd = UnityEngine.Random.Range(0, 11);
        switch (rnd)
        {
            case 0:
                if (ColorUtility.TryParseHtmlString("#000000", out newCol) && !NotthisColor.Equals("black"))
                {
                    return newCol;
                }
                else
                {
                    return Color.white;
                }
            case 1:
                if (ColorUtility.TryParseHtmlString("#FFFFFF", out newCol) && !NotthisColor.Equals("white"))
                {
                    return newCol;
                }
                else
                {
                    return Color.black;
                }
            case 2:
                if (ColorUtility.TryParseHtmlString("#006432", out newCol) && !NotthisColor.Equals("green"))
                {
                    return newCol;
                }
                else
                {
                    return Color.magenta;
                }
            case 3:
                if (ColorUtility.TryParseHtmlString("#C80FA0", out newCol) && !NotthisColor.Equals("purple"))
                {
                    return newCol;
                }
                else
                {
                    return Color.green;
                }
            case 4:
                if (ColorUtility.TryParseHtmlString("#FFC800", out newCol) && !NotthisColor.Equals("yellow"))
                {
                    return newCol;
                }
                else
                {
                    return Color.blue;
                }
            case 5:
                if (ColorUtility.TryParseHtmlString("#230FD2", out newCol) && !NotthisColor.Equals("blue"))
                {
                    return newCol;
                }
                else
                {
                    return Color.yellow;
                }
            case 6:
                if (ColorUtility.TryParseHtmlString("#FF5000", out newCol) && !NotthisColor.Equals("red"))
                {
                    return newCol;
                }
                else
                {
                    return Color.white;
                }
            case 7:
                if (ColorUtility.TryParseHtmlString("#FFFF00", out newCol) && !NotthisColor.Equals("yellow"))
                {
                    return newCol;
                }
                else
                {
                    return Color.red;
                }
            case 8:
                if (ColorUtility.TryParseHtmlString("#FF0064", out newCol) && !NotthisColor.Equals("pink"))
                {
                    return newCol;
                }
                else
                {
                    return Color.black;
                }

        }
        return Color.blue;
    }
    public Color GetColor(String Colorx)
    {
        Color newCol;
        Color SelectedColor = Color.blue;
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
                SelectedColor = newCol;
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
            if (ColorUtility.TryParseHtmlString("#ffa500", out newCol))
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

    IEnumerator PlayAudio(string word,string colorx)
    {
      
            AudioClip add = Resources.Load("colorthe") as AudioClip;
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

            AudioClip add3 = Resources.Load(colorx) as AudioClip;
            voice.clip = add3;
            //  voice.clip = Resources.Load<AudioClip>("14.mp3");
            voice.Play();
            /// add = Resources.Load(variable) as AudioClip;
            // voice.clip = add;
            // voice.Play();

            yield return new WaitForSeconds(voice.clip.length);
            //   add = Resources.Load(answer) as AudioClip;
      

        ///read the letter

    }
    public void ChangePicture(String Word)
    {
        Picture.GetComponent<Image>().sprite = Resources.Load<Sprite>("BlackWhite/" + Word);
    }
    public void NextWord()
    {
        StopAllCoroutines();
        if (Indexa < ListSize - 1)
        {
            Indexa = Indexa + 1;
        }
        else
        {
            Indexa = 0;
        }
        PickRandomQuestion();
    }
    public void Reset()
    {
        Color1Select.SetActive(false);
        Color2Select.SetActive(false);
        Color3Select.SetActive(false);
    }

    public void GetArray(string[] ArrayName)
    {
        try
        {
            questions = ArrayName;

            foreach (string Ques in questions)
            {
                String Itemx = Ques.Split('_')[0];
                String Colorx = Ques.Split('_')[1];
                Question ques1 = new Question
                {
                    pQuestion = "Color the " + Itemx + " " + Colorx,
                    pVari = Itemx,
                    pRightAnswer = Colorx
                    

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
       
    }
}
