using UnityEngine;
using TMPro;
using System;

public class PlaceChoose : MonoBehaviour
{
    private InputData inputDataInstance;

    [SerializeField] private TextMeshProUGUI fromTimeText;
    [SerializeField] private TextMeshProUGUI beforeTimedateText;
    [SerializeField] private TextMeshProUGUI intervalResult;

    private DateTime localFromTime;
    private DateTime localBeforeTime;
    private TimeSpan timeInterval;

    private int minutesInterval;

    void Start()
    {
        inputDataInstance = FindObjectOfType<InputData>();

        localFromTime = inputDataInstance.inputFromTime;
        localBeforeTime = inputDataInstance.beforeTime;

        timeInterval = localBeforeTime - localFromTime;
        minutesInterval = (int)timeInterval.TotalMinutes;
            
        fromTimeText.text = $"{localFromTime.ToString("H:mm")}";
        beforeTimedateText.text = $"{localBeforeTime.ToString("H:mm")}";
        intervalResult.text = $"{minutesInterval.ToString()} minutes";
    }
}
