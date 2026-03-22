using UnityEngine;
using static Topics;

[CreateAssetMenu(fileName = "Messages", menuName = "Scriptable Objects/Messages")]
public class Messages : ScriptableObject
{
    public string Archtype;  
    public Narrative NarrativeStage;
    public Collab NeedCollab;
    public MiniGame NeedMiniGame;

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

    public enum Narrative
    {
        Stage1 = 1,
        Stage2 = 2,
        Stage3 = 3
    }

    public enum Collab
    {
        Any = 99,
        None = 0,
        Unicorn = 1,
        Dragon = 2
    }

    public enum MiniGame
    {
        Any = 99,
        None = 0,
        SideScroller = 1,
        Tycoon = 2,
        RhythmGame = 3
    }


}
