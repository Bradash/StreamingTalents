using System.Collections;
using TMPro;
using UnityEngine;

public class DonationManager : MonoBehaviour
{
    [Header("Timing")]
    public float minDelay = 5f;
    public float maxDelay = 10f;

    [Header("UI")]
    public TMP_Text donationText;

    [Header("Usernames")]
    public Usernames[] names;

    [Header("Display")]
    public float visibleDuration = 4f;

    void Start()
    {
        donationText.gameObject.SetActive(false);
        StartCoroutine(DonationLoop());
    }

    IEnumerator DonationLoop()
    {
        while (true)
        {
            float wait = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(wait);

            StartCoroutine(ShowDonation());
        }
    }

    void TriggerDonation()
    {
        float viewers = UIStatsManager.Instance.viewers;
        float mood = UIStatsManager.Instance.mood;

        float donationAmount = (viewers / 50f) * (mood / 50f);

        // Safety clamp so it never gives 0
        donationAmount = Mathf.Max(1f, donationAmount);

        UIStatsManager.Instance.AddMoney(donationAmount);

        string user = GetRandomUsername();
        donationText.text =
            user + " donated $" + Mathf.FloorToInt(donationAmount);

        StartCoroutine(ShowDonation());
    }

    IEnumerator ShowDonation()
    {
        float viewers = UIStatsManager.Instance.viewers;
        float mood = UIStatsManager.Instance.mood;

        float donationAmount = (viewers / 50f) * (mood / 50f);
        donationAmount = Mathf.Max(1f, donationAmount);

        UIStatsManager.Instance.AddMoney(donationAmount);

        string user = GetRandomUsername();

        donationText.text =
            user + " donated $" + Mathf.FloorToInt(donationAmount);

        donationText.gameObject.SetActive(true);

        yield return new WaitForSeconds(visibleDuration);

        donationText.gameObject.SetActive(false);
    }

    string GetRandomUsername()
    {
        if (names.Length == 0) return "Anonymous";
        return names[Random.Range(0, names.Length)].messageText;
    }
}
