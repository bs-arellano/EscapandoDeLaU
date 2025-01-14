using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int time;
    public TextMeshProUGUI timeText;
    public AudioClip gameOverSound;
    public void Start()
    {
        //Seconds up to 1800 (half hour)
        time = PlayerPrefs.GetInt("Time", 0);
        //HH:MM between 00:00 and 06:00
        timeText.text = "00:00 am";
        StartCoroutine(UpdateTime());
    }

    public void SaveTime(){
        PlayerPrefs.SetInt("Time", time);
    }
    //Each second add one to the time var
    IEnumerator UpdateTime()
    {
        while (time<1800)
        {
            yield return new WaitForSeconds(1);
            time++;
            //Convert time to HH:MM (5 seconds one minute)
            timeText.text = (time / 300).ToString("00") + ":" + (time % 300 / 5).ToString("00") + " am";
            if (time == 1794){
                GetComponent<AudioSource>().PlayOneShot(gameOverSound);
            }
        }
        GameOver();
    }
    public void ReduceTime(int amount)
    {
        time -= amount;
        if (time < 0)
        {
            time = 0;
        }
        timeText.text = (time / 300).ToString("00") + ":" + (time % 300 / 5).ToString("00") + " am";
        SaveTime();
    }
    public int GetTime()
    {
        return time;
    }
    private void GameOver()
    {
        SceneManager.LoadScene("Creditos");
    }
}
