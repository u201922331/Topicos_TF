using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMP_Text _timertext;
    enum TimerType {Countdown, Stopwatch}
    [SerializeField] private TimerType timerType;
    [SerializeField] private float startTime = 60.0f;
    float timeToDisplay;

    private bool _isRunning;
    
    private void Awake(){
        _timertext = GetComponent<TMP_Text>();
    }

    private void OnEnable(){
        EventManager.TimerStart += EventManagerOnTimeStart;
        EventManager.TimerStop += EventManagerOnTimeStop;
    }
    private void OnDisable(){
        EventManager.TimerStart -= EventManagerOnTimeStart;
        EventManager.TimerStop -= EventManagerOnTimeStop;
    }
    private void EventManagerOnTimeStop()
    {
        _isRunning = false;
    }

    private void EventManagerOnTimeStart()
    {
        timeToDisplay = startTime;
        _isRunning = true;
    }

    private void Update()
    {
        if(!_isRunning) return;
        if(timerType == TimerType.Countdown && timeToDisplay < 0.0f) return;
        timeToDisplay += timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        _timertext.text = timeSpan.ToString(format:@"mm\:ss\:ff");

        if (timeToDisplay <= 0)
        {
            GameManager.Instance.EndGame();
            _timertext.text = "00:00:00";
        }

    }
}
