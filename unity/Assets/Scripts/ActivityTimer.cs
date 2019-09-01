using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivityTimer : MonoBehaviour
{
    float timer;
    float seconds;
    float minutes;
    float hours;

    bool start;

    private TMP_Text activityTimerText;

    public void StartTimer()
    {
        start = true;
    }

    void TimerIncrement()
    {
        if (start)
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
            minutes = (int)((timer / 60) % 60);
            hours = (int)(timer / 3600);

            activityTimerText = GetComponent<TMP_Text>();
            activityTimerText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void StopTimer()
    {
        start = false;
        timer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        TimerIncrement();
    }
}
