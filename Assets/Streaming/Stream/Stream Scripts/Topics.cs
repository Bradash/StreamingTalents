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
    public DeerEmotionBase DeerEmotion;
    public OtherEmotionBase WolfEmotion;
    public OtherEmotionBase UnicornEmotion;
    public OtherEmotionBase DragonEmotion;

    [TextArea]
    public string DeerReaction;
    [TextArea]
    public string WolfReaction;
    [TextArea]
    public string UnicornReaction;
    [TextArea]
    public string DragonReactione;

    public enum DeerEmotionBase
    {
        Neutral,
        Smile,
        Angry,
        Scared,
        Laugh
    }
    public enum OtherEmotionBase
    {
        Neutral,
        Smile,
        Angry,
        Scared,
        Laugh
    }
}
