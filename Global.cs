using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{


    public static string CrossSceneInformation { get; set; }
    public static bool SingleUse { get; set; }  // C# 6 or higher
    public static string LessonPlan { get; set; } // C# 6 or higher
    public static int CurrentLesson { get; set; }  // C# 6 or higher
    public static string[] SpellWords { get; set; }
    public static string SpellingWord { get; set; }
    public static int SpellingWordIndex { get; set; }
    public static string SpellThis = "";
    public static bool SpellingBee { get; set; }
    public static string SpellingBeeIndex { get; set; }
    public static string[] SpellingWordList1 = new string[10] { "all", "am", "as", "at", "any", "an", "by", "but", "car", "do" };
    public static string[] WhatLetterIsMissing = new string[3] { "Apple", "Dog", "Wood" };
    public static string[] SpellTheWord = new string[10] { "all", "am", "as", "at", "any", "an", "by", "but", "car", "do" };
}
