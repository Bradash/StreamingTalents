using UnityEngine;
using static Topics;

[CreateAssetMenu(fileName = "Messages", menuName = "Scriptable Objects/Messages")]
public class Messages : ScriptableObject
{
    public string Archtype;  
    public int NarrativeStage;

    [TextArea]
    public string message;
    public int moodChange;      
    public int viewerChange;
    public OtherEmotionBase DeerEmotion;
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
    public string DragonReaction;


}
