using UnityEngine;

[CreateAssetMenu(fileName = "Topics", menuName = "Scriptable Objects/Topics")]
public class Topics : ScriptableObject
{
    public string Archtype;
    public int NarrativeStage;

    [TextArea]
    public string TopicName;
    public int moodChange;
    public int viewerChange;
    public string DeerEmotion;

    [TextArea]
    public string DeerReaction;
    [TextArea]
    public string WolfReaction;
    [TextArea]
    public string OniReaction;
    [TextArea]
    public string DragonReactione;
}
