using UnityEngine;

[CreateAssetMenu(fileName = "Messages", menuName = "Scriptable Objects/Messages")]
public class Messages : ScriptableObject
{
    public string Archtype;  
    public int NarrativeStage;

    [TextArea]
    public string message;
    public int moodChange;      
    public int viewerChange;

    [TextArea]
    public string DeerReaction;
    [TextArea]
    public string WolfReaction;
    [TextArea]
    public string OniReaction;
    [TextArea]
    public string DragonReactione;

}
