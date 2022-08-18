using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learningplanx : MonoBehaviour {
    string[] templist;
    // Use this for initialization
    void Start () {
		
	}
	public void Select_prek()
    {
        templist = WordList.SightWordsPreK.Split(',');
        Global.WhatLetterIsMissing = templist;
        Global.SpellTheWord = templist;
        Global.SpellingWordList1 = templist;
    }

    public void Select_k()
    {
        templist = WordList.SightWordsKindergarten.Split(',');
        Global.WhatLetterIsMissing = templist;
        Global.SpellTheWord = templist;
        Global.SpellingWordList1 = templist;
    }
    public void Select_1st()
    {
        templist = WordList.SightWordsFirstGrade.Split(',');
        Global.WhatLetterIsMissing = templist;
        Global.SpellTheWord = templist;
        Global.SpellingWordList1 = templist;
    }
    public void Select_2nd()
    {
        templist = WordList.SightWordsSecondGrade.Split(',');
        Global.WhatLetterIsMissing = templist;
        Global.SpellTheWord = templist;
        Global.SpellingWordList1 = templist;
    }
    public void Select_3rd()
    {
        templist = WordList.SightWordsThirdGrade.Split(',');
        Global.WhatLetterIsMissing = templist;
        Global.SpellTheWord = templist;
        Global.SpellingWordList1 = templist;
    }
    public void Select_colors()
    {
        templist = WordList.Colors.Split(',');
        Global.WhatLetterIsMissing = templist;
        Global.SpellTheWord = templist;
        Global.SpellingWordList1 = templist;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
