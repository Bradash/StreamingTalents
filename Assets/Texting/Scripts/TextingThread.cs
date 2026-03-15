using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextingThread", menuName = "Scriptable Objects/TextingThread")]
public class TextingThread : ScriptableObject
{
    public int day;
    public MessageGroup participants;
    //public bool groupChat;
    public TextMessage startingMessage;
}
