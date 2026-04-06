using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] private AudioSource[] musicStreamAudio;
    [SerializeField] private AudioSource[] sfxAudio;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider audioSlider;
    [SerializeField] private GameObject UI;
    public bool isFPS;

    protected virtual void OnInit()
    {

    }

    private void Start()
    {
        if (GameManager.currentday == 0 && SceneManager.GetActiveScene().name == "menu")
        {
            GameManager.musicVolume = 0.25f;
            GameManager.sfxVolume = 0.1f;
        }
        if (SceneManager.GetActiveScene().name == "IRL")
        {
            musicAudio.pitch = 1 - GameManager.currentday / 30;
        }
        musicSlider.value = GameManager.musicVolume;
        audioSlider.value = GameManager.sfxVolume;
        musicAudio.volume = GameManager.musicVolume;
        musicLoop();
        sfxLoop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        if (UI.activeSelf)
        {
            resume();
        }
        //if locked it's an FPS
        else
        {
            UI.SetActive(true);
        }
    }


    public void resume()
    {
        //if FPS lock it again after unpause
        UI.SetActive(false);
    }

    public void musicChanged()
    {
        GameManager.musicVolume = musicSlider.value;
        musicAudio.volume = GameManager.musicVolume;
        musicLoop();
    }
    public void audioChanged()
    {
        GameManager.sfxVolume = audioSlider.value;
        sfxLoop();
    }
    void musicLoop()
    {
        for (int i = 0; i < musicStreamAudio.Length; i++)
        {
            musicStreamAudio[i].volume = GameManager.musicVolume;
        }
    }
    void sfxLoop()
    {
        for (int i = 0; i < sfxAudio.Length; i++)
        {
            sfxAudio[i].volume = GameManager.sfxVolume;
        }
    }

}
