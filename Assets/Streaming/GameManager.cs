using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    //Normal information
    public static int SelectedMinigame;
    public static int SelectedCollab;
    public static int currentday; //Save
    public static float currentmoney; // Save
    public static float unicornRelationship; //Save
    public static float dragonRelationship; //Save
    public static float wolfRelationship; //Save

    // tutorial stats
    public static bool seenTycoon = false;
    public static bool seenBird = false;
    public static bool seenTemple = false;
    public static bool seenRhythm = false;


    public static bool isTutorial;
    public static float musicVolume;
    public static float sfxVolume;

    //Stats screen
    public static float highestviewers;
    public static float avargeChatMood;
    public static float endOfDayMoney;
    public static float startOfDayMoney;
    public static int todayQuota;

    public static float lastHighestviewers;
    public static float lastAvargeChatMood;
    public static float lastIncome;
    public static float lastBalance;
    public static float lastTodayQuota;

    // save this!
    static public Dictionary<string, Dictionary<string, bool>> tutorialList = new()
    {
        {"Movement", new Dictionary<string, bool>{ { "Use WASD to move, use the mouse to look", false } } },
        {"Interaction", new Dictionary<string, bool>{ { "Use the key E or the left mouse button to interact with highlighted objects", false } } },
        {"Stream Setup", new Dictionary<string, bool>{ { "Here is the stream setup. You can choose which game and who you will collab with. For now, you have no collabs or games to choose.", false } } },
        {"Streaming", new Dictionary<string, bool>{ { "A lot of things to consider.", false } } },
        {"Tycoon", new Dictionary<string, bool>{ { "Click the shops to make money, click the green button to upgrade them!", false } } },
        {"Cave Flyer", new Dictionary<string, bool>{ { "Use W and S to move around the obstacles!", false } } },
        {"Lane Changer", new Dictionary<string, bool>{ { "Use the keys A and D to avoid obstacles!", false } } },
        {"Rhythm", new Dictionary<string, bool>{ { "Press the corrosponding keys (W,A,S,D) when the notes come in!", false } } },
        {"Stream Results", new Dictionary<string, bool>{ { "Great Stream! Here are the results from your stream.", false } } }
    };
}
