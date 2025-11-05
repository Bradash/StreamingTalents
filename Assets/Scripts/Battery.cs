using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Battery : MonoBehaviour
{
    public bool flashlight;
    bool isDraining;
    float lightBattery = 1;
    public Light light;
    public Light lightBounce;
    public Slider slider;
    public AudioSource audioSource;
    public AudioClip flashSound;
    public AudioClip warningSound;
    public float flashTime;
    public GameObject warning;
    public AudioLowPassFilter lowPassFilter;
    public GameObject gameOver;

    // Update is called once per frame
    void Update()
    {
        lowPassFilter.cutoffFrequency = 22000* lightBattery;
        if (Input.GetMouseButtonDown(0))
        {
            if (flashlight)
            {
                audioSource.clip = flashSound;
                audioSource.Play();
                flashTime = 2f;
            }
        }
            //if Flash
            if (flashTime <= 0.01)
        {
            light.intensity = lightBattery;
            lightBounce.intensity = lightBattery / 4;
        }
        if (flashTime > 0)
        {

            flashTime -= Time.deltaTime;
            light.intensity = flashTime * lightBattery + lightBattery;
            lightBounce.intensity = flashTime * lightBattery + lightBattery;
        }

        slider.value = lightBattery;
        //Draining
        if (isDraining && lightBattery >= 0)
            lightBattery -= Time.deltaTime * 2;
        //Recovery
        else if (lightBattery < 1 && flashlight) lightBattery += Time.deltaTime / 20;
        else if (lightBattery < 1 && !flashlight) lightBattery += Time.deltaTime / 30;

        if (lightBattery <= 0.01) { 
            flashlight = false;
            audioSource.clip = warningSound;
            warning.SetActive(true);
            audioSource.Play();
        }
        if (lightBattery >= 1) { 
            flashlight = true;
            warning.SetActive(false);
        }
    }
    //Collision
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Drainer")
        {
            isDraining = true;
        }
        if (collision.gameObject.tag == "Killer")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOver.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Drainer")
        {
            isDraining = false;
        }
    }
}
