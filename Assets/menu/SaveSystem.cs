using UnityEngine;

public class SaveSystem
{
    public static void SaveGame()
    {
        PlayerPrefs.SetInt("currentday", GameManager.currentday);
        PlayerPrefs.SetFloat("currentmoney", GameManager.currentmoney);
        PlayerPrefs.SetFloat("unicornRelationship", GameManager.unicornRelationship);
        PlayerPrefs.SetFloat("dragonRelationship", GameManager.dragonRelationship);
        PlayerPrefs.SetFloat("wolfRelationship", GameManager.wolfRelationship);

        PlayerPrefs.Save();
    }

    public static void LoadGame()
    {
        GameManager.currentday = PlayerPrefs.GetInt("currentday");
        GameManager.currentmoney = PlayerPrefs.GetFloat("currentmoney");
        GameManager.unicornRelationship = PlayerPrefs.GetFloat("unicornRelationship");
        GameManager.dragonRelationship = PlayerPrefs.GetFloat("dragonRelationship");
        GameManager.wolfRelationship = PlayerPrefs.GetFloat("wolfRelationship");
    }

    public static bool SaveExists()
    {
        return PlayerPrefs.HasKey("currentday");
    }

    public static void DeleteSave()
    {
        PlayerPrefs.DeleteKey("currentday");
        PlayerPrefs.DeleteKey("currentmoney");
        PlayerPrefs.DeleteKey("unicornRelationship");
        PlayerPrefs.DeleteKey("dragonRelationship");
        PlayerPrefs.DeleteKey("wolfRelationship");
    }
}