using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextMessage", menuName = "Scriptable Objects/TextMessage")]
public class TextMessage : ScriptableObject
{
    public int day;

    public MessageGroup speaker;

    public bool groupChat;

    [TextArea(3, 10)]
    public string message;

    public MessageFlowType flowType;

    // Auto
    public TextMessage nextMessage;

    // Question
    public List<TextingOption> options;
}


public enum MessageFlowType
{
    Auto,       // goes directly to nextMessage
    Question    // waits for player choice
}
