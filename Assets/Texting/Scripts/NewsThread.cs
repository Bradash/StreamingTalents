using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewsThread", menuName = "Scriptable Objects/NewsThread")]
public class NewsThread : ScriptableObject
{
    public int day;

    public GameObject NewsArticle;
}
